using Microsoft.Win32;
using System;
using System.Net;
using System.Windows.Forms;
using System.Configuration;
using System.Resources;

namespace KtuvitRssDownloaderGui
{
    public partial class frmMainForm : Form
    {
        //private const string AppName = "Ktuvit RSS downloader";
        private const string Username = "Username";
        private const string Password = "Password";

        // The path to the key where Windows looks for startup applications
        private RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        public frmMainForm()
        {
            InitializeComponent();
            LoadValuesFromAppConfig();
        }

        private void LoadValuesFromAppConfig()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            txtBoxUsername.Text = WebUtility.UrlDecode(ConfigurationManager.AppSettings[Username]);
            txtBoxPassword.Text = WebUtility.UrlDecode(ConfigurationManager.AppSettings[Password]);
            CheckRegistryIfRunAtStartup();
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
            //launch thread to start downloading
        }

        private void menuItemStartMinimized_Click(object sender, EventArgs e)
        {
            menuItemStartMinimized.Checked = !menuItemStartMinimized.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var encodedUsername = WebUtility.UrlEncode(txtBoxUsername.Text);
            var encodedPassword = WebUtility.UrlEncode(txtBoxPassword.Text);
            var config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings.Remove("UserName");
            config.AppSettings.Settings.Add("UserName", encodedUsername);
            config.AppSettings.Settings.Remove("Password");
            config.AppSettings.Settings.Add("Password", encodedPassword);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

    }
}