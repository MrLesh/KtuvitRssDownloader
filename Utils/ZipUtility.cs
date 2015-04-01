using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;
using KtuvitRssDownloader.Logging;


namespace KtuvitRssDownloader.Utils
{
    public class ZipUtility
    {
        private Logger _log = Logger.GetInstance();
        public void Unzip(string filename)
        {
            using (ZipArchive archive = ZipFile.OpenRead(filename))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".srt", StringComparison.OrdinalIgnoreCase))
                    {
                        try
                        {
                            entry.ExtractToFile(Path.Combine(Path.GetDirectoryName(filename), entry.FullName));
                        }
                        catch (Exception e)
                        {
                            _log.Error(string.Format("Couldn't unzip file:{0}.Error is:{1}", filename,e.Message));
                        }
                        
                    }
                }
            } 
        }
    }
}
