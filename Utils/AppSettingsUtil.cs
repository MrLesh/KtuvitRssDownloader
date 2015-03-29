using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KtuvitRssDownloader.Utils
{
    public static class AppSettingsUtil
    {
        private static object _locker = new object();
        private static Configuration config;

        public static string ReadFromSettings(string key) 
        {
            lock (_locker)
            {
                var result = Settings.Default[key];
                return result != null ? result.ToString() : "" ;
            }
            
            
        }
        public static void WriteASetting<T>(string key,T value) 
        {
            lock(_locker)
            {
                Settings.Default[key] = value;
                Settings.Default.Save();
            }
            
        }
    }
}
