using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KtuvitRssDownloader.KtuvitRssDownloaderGui
{
    public static class Extensions
    {
        public static void InvokeSafe(this Control control, Action action)
        {
            if (control != null && !control.IsDisposed)
            {
                if (control.InvokeRequired)
                {
                    control.Invoke(action);
                }
                else
                {
                    action();
                }
            }
        }
    }
}
