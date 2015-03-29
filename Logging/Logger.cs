using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtuvitRssDownloader.Logging
{
    public class Logger
    {
        private static Logger instance;
        public event EventHandler<CustomEventArgs> Log;

        private Logger() { }

        public static Logger GetInstance()
        {
            if (instance != null)
                return instance;

            instance = new Logger();
            return instance;
        }

        public virtual void Debug(string className,string s) 
        {
            DoLog(new CustomEventArgs(string.Format("[{0}]{1}", className, s), Level.Debug));
        }
        public virtual void Error(string className, string s)
        {
            DoLog(new CustomEventArgs(string.Format("[{0}]{1}", className, s), Level.Error));
        }

        public virtual void Info(string className, string s) 
        {
            DoLog(new CustomEventArgs(string.Format("[{0}]{1}", className, s), Level.Info));
        }

        private void DoLog(CustomEventArgs e)
        {
            EventHandler<CustomEventArgs> handler = Log;
            if(handler != null)
            {
                handler(this, e);
            }
        }

        public enum Level
        {
            Debug, Error, Info
        }
    }

    public class CustomEventArgs : EventArgs
    {
        public CustomEventArgs(string s,KtuvitRssDownloader.Logging.Logger.Level l)
        {
            msg = s;
            lvl = l;
        }
        private string msg;
        private KtuvitRssDownloader.Logging.Logger.Level lvl;
        public string Message
        {
            get { return msg; }
        }
        public KtuvitRssDownloader.Logging.Logger.Level Level
        {
            get { return lvl; }
        }
    }
    

}

