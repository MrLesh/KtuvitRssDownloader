namespace KtuvitRssDownloader.KtuvitRssDownloaderGui
{
    partial class frmMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainForm));
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnExecute = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxUsername = new System.Windows.Forms.TextBox();
            this.txtBoxPassword = new System.Windows.Forms.MaskedTextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblForInterval = new System.Windows.Forms.Label();
            this.btnDirectoryToSave = new System.Windows.Forms.Button();
            this.txtBoxDirectoryToSave = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFeedInfo = new System.Windows.Forms.Label();
            this.chBoxShouldRunAtStartUp = new System.Windows.Forms.CheckBox();
            this.checkRssInterval = new System.Windows.Forms.NumericUpDown();
            this.txtBoxFeedUrl = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTxtBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemStartMinimized = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayIconContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkRssInterval)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.trayIconContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabPage1);
            this.tabs.Controls.Add(this.tabPage2);
            this.tabs.Location = new System.Drawing.Point(0, 26);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(456, 298);
            this.tabs.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnExecute);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtBoxUsername);
            this.tabPage1.Controls.Add(this.txtBoxPassword);
            this.tabPage1.Controls.Add(this.btnCancel);
            this.tabPage1.Controls.Add(this.btnSave);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.lblForInterval);
            this.tabPage1.Controls.Add(this.btnDirectoryToSave);
            this.tabPage1.Controls.Add(this.txtBoxDirectoryToSave);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lblFeedInfo);
            this.tabPage1.Controls.Add(this.chBoxShouldRunAtStartUp);
            this.tabPage1.Controls.Add(this.checkRssInterval);
            this.tabPage1.Controls.Add(this.txtBoxFeedUrl);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(448, 272);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(375, 22);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(59, 39);
            this.btnExecute.TabIndex = 15;
            this.btnExecute.Text = "Execute!";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(184, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Username:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(314, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Please provide username and password to connect to Ktuvit.com";
            // 
            // txtBoxUsername
            // 
            this.txtBoxUsername.Location = new System.Drawing.Point(74, 34);
            this.txtBoxUsername.Name = "txtBoxUsername";
            this.txtBoxUsername.Size = new System.Drawing.Size(100, 20);
            this.txtBoxUsername.TabIndex = 8;
            // 
            // txtBoxPassword
            // 
            this.txtBoxPassword.Location = new System.Drawing.Point(242, 34);
            this.txtBoxPassword.Name = "txtBoxPassword";
            this.txtBoxPassword.PasswordChar = '*';
            this.txtBoxPassword.Size = new System.Drawing.Size(100, 20);
            this.txtBoxPassword.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(246, 235);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(336, 235);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "minutes";
            // 
            // lblForInterval
            // 
            this.lblForInterval.AutoSize = true;
            this.lblForInterval.Location = new System.Drawing.Point(9, 203);
            this.lblForInterval.Name = "lblForInterval";
            this.lblForInterval.Size = new System.Drawing.Size(125, 13);
            this.lblForInterval.TabIndex = 6;
            this.lblForInterval.Text = "RSS feed refresh interval";
            // 
            // btnDirectoryToSave
            // 
            this.btnDirectoryToSave.Location = new System.Drawing.Point(375, 146);
            this.btnDirectoryToSave.Name = "btnDirectoryToSave";
            this.btnDirectoryToSave.Size = new System.Drawing.Size(36, 23);
            this.btnDirectoryToSave.TabIndex = 2;
            this.btnDirectoryToSave.Text = "...";
            this.btnDirectoryToSave.UseVisualStyleBackColor = true;
            this.btnDirectoryToSave.Click += new System.EventHandler(this.btnDirectoryToSave_Click);
            // 
            // txtBoxDirectoryToSave
            // 
            this.txtBoxDirectoryToSave.Enabled = false;
            this.txtBoxDirectoryToSave.Location = new System.Drawing.Point(9, 147);
            this.txtBoxDirectoryToSave.Name = "txtBoxDirectoryToSave";
            this.txtBoxDirectoryToSave.Size = new System.Drawing.Size(360, 20);
            this.txtBoxDirectoryToSave.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Choose where to save subtitles to:";
            // 
            // lblFeedInfo
            // 
            this.lblFeedInfo.AutoSize = true;
            this.lblFeedInfo.BackColor = System.Drawing.Color.White;
            this.lblFeedInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFeedInfo.Location = new System.Drawing.Point(9, 78);
            this.lblFeedInfo.Name = "lblFeedInfo";
            this.lblFeedInfo.Size = new System.Drawing.Size(130, 13);
            this.lblFeedInfo.TabIndex = 2;
            this.lblFeedInfo.Text = "Paste you RSS feed here:";
            // 
            // chBoxShouldRunAtStartUp
            // 
            this.chBoxShouldRunAtStartUp.AutoSize = true;
            this.chBoxShouldRunAtStartUp.Location = new System.Drawing.Point(9, 236);
            this.chBoxShouldRunAtStartUp.Name = "chBoxShouldRunAtStartUp";
            this.chBoxShouldRunAtStartUp.Size = new System.Drawing.Size(200, 17);
            this.chBoxShouldRunAtStartUp.TabIndex = 4;
            this.chBoxShouldRunAtStartUp.Text = "Start donwloader on windows startup";
            this.chBoxShouldRunAtStartUp.UseVisualStyleBackColor = true;
            this.chBoxShouldRunAtStartUp.CheckedChanged += new System.EventHandler(this.chBoxShouldRunAtStartUp_CheckedChanged);
            // 
            // checkRssInterval
            // 
            this.checkRssInterval.Location = new System.Drawing.Point(140, 199);
            this.checkRssInterval.Name = "checkRssInterval";
            this.checkRssInterval.Size = new System.Drawing.Size(52, 20);
            this.checkRssInterval.TabIndex = 12;
            this.checkRssInterval.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.checkRssInterval.ValueChanged += new System.EventHandler(this.checkRssInterval_ValueChanged);
            // 
            // txtBoxFeedUrl
            // 
            this.txtBoxFeedUrl.Location = new System.Drawing.Point(9, 94);
            this.txtBoxFeedUrl.Name = "txtBoxFeedUrl";
            this.txtBoxFeedUrl.Size = new System.Drawing.Size(402, 20);
            this.txtBoxFeedUrl.TabIndex = 10;
            this.txtBoxFeedUrl.TextChanged += new System.EventHandler(this.txtBoxFeedUrl_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTxtBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(448, 272);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Logs";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTxtBox
            // 
            this.richTxtBox.Location = new System.Drawing.Point(0, 0);
            this.richTxtBox.Name = "richTxtBox";
            this.richTxtBox.ReadOnly = true;
            this.richTxtBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTxtBox.Size = new System.Drawing.Size(448, 272);
            this.richTxtBox.TabIndex = 0;
            this.richTxtBox.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(456, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemStartMinimized,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // menuItemStartMinimized
            // 
            this.menuItemStartMinimized.Name = "menuItemStartMinimized";
            this.menuItemStartMinimized.Size = new System.Drawing.Size(160, 22);
            this.menuItemStartMinimized.Text = "Start minimized ";
            this.menuItemStartMinimized.Click += new System.EventHandler(this.menuItemStartMinimized_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.trayIconContextMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = global::KtuvitRssDownloader.KtuvitRssDownloaderGui.Properties.Resources.ApplicationName;
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // trayIconContextMenu
            // 
            this.trayIconContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restoreToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem1});
            this.trayIconContextMenu.Name = "trayIconContextMenu";
            this.trayIconContextMenu.Size = new System.Drawing.Size(114, 54);
            this.trayIconContextMenu.Text = "Ktuvit RSS downloader";
            // 
            // restoreToolStripMenuItem
            // 
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            this.restoreToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.restoreToolStripMenuItem.Text = "Restore";
            this.restoreToolStripMenuItem.Click += new System.EventHandler(this.restoreToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(110, 6);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(113, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(456, 321);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ktuvit RSS downloader";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkRssInterval)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.trayIconContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnDirectoryToSave;
        private System.Windows.Forms.TextBox txtBoxDirectoryToSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFeedInfo;
        private System.Windows.Forms.CheckBox chBoxShouldRunAtStartUp;
        private System.Windows.Forms.NumericUpDown checkRssInterval;
        private System.Windows.Forms.TextBox txtBoxFeedUrl;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox richTxtBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblForInterval;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip trayIconContextMenu;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxUsername;
        private System.Windows.Forms.MaskedTextBox txtBoxPassword;
        private System.Windows.Forms.ToolStripMenuItem menuItemStartMinimized;
        private System.Windows.Forms.Button btnExecute;
    }
}

