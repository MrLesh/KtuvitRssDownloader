using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Argotic.Syndication;
using System.Net;  

namespace KtuvitRssDownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = @"http://rss.ktuvit.com/myseriesrss.php?uid=348679&ticket=AC8846E87";
            string subtitleDownloadUrl = @"http://www.ktuvit.com/downloadsubtitle.php?id={0}";
            XmlReader reader = XmlReader.Create(url);
            RssFeed feed = RssFeed.Create(new Uri(url)); 
            foreach (var item in feed.Channel.Items)
            {

                Console.WriteLine(string.Format("Name:{0}, Link:{1}, Date:{2}", item.Title, item.Link, item.PublicationDate));
                if(item.HasExtensions)
                {
                    var content = item.Extensions.Where(i=>i.XmlPrefix=="content").First();
                    var pos1 = content.ToString().IndexOf(@";m=subtitles#");
                    var pos2 = content.ToString().IndexOf(@"""", pos1);
                    var id = content.ToString().Substring(pos1 + @";m=subtitles#".Length, pos2 - pos1 - @";m=subtitles#".Length);
                    Console.WriteLine(string.Format("ID of subtitle:{0}", id));
                    Console.WriteLine("-----------------------");
                    using(WebClient client = new WebClient())
	                {
                        var filename = item.Title.Substring(item.Title.IndexOf('|')+2);
                        client.DownloadFile(string.Format(subtitleDownloadUrl, id), string.Format(@"D:\TV Shows\{0}.zip", filename));
	                }
                    
                }
                
            }
        }
    }
}
