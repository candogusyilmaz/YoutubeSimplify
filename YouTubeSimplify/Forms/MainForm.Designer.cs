namespace YouTubeSimplify
{
    partial class MainForm
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
            this.grpMain = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbAudioBitrate = new System.Windows.Forms.ComboBox();
            this.pnlTextBox = new System.Windows.Forms.Panel();
            this.VideoURLTextBoxPanel = new System.Windows.Forms.Panel();
            this.txtYouTubeURL = new System.Windows.Forms.TextBox();
            this.pbVideoInfo = new System.Windows.Forms.ProgressBar();
            this.btnGetVideoInfo = new System.Windows.Forms.Button();
            this.lblDownloading = new System.Windows.Forms.Label();
            this.pbDownloadProgress = new System.Windows.Forms.ProgressBar();
            this.btnFolderPath = new System.Windows.Forms.Button();
            this.txtSaveFolder = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbResolution = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblCancel = new System.Windows.Forms.Label();
            this.splitterBottom = new System.Windows.Forms.Splitter();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.btnSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.btnChangeAlbum = new System.Windows.Forms.ToolStripMenuItem();
            this.grpMain.SuspendLayout();
            this.pnlTextBox.SuspendLayout();
            this.VideoURLTextBoxPanel.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.label8);
            this.grpMain.Controls.Add(this.label7);
            this.grpMain.Controls.Add(this.label6);
            this.grpMain.Controls.Add(this.cmbAudioBitrate);
            this.grpMain.Controls.Add(this.pnlTextBox);
            this.grpMain.Controls.Add(this.btnGetVideoInfo);
            this.grpMain.Controls.Add(this.lblDownloading);
            this.grpMain.Controls.Add(this.pbDownloadProgress);
            this.grpMain.Controls.Add(this.btnFolderPath);
            this.grpMain.Controls.Add(this.txtSaveFolder);
            this.grpMain.Controls.Add(this.label4);
            this.grpMain.Controls.Add(this.label3);
            this.grpMain.Controls.Add(this.cmbResolution);
            this.grpMain.Controls.Add(this.label2);
            this.grpMain.Controls.Add(this.cmbType);
            this.grpMain.Controls.Add(this.label1);
            this.grpMain.Location = new System.Drawing.Point(14, 28);
            this.grpMain.Margin = new System.Windows.Forms.Padding(4);
            this.grpMain.Name = "grpMain";
            this.grpMain.Padding = new System.Windows.Forms.Padding(10, 8, 10, 12);
            this.grpMain.Size = new System.Drawing.Size(416, 219);
            this.grpMain.TabIndex = 0;
            this.grpMain.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(375, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "kbps";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(286, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "p";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(318, 73);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Ses :";
            // 
            // cmbAudioBitrate
            // 
            this.cmbAudioBitrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAudioBitrate.Enabled = false;
            this.cmbAudioBitrate.FormattingEnabled = true;
            this.cmbAudioBitrate.Location = new System.Drawing.Point(315, 89);
            this.cmbAudioBitrate.Name = "cmbAudioBitrate";
            this.cmbAudioBitrate.Size = new System.Drawing.Size(60, 21);
            this.cmbAudioBitrate.TabIndex = 3;
            // 
            // pnlTextBox
            // 
            this.pnlTextBox.Controls.Add(this.VideoURLTextBoxPanel);
            this.pnlTextBox.Controls.Add(this.pbVideoInfo);
            this.pnlTextBox.Location = new System.Drawing.Point(14, 44);
            this.pnlTextBox.Name = "pnlTextBox";
            this.pnlTextBox.Size = new System.Drawing.Size(314, 23);
            this.pnlTextBox.TabIndex = 16;
            // 
            // VideoURLTextBoxPanel
            // 
            this.VideoURLTextBoxPanel.BackColor = System.Drawing.SystemColors.Window;
            this.VideoURLTextBoxPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VideoURLTextBoxPanel.Controls.Add(this.txtYouTubeURL);
            this.VideoURLTextBoxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VideoURLTextBoxPanel.Location = new System.Drawing.Point(0, 0);
            this.VideoURLTextBoxPanel.Name = "VideoURLTextBoxPanel";
            this.VideoURLTextBoxPanel.Padding = new System.Windows.Forms.Padding(1, 3, 1, 0);
            this.VideoURLTextBoxPanel.Size = new System.Drawing.Size(314, 21);
            this.VideoURLTextBoxPanel.TabIndex = 19;
            // 
            // txtYouTubeURL
            // 
            this.txtYouTubeURL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtYouTubeURL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtYouTubeURL.Location = new System.Drawing.Point(1, 3);
            this.txtYouTubeURL.MaximumSize = new System.Drawing.Size(320, 20);
            this.txtYouTubeURL.Name = "txtYouTubeURL";
            this.txtYouTubeURL.Size = new System.Drawing.Size(310, 14);
            this.txtYouTubeURL.TabIndex = 0;
            this.txtYouTubeURL.Text = "https://www.youtube.com/watch?v=g1Z3Cc4fQxQ";
            // 
            // pbVideoInfo
            // 
            this.pbVideoInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbVideoInfo.Location = new System.Drawing.Point(0, 21);
            this.pbVideoInfo.MarqueeAnimationSpeed = 24;
            this.pbVideoInfo.Name = "pbVideoInfo";
            this.pbVideoInfo.Size = new System.Drawing.Size(314, 2);
            this.pbVideoInfo.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbVideoInfo.TabIndex = 18;
            this.pbVideoInfo.Visible = false;
            // 
            // btnGetVideoInfo
            // 
            this.btnGetVideoInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetVideoInfo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGetVideoInfo.Location = new System.Drawing.Point(334, 44);
            this.btnGetVideoInfo.Name = "btnGetVideoInfo";
            this.btnGetVideoInfo.Size = new System.Drawing.Size(69, 23);
            this.btnGetVideoInfo.TabIndex = 0;
            this.btnGetVideoInfo.Text = "Bilgileri Al";
            this.btnGetVideoInfo.UseVisualStyleBackColor = true;
            this.btnGetVideoInfo.Click += new System.EventHandler(this.btnGetVideoInfo_Click);
            // 
            // lblDownloading
            // 
            this.lblDownloading.AutoSize = true;
            this.lblDownloading.Location = new System.Drawing.Point(18, 164);
            this.lblDownloading.Name = "lblDownloading";
            this.lblDownloading.Size = new System.Drawing.Size(58, 13);
            this.lblDownloading.TabIndex = 12;
            this.lblDownloading.Text = "İndiriliyor :";
            // 
            // pbDownloadProgress
            // 
            this.pbDownloadProgress.Location = new System.Drawing.Point(14, 180);
            this.pbDownloadProgress.MarqueeAnimationSpeed = 20;
            this.pbDownloadProgress.Name = "pbDownloadProgress";
            this.pbDownloadProgress.Size = new System.Drawing.Size(389, 24);
            this.pbDownloadProgress.TabIndex = 11;
            // 
            // btnFolderPath
            // 
            this.btnFolderPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFolderPath.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFolderPath.Location = new System.Drawing.Point(367, 135);
            this.btnFolderPath.Name = "btnFolderPath";
            this.btnFolderPath.Size = new System.Drawing.Size(36, 21);
            this.btnFolderPath.TabIndex = 10;
            this.btnFolderPath.Text = "...";
            this.btnFolderPath.UseVisualStyleBackColor = true;
            this.btnFolderPath.Click += new System.EventHandler(this.btnFolderPath_Click);
            // 
            // txtSaveFolder
            // 
            this.txtSaveFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSaveFolder.Location = new System.Drawing.Point(14, 135);
            this.txtSaveFolder.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.txtSaveFolder.Name = "txtSaveFolder";
            this.txtSaveFolder.ReadOnly = true;
            this.txtSaveFolder.Size = new System.Drawing.Size(347, 21);
            this.txtSaveFolder.TabIndex = 8;
            this.txtSaveFolder.TabStop = false;
            this.txtSaveFolder.DoubleClick += new System.EventHandler(this.txtSaveFolder_DoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Kayıt Klasörü :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(229, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Video :";
            // 
            // cmbResolution
            // 
            this.cmbResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResolution.Enabled = false;
            this.cmbResolution.FormattingEnabled = true;
            this.cmbResolution.Location = new System.Drawing.Point(226, 89);
            this.cmbResolution.Name = "cmbResolution";
            this.cmbResolution.Size = new System.Drawing.Size(60, 21);
            this.cmbResolution.TabIndex = 2;
            this.cmbResolution.SelectedIndexChanged += new System.EventHandler(this.PopulateAudioBitrates);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tür :";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.Enabled = false;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(14, 89);
            this.cmbType.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(191, 21);
            this.cmbType.TabIndex = 1;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.PopulateResolutions);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Video URL :";
            // 
            // btnDownload
            // 
            this.btnDownload.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDownload.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnDownload.Location = new System.Drawing.Point(335, 11);
            this.btnDownload.Margin = new System.Windows.Forms.Padding(4);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(95, 28);
            this.btnDownload.TabIndex = 2;
            this.btnDownload.Text = "İndir";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.LightGray;
            this.pnlBottom.Controls.Add(this.lblCancel);
            this.pnlBottom.Controls.Add(this.splitterBottom);
            this.pnlBottom.Controls.Add(this.btnDownload);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 265);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(444, 51);
            this.pnlBottom.TabIndex = 1;
            // 
            // lblCancel
            // 
            this.lblCancel.AutoSize = true;
            this.lblCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCancel.Location = new System.Drawing.Point(299, 19);
            this.lblCancel.Name = "lblCancel";
            this.lblCancel.Size = new System.Drawing.Size(29, 13);
            this.lblCancel.TabIndex = 3;
            this.lblCancel.Text = "İptal";
            this.lblCancel.Click += new System.EventHandler(this.lblCancel_Click);
            // 
            // splitterBottom
            // 
            this.splitterBottom.BackColor = System.Drawing.Color.Silver;
            this.splitterBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterBottom.Location = new System.Drawing.Point(0, 0);
            this.splitterBottom.MinExtra = 2;
            this.splitterBottom.MinSize = 5;
            this.splitterBottom.Name = "splitterBottom";
            this.splitterBottom.Size = new System.Drawing.Size(444, 2);
            this.splitterBottom.TabIndex = 1;
            this.splitterBottom.TabStop = false;
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.BackColor = System.Drawing.Color.Transparent;
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSettings,
            this.btnChangeAlbum});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Padding = new System.Windows.Forms.Padding(8, 4, 8, 4);
            this.mainMenuStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mainMenuStrip.Size = new System.Drawing.Size(444, 27);
            this.mainMenuStrip.TabIndex = 2;
            this.mainMenuStrip.Text = "Menu";
            // 
            // btnSettings
            // 
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(56, 19);
            this.btnSettings.Text = "Ayarlar";
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnChangeAlbum
            // 
            this.btnChangeAlbum.Name = "btnChangeAlbum";
            this.btnChangeAlbum.Size = new System.Drawing.Size(98, 19);
            this.btnChangeAlbum.Text = "Albüm Değiştir";
            this.btnChangeAlbum.Click += new System.EventHandler(this.btnChangeAlbum_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(444, 316);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.grpMain);
            this.Controls.Add(this.mainMenuStrip);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mainMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "YouTube Simplify";
            this.Text = "YouTube Simplify";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.grpMain.ResumeLayout(false);
            this.grpMain.PerformLayout();
            this.pnlTextBox.ResumeLayout(false);
            this.VideoURLTextBoxPanel.ResumeLayout(false);
            this.VideoURLTextBoxPanel.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbResolution;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Button btnFolderPath;
        private System.Windows.Forms.TextBox txtSaveFolder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Splitter splitterBottom;
        private System.Windows.Forms.Label lblDownloading;
        private System.Windows.Forms.ProgressBar pbDownloadProgress;
        private System.Windows.Forms.Button btnGetVideoInfo;
        private System.Windows.Forms.Panel pnlTextBox;
        private System.Windows.Forms.Panel VideoURLTextBoxPanel;
        private System.Windows.Forms.TextBox txtYouTubeURL;
        private System.Windows.Forms.ProgressBar pbVideoInfo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbAudioBitrate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCancel;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem btnSettings;
        private System.Windows.Forms.ToolStripMenuItem btnChangeAlbum;
    }
}