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
    public class MyQuartzScehduler : KtuvitRssDownloader.DownloadScheduler.Interfaces.Scheduler
    {
        private IScheduler _scheduler;
        private Logger _log = Logger.GetInstance();
        private JobKey JobKey = new JobKey("MyJob","MyGroup");

        public override void StartScheduler() 
        {
            
            ISchedulerFactory schedFact = new StdSchedulerFactory();

            // get a scheduler, start the schedular before triggers or anything else  
            _scheduler = schedFact.GetScheduler();
            _scheduler.Start();  

            // define the job and tie it to our HelloJob class
            IJobDetail job = JobBuilder.Create<SimpleJob>()
                .WithIdentity(JobKey)
                .Build();

            // Trigger the job to run now, and then repeat every 10 seconds
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInHours(GetIntervalFromConfig())
                    .RepeatForever())
                .Build();

            // Tell quartz to schedule the job using our trigger
            var nextTimeToRun = _scheduler.ScheduleJob(job, trigger);
        }



        public override DateTime GetTimeLeft()
        {
            var triggers = _scheduler.GetTriggersOfJob(JobKey);
            if (triggers.Count > 0)
            {
                var nextFireTimeUtc = triggers[0].GetNextFireTimeUtc();
                var nextTimeLocal = TimeZoneInfo.ConvertTimeFromUtc(nextFireTimeUtc.Value.UtcDateTime, TimeZoneInfo.Local);
                return nextTimeLocal;
            }
            return DateTime.MinValue;
        }

        public override void StopScheduler()
        {
            if(_scheduler!= null && _scheduler.IsStarted)
                _scheduler.Shutdown();
        }
    }
}
