using KtuvitRssDownloader.Logging;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KtuvitRssDownloader.DownloadScheduler
{
    public class SimpleScheduler
    {
        private IScheduler _scheduler;
        private Logger _log = Logger.GetInstance();

        public void StartSchedule() 
        {
            
            ISchedulerFactory schedFact = new StdSchedulerFactory();

            // get a scheduler, start the schedular before triggers or anything else  
            _scheduler = schedFact.GetScheduler();
            _scheduler.Start();  

            // define the job and tie it to our HelloJob class
            IJobDetail job = JobBuilder.Create<SimpleJob>()
                .WithIdentity("job1", "group1")
                .Build();

            // Trigger the job to run now, and then repeat every 10 seconds
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(GetIntervalFromConfig())
                    .RepeatForever())
                .Build();

            // Tell quartz to schedule the job using our trigger
            _scheduler.ScheduleJob(job, trigger);
        }

        private int GetIntervalFromConfig()
        {
            return int.Parse(Utils.AppSettingsUtil.ReadFromSettings("Interval"));
        }

        public void StopScheuler()
        {
            if(_scheduler!= null && _scheduler.IsStarted)
                _scheduler.Shutdown();
        }
    }
}
