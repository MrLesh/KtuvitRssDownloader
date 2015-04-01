using KtuvitRssDownloader.DownloadScheduler.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace KtuvitRssDownloader.DownloadScheduler.Scheduler
{
    public class TimerScheduler : KtuvitRssDownloader.DownloadScheduler.Interfaces.Scheduler
    {
        private Timer _timer;
        private DateTime _lastExecutionTime;
        public override void StartScheduler()
        {
            if(_timer == null)
            {
                _timer = new Timer(5000);
               // _timer.Interval = TimeSpan.FromHours(GetIntervalFromConfig()).TotalMilliseconds;
                _timer.AutoReset = true;
                _timer.Elapsed += TriggerJob;
                _lastExecutionTime = DateTime.Now;
                _timer.Start();
                return;
            }
            ResetTimer();
        }

        private void ResetTimer()
        {
            _timer.Stop();
            _timer.Interval = TimeSpan.FromHours(GetIntervalFromConfig()).TotalMilliseconds;
            _lastExecutionTime = DateTime.Now;
            _timer.Start();
        }

        private void TriggerJob(object sender, ElapsedEventArgs e)
        {
            _timer.Stop();
            _lastExecutionTime = DateTime.Now;
            var job = new SimpleJob();
            job.Execute();
            //ResetTimer();
        }

        public override void StopScheduler()
        {
            if(_timer != null)
            _timer.Stop();
        }

        public override DateTime GetTimeLeft()
        {
            var interval = GetIntervalFromConfig();
            return _lastExecutionTime.AddHours(interval);
        }
    }
}
