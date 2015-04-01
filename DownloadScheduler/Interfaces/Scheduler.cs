using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtuvitRssDownloader.DownloadScheduler.Interfaces
{
    public abstract class Scheduler
    {
        public abstract  void StartScheduler();
        public abstract void StopScheduler();
        public abstract DateTime GetTimeLeft();

        protected virtual int GetIntervalFromConfig()
        {
            return int.Parse(Utils.AppSettingsUtil.ReadFromSettings("Interval"));
        }
    }
}
