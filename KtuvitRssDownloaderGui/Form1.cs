using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace KtuvitRssDownloaderGui
{
    public partial class frmMainForm : Form
    {
        private const string AppName = "Ktuvit RSS downloader";

        // The path to the key where Windows looks for startup applications
        private RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        public frmMainForm()
        {
            InitializeComponent();
            // Check to see the current state (running at startup or not)
            CheckRegistryIfRunAtStartup();
        }

        public void frmStartup()
        {
            InitializeComponent();
        }

        private void CheckRegistryIfRunAtStartup()
        {
            if (rkApp.GetValue(AppName) == null)
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
                rkApp.SetValue(AppName, Application.ExecutablePath.ToString());
            }
            else
            {
                // Remove the value from the registry so that the application doesn't start
                rkApp.DeleteValue(AppName, false);
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

    }
}