using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KtuvitRssDownloader.KtuvitRssDownloaderGui
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var myForm = new frmMainForm();
            Application.ApplicationExit += myForm.ApplicationExit;
            //Common.Logging.LogManager.Adapter = new Common.Logging.Simple. { Level = Common.Logging.LogLevel.Info};
            Application.Run(myForm);
        }
    }
}
