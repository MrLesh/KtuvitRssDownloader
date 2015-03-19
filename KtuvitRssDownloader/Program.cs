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
			const string url = @"http://rss.ktuvit.com/myseriesrss.php?uid=348679&ticket=AC8846E87";
			var downloader = new SubtitleDownloader();
			var feed = RssFeed.Create(new Uri(url)); 
			foreach (var item in feed.Channel.Items)
			{
				Console.WriteLine("Name:{0}, Link:{1}, Date:{2}", item.Title, item.Link, item.PublicationDate);
				if(item.HasExtensions)
				{
					var content = item.Extensions.First(i => i.XmlPrefix=="content");
					var pos1 = content.ToString().IndexOf(@";m=subtitles#");
					var pos2 = content.ToString().IndexOf(@"""", pos1);
					var id = content.ToString().Substring(pos1 + @";m=subtitles#".Length, pos2 - pos1 - @";m=subtitles#".Length);
					Console.WriteLine(string.Format("ID of subtitle:{0}", id));
					Console.WriteLine("-----------------------");
                    downloader.Download(id,item.Title.Substring(item.Title.IndexOf('|')+2));

					
				}
				
			}
		}
	}
}
