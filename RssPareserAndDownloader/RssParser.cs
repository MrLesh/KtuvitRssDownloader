using Argotic.Syndication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssPareserAndDownloader
{
    public class RssParser
    {
        public void ParseAndDownload(string feedUrl)
        {
            var downloader = new SubtitleDownloader();
            var feed = RssFeed.Create(new Uri(feedUrl));
            foreach (var item in feed.Channel.Items)
            {
                Console.WriteLine("Name:{0}, Link:{1}, Date:{2}", item.Title, item.Link, item.PublicationDate);
                if (item.HasExtensions)
                {
                    var content = item.Extensions.First(i => i.XmlPrefix == "content");
                    var pos1 = content.ToString().IndexOf(@";m=subtitles#");
                    var pos2 = content.ToString().IndexOf(@"""", pos1);
                    var id = content.ToString().Substring(pos1 + @";m=subtitles#".Length, pos2 - pos1 - @";m=subtitles#".Length);
                    Console.WriteLine(string.Format("ID of subtitle:{0}", id));
                    Console.WriteLine("-----------------------");
                    downloader.Download(id, item.Title.Substring(item.Title.IndexOf('|') + 2));
                }
            }
        }
    }
}
