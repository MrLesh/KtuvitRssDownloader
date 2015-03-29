using KtuvitRssDownloader.RssPareserAndDownloader;
using Quartz;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using KtuvitRssDownloader.Logging;
using System.Threading;

namespace KtuvitRssDownloader.DownloadScheduler
{
    class SimpleJob:IJob
    {
        private Logger _log = Logger.GetInstance();
        public void Execute(IJobExecutionContext context)
        {
            var rssParser = new RssParser();
            var jobs = context.Scheduler.GetCurrentlyExecutingJobs();
            if (jobs.Count > 1) 
            {
                _log.Info(this.GetType().Name, string.Format("There are {0} jobs running - terminating",jobs.Count));
                return;
            }
            
            var feedUrl = Utils.AppSettingsUtil.ReadFromSettings("FeedUrl");
          //  var path = new System.Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;
           // Configuration config = ConfigurationManager.OpenExeConfiguration(Path.GetDirectoryName(path));

            _log.Debug(this.GetType().Name, feedUrl);
            //Common.Logging.LogManager.Adapter.GetLogger("SimpleJob").Debug(string.Format("{0}:{1}","kuku",DateTime.Now));
            //Console.WriteLine(ConfigurationManager.AppSettings["FeedUrl"]);
            rssParser.ParseAndDownload(feedUrl);
        }
    }
}
