using Argotic.Syndication;
using KtuvitRssDownloader.Logging;
using KtuvitRssDownloader.Utils;
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
            var downloader = new SubtitleDownloader();
            var feed = RssFeed.Create(new Uri(feedUrl));
            DateTime recentTimeFromConfig = GetPreviousCheckTime();

            _log.Debug(string.Format("Last update was on {0}", recentTimeFromConfig));
            var itemsList = feed.Channel.Items.Where(i => i.PublicationDate > recentTimeFromConfig);
            _log.Debug(string.Format("There are {0} items", itemsList.Count()));
            foreach (var item in itemsList)
            {
                _log.Debug(string.Format("Name:{0}, Link:{1}, Date:{2}", item.Title, item.Link, item.PublicationDate));
                if (item.HasExtensions)
                {
                    var id = GetSubtitleId(item);
                    var filename = downloader.Download(id, item.Title.Substring(item.Title.IndexOf('|') + 2));
                    if(!string.IsNullOrEmpty(filename))
                    {
                        var zipUtility = new ZipUtility();
                        Task.Run(() => zipUtility.Unzip(filename));
                    }
                }
            }
            var recentPubDate = feed.Channel.Items.Max(i => i.PublicationDate);
            Utils.AppSettingsUtil.WriteASetting("NewestSubtitle", DateTime.Now);
        }

        private DateTime GetPreviousCheckTime()
        {
            var recentTimeFromConfigAsString = Utils.AppSettingsUtil.ReadFromSettings("NewestSubtitle");
             return string.IsNullOrEmpty(recentTimeFromConfigAsString) ?
                 new DateTime() :
                 DateTime.Parse(recentTimeFromConfigAsString);
        }

        private static string GetSubtitleId(RssItem item)
        {
            var content = item.Extensions.First(i => i.XmlPrefix == "content");
            var pos1 = content.ToString().IndexOf(@";m=subtitles#");
            var pos2 = content.ToString().IndexOf(@"""", pos1);
            var id = content.ToString().Substring(pos1 + @";m=subtitles#".Length, pos2 - pos1 - @";m=subtitles#".Length);
            return id;
        }
    }
}
