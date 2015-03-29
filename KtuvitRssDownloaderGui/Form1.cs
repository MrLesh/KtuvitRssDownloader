using Microsoft.Win32;
using System;
using System.Net;
using System.Windows.Forms;
using System.Configuration;
using System.Resources;
using KtuvitRssDownloader.DownloadScheduler;
using KtuvitRssDownloader.Logging;
using System.Drawing;
using KtuvitRssDownloader.KtuvitRssDownloaderGui;
using KtuvitRssDownloader.Utils;

namespace KtuvitRssDownloader.KtuvitRssDownloaderGui
{
    public partial class frmMainForm : Form
    {
        private SimpleScheduler _scheduler;
        private Logger log = Logger.GetInstance();
        //private const string AppName = "Ktuvit RSS downloader";
        private const string Username = "Username";
        private const string Password = "Password";
        private const string FeedUrl = "FeedUrl";
        private const string Interval = "Interval";
        private const string SaveDir = "SaveDir";

        // The path to the key where Windows looks for startup applications
        private RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        public frmMainForm()
        {
            InitializeComponent();
            log.Log += LogAccepted;
            LoadValuesFromAppConfig();
        }

        private void LogAccepted(object sender, CustomEventArgs e)
        {
            switch (e.Level)
            {
                case(Logger.Level.Debug):
                    RichTextBoxAppendText(e.Message, Color.Black);
                    break;
                case(Logger.Level.Error):
                    RichTextBoxAppendText(e.Message, Color.Red);
                    break;
                case(Logger.Level.Info):
                    RichTextBoxAppendText(e.Message, Color.Blue);
                    break;
                default:
                    break;
            }
        }

        private void RichTextBoxAppendText(string message, Color color)
        {         
            this.InvokeSafe(() => AppendMessage(message,color));
        }

        private void AppendMessage(string message,Color color)
        {
            int length = richTxtBox.TextLength;
            if (!string.IsNullOrEmpty(message))
            {
                int start = richTxtBox.SelectionStart;
                int len = richTxtBox.SelectionLength;
                richTxtBox.SelectionStart = length;
                richTxtBox.SelectionLength = message.Length;
                richTxtBox.SelectionColor = color;
                richTxtBox.AppendText(string.Format("{0}>{1}{2}", DateTime.Now.TimeOfDay, message,Environment.NewLine));
            }
        }

        private void LoadValuesFromAppConfig()
        {
            txtBoxUsername.Text = WebUtility.UrlDecode(AppSettingsUtil.ReadFromSettings(Username));
            txtBoxPassword.Text = WebUtility.UrlDecode(AppSettingsUtil.ReadFromSettings(Password));
            checkRssInterval.Value = decimal.Parse(AppSettingsUtil.ReadFromSettings(Interval));
            txtBoxFeedUrl.Text = AppSettingsUtil.ReadFromSettings(FeedUrl);
            txtBoxDirectoryToSave.Text = AppSettingsUtil.ReadFromSettings(SaveDir);
            CheckRegistryIfRunAtStartup();
            log.Info(this.GetType().Name, "All values were loaded from settings");
        }

        public void frmStartup()
        {
            InitializeComponent();
        }

        private void CheckRegistryIfRunAtStartup()
        {
            if (rkApp.GetValue(Properties.Resources.ApplicationName) == null)
            {
                chBoxShouldRunAtStartUp.Checked = false;
            }
            else
            {
                chBoxShouldRunAtStartUp.Checked = true;
            }
        }

        private void btnDirectoryToSave_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtBoxDirectoryToSave.Text = folderBrowserDialog.SelectedPath;
                AppSettingsUtil.WriteASetting(SaveDir, txtBoxDirectoryToSave.Text);
            }
        }

        private void chBoxShouldRunAtStartUp_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chBoxShouldRunAtStartUp.Checked)
            {
                // Add the value in the registry so that the application runs at startup
                rkApp.SetValue(Properties.Resources.ApplicationName, Application.ExecutablePath.ToString());
            }
            else
            {
                // Remove the value from the registry so that the application doesn't start
                rkApp.DeleteValue(Properties.Resources.ApplicationName, false);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                MinimizeToTray();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MinimizeToTray();
        }

        private void MinimizeToTray()
        {
            this.Hide();
            this.WindowState = FormWindowState.Minimized;
            notifyIcon.Visible = true;
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Restore();
        }

        private void Restore()
        {
            notifyIcon.Visible = false;
            this.Show();
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Restore();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //
        }

        private void menuItemStartMinimized_Click(object sender, EventArgs e)
        {
            menuItemStartMinimized.Checked = !menuItemStartMinimized.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var encodedUsername = WebUtility.UrlEncode(txtBoxUsername.Text);
            var encodedPassword = WebUtility.UrlEncode(txtBoxPassword.Text);
            AppSettingsUtil.WriteASetting(Username, encodedUsername);
            AppSettingsUtil.WriteASetting(Password, encodedPassword);
            
        }

        private void checkRssInterval_ValueChanged(object sender, EventArgs e)
        {
            AppSettingsUtil.WriteASetting(Interval, Convert.ToInt32(checkRssInterval.Value).ToString());
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            var schduler = GetScheduler();
            _scheduler.StartSchedule();
        }

        private SimpleScheduler GetScheduler()
        {
            if (_scheduler != null)
                return _scheduler;

            _scheduler = new SimpleScheduler();
            return _scheduler;

        }

        private void txtBoxFeedUrl_TextChanged(object sender, EventArgs e)
        {
            AppSettingsUtil.WriteASetting(FeedUrl, txtBoxFeedUrl.Text);
        }

        internal void ApplicationExit(object sender, EventArgs e)
        {
            var scheduler = GetScheduler();
            scheduler.StopScheuler();
        }

        
    }
}