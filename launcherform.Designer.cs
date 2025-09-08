namespace LEHuDModLauncher
{
    partial class launcherform
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
            groupBox1 = new GroupBox();
            buttonGetSteamFolder = new Button();
            buttonGetGameFolder = new Button();
            buttonBrowseSteamFolder = new Button();
            textSteamPath = new TextBox();
            panel1 = new Panel();
            textGameVersion = new TextBox();
            buttonOffline = new Button();
            label3 = new Label();
            buttonOnline = new Button();
            buttonBrowseGameFolder = new Button();
            textGamePath = new TextBox();
            statusStrip = new StatusStrip();
            toolStripProgress = new ToolStripProgressBar();
            statusStripLabel = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            installToolStripMenuItem = new ToolStripMenuItem();
            changelogToolStripMenuItem = new ToolStripMenuItem();
            checkForNewVersionToolStripMenuItem = new ToolStripMenuItem();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            statusStrip.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonGetSteamFolder);
            groupBox1.Controls.Add(buttonGetGameFolder);
            groupBox1.Controls.Add(buttonBrowseSteamFolder);
            groupBox1.Controls.Add(textSteamPath);
            groupBox1.Controls.Add(panel1);
            groupBox1.Controls.Add(buttonBrowseGameFolder);
            groupBox1.Controls.Add(textGamePath);
            groupBox1.Location = new Point(12, 46);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(793, 361);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // buttonGetSteamFolder
            // 
            buttonGetSteamFolder.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonGetSteamFolder.Location = new Point(12, 273);
            buttonGetSteamFolder.Name = "buttonGetSteamFolder";
            buttonGetSteamFolder.Size = new Size(176, 31);
            buttonGetSteamFolder.TabIndex = 12;
            buttonGetSteamFolder.Text = "Get Steam folder";
            buttonGetSteamFolder.UseVisualStyleBackColor = true;
            buttonGetSteamFolder.Click += buttonGetSteamFolder_Click;
            // 
            // buttonGetGameFolder
            // 
            buttonGetGameFolder.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonGetGameFolder.Location = new Point(12, 183);
            buttonGetGameFolder.Name = "buttonGetGameFolder";
            buttonGetGameFolder.Size = new Size(176, 31);
            buttonGetGameFolder.TabIndex = 11;
            buttonGetGameFolder.Text = "Get GameFolder";
            buttonGetGameFolder.UseVisualStyleBackColor = true;
            buttonGetGameFolder.Click += buttonGetGameFolder_Click;
            // 
            // buttonBrowseSteamFolder
            // 
            buttonBrowseSteamFolder.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonBrowseSteamFolder.Location = new Point(686, 310);
            buttonBrowseSteamFolder.Name = "buttonBrowseSteamFolder";
            buttonBrowseSteamFolder.Size = new Size(53, 31);
            buttonBrowseSteamFolder.TabIndex = 8;
            buttonBrowseSteamFolder.Text = "...";
            buttonBrowseSteamFolder.UseVisualStyleBackColor = true;
            buttonBrowseSteamFolder.Click += buttonBrowseSteamFolder_Click;
            // 
            // textSteamPath
            // 
            textSteamPath.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textSteamPath.Location = new Point(12, 310);
            textSteamPath.Name = "textSteamPath";
            textSteamPath.Size = new Size(668, 31);
            textSteamPath.TabIndex = 7;
            // 
            // panel1
            // 
            panel1.Controls.Add(textGameVersion);
            panel1.Controls.Add(buttonOffline);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(buttonOnline);
            panel1.Location = new Point(12, 30);
            panel1.Name = "panel1";
            panel1.Size = new Size(765, 88);
            panel1.TabIndex = 6;
            // 
            // textGameVersion
            // 
            textGameVersion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textGameVersion.CausesValidation = false;
            textGameVersion.Location = new Point(274, 46);
            textGameVersion.Name = "textGameVersion";
            textGameVersion.ReadOnly = true;
            textGameVersion.ShortcutsEnabled = false;
            textGameVersion.Size = new Size(219, 31);
            textGameVersion.TabIndex = 11;
            textGameVersion.TextAlign = HorizontalAlignment.Center;
            // 
            // buttonOffline
            // 
            buttonOffline.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            buttonOffline.Location = new Point(515, 10);
            buttonOffline.Name = "buttonOffline";
            buttonOffline.Size = new Size(221, 67);
            buttonOffline.TabIndex = 1;
            buttonOffline.Text = "OFFLINE (mod)";
            buttonOffline.UseVisualStyleBackColor = true;
            buttonOffline.Click += buttonOffline_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(274, 10);
            label3.Name = "label3";
            label3.Size = new Size(199, 25);
            label3.TabIndex = 10;
            label3.Text = "Game Version detected:";
            // 
            // buttonOnline
            // 
            buttonOnline.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            buttonOnline.Location = new Point(9, 10);
            buttonOnline.Name = "buttonOnline";
            buttonOnline.Size = new Size(241, 67);
            buttonOnline.TabIndex = 0;
            buttonOnline.Text = "ONLINE (no mods)";
            buttonOnline.UseVisualStyleBackColor = true;
            buttonOnline.Click += buttonOnline_Click;
            // 
            // buttonBrowseGameFolder
            // 
            buttonBrowseGameFolder.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonBrowseGameFolder.Location = new Point(686, 220);
            buttonBrowseGameFolder.Name = "buttonBrowseGameFolder";
            buttonBrowseGameFolder.Size = new Size(53, 31);
            buttonBrowseGameFolder.TabIndex = 3;
            buttonBrowseGameFolder.Text = "...";
            buttonBrowseGameFolder.UseVisualStyleBackColor = true;
            buttonBrowseGameFolder.Click += buttonBrowse_Click;
            // 
            // textGamePath
            // 
            textGamePath.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textGamePath.Location = new Point(12, 220);
            textGamePath.Name = "textGamePath";
            textGamePath.Size = new Size(668, 31);
            textGamePath.TabIndex = 1;
            textGamePath.TextChanged += textPath_TextChanged;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(24, 24);
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripProgress, statusStripLabel });
            statusStrip.Location = new Point(0, 429);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(842, 35);
            statusStrip.TabIndex = 4;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripProgress
            // 
            toolStripProgress.Name = "toolStripProgress";
            toolStripProgress.Size = new Size(100, 27);
            // 
            // statusStripLabel
            // 
            statusStripLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            statusStripLabel.Name = "statusStripLabel";
            statusStripLabel.Size = new Size(184, 28);
            statusStripLabel.Text = "dsafasdgsdagsadg";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { installToolStripMenuItem, changelogToolStripMenuItem, checkForNewVersionToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(842, 36);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // installToolStripMenuItem
            // 
            installToolStripMenuItem.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            installToolStripMenuItem.Name = "installToolStripMenuItem";
            installToolStripMenuItem.Size = new Size(86, 32);
            installToolStripMenuItem.Text = "Install";
            installToolStripMenuItem.Click += installToolStripMenuItem_Click;
            // 
            // changelogToolStripMenuItem
            // 
            changelogToolStripMenuItem.Enabled = false;
            changelogToolStripMenuItem.Name = "changelogToolStripMenuItem";
            changelogToolStripMenuItem.Size = new Size(114, 32);
            changelogToolStripMenuItem.Text = "Changelog";
            // 
            // checkForNewVersionToolStripMenuItem
            // 
            checkForNewVersionToolStripMenuItem.Enabled = false;
            checkForNewVersionToolStripMenuItem.Name = "checkForNewVersionToolStripMenuItem";
            checkForNewVersionToolStripMenuItem.Size = new Size(202, 32);
            checkForNewVersionToolStripMenuItem.Text = "Check for new version";
            // 
            // launcherform
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(842, 464);
            Controls.Add(groupBox1);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MinimumSize = new Size(844, 520);
            Name = "launcherform";
            Opacity = 0.95D;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "launcherform";
            FormClosing += launcherform_FormClosing;
            Load += launcherform_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox textGamePath;
        private Button buttonBrowseGameFolder;
        public ToolStripStatusLabel statusStripLabel;
        public StatusStrip statusStrip;
        public ToolStripProgressBar toolStripProgress;
        private Panel panel1;
        private Button buttonOffline;
        private Button buttonOnline;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem installToolStripMenuItem;
        private ToolStripMenuItem changelogToolStripMenuItem;
        private ToolStripMenuItem checkForNewVersionToolStripMenuItem;
        private Button buttonBrowseSteamFolder;
        private TextBox textSteamPath;
        private TextBox textGameVersion;
        private Label label3;
        private Button buttonGetGameFolder;
        private Button buttonGetSteamFolder;
    }
}