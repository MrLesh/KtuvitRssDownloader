using Argotic.Syndication;
using KtuvitRssDownloader.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtuvitRssDownloader.RssPareserAndDownloader
{
    public class RssParser
    {
        private Logger _log = Logger.GetInstance();
        public void ParseAndDownload(string feedUrl)
        {
            DateTime recentTimeFromConfig;
            var downloader = new SubtitleDownloader();
            var feed = RssFeed.Create(new Uri(feedUrl));
            var recentTimeFromConfigAsString = Utils.AppSettingsUtil.ReadFromSettings("NewestSubtitle");
            if(string.IsNullOrEmpty(recentTimeFromConfigAsString))
                recentTimeFromConfig = new DateTime();
            else
                recentTimeFromConfig = DateTime.Parse(recentTimeFromConfigAsString);

            var itemsList = feed.Channel.Items.Where(i => i.PublicationDate > recentTimeFromConfig);
            _log.Debug(this.GetType().Name, string.Format("Last update was on {0}", recentTimeFromConfig));
            _log.Debug(this.GetType().Name, string.Format("There are {0} items", itemsList.Count()));
            foreach (var item in feed.Channel.Items)
            {
                _log.Debug(this.GetType().Name,string.Format("Name:{0}, Link:{1}, Date:{2}", item.Title, item.Link, item.PublicationDate));
                if (item.HasExtensions)
                {
                    var content = item.Extensions.First(i => i.XmlPrefix == "content");
                    var pos1 = content.ToString().IndexOf(@";m=subtitles#");
                    var pos2 = content.ToString().IndexOf(@"""", pos1);
                    var id = content.ToString().Substring(pos1 + @";m=subtitles#".Length, pos2 - pos1 - @";m=subtitles#".Length);
                    //Console.WriteLine(string.Format("ID of subtitle:{0}", id));
                    //Console.WriteLine("-----------------------");
                    downloader.Download(id, item.Title.Substring(item.Title.IndexOf('|') + 2));
                }
            }
            var recentPubDate = feed.Channel.Items.Max(i => i.PublicationDate);
            Utils.AppSettingsUtil.WriteASetting("NewestSubtitle", recentPubDate);
        }
    }
}
