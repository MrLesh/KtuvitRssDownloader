using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KtuvitRssDownloaderGui
{
    public partial class Form1 : Form
    {
        private const string AppName = "Ktuvit RSS downloader";
        // The path to the key where Windows looks for startup applications
        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        public Form1()
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
                // The value doesn't exist, the application is not set to run at startup
                chBoxShouldRunAtStartUp.Checked = false;
            }
            else
            {
                // The value exists, the application is set to run at startup
                chBoxShouldRunAtStartUp.Checked = true;
            }
        }
        

        private void btnDirectoryToSave_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtBoxDirectoryToSave.Text = folderBrowserDialog1.SelectedPath;
               
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
            //else if (this.WindowState == FormWindowState.Normal)
            //{
            //    Restore();
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MinimizeToTray();
        }

        private void MinimizeToTray()
        {
            this.Hide();
            this.WindowState = FormWindowState.Minimized;
            notifyIcon1.Visible = true;
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Restore();
        }

        private void Restore()
        {
            notifyIcon1.Visible = false;
            this.Show();
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;

            // Activate the form. 

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

    }
}
