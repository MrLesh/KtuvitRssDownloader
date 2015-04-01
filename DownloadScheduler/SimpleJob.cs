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
            
            var jobs = context.Scheduler.GetCurrentlyExecutingJobs();
            if (jobs.Count > 1) 
            {
                _log.Info(string.Format("There are {0} jobs running - terminating",jobs.Count));
                return;
            }

            Execute();
        }

        public void Execute()
        {
            var rssParser = new RssParser();
            var feedUrl = Utils.AppSettingsUtil.ReadFromSettings("FeedUrl");
            _log.Debug(feedUrl);
            rssParser.ParseAndDownload(feedUrl);
        }
    }
}
