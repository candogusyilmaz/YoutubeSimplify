namespace YouTubeSimplify
{
    partial class SettingsForm
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
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.splitterBottom = new System.Windows.Forms.Splitter();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkChangeAlbumInfoAfterDownload = new System.Windows.Forms.CheckBox();
            this.btnFFmpegPath = new System.Windows.Forms.Button();
            this.txtFFmpegPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtYouTubeDecryptionFunctionRegex = new System.Windows.Forms.TextBox();
            this.chkBringWindowToTopWhenLinkCopied = new System.Windows.Forms.CheckBox();
            this.chkGetInformationAuto = new System.Windows.Forms.CheckBox();
            this.chkMinimizeToSystemTry = new System.Windows.Forms.CheckBox();
            this.tabNotifications = new System.Windows.Forms.TabPage();
            this.chkNotifyConverted = new System.Windows.Forms.CheckBox();
            this.chkNotifyDownloaded = new System.Windows.Forms.CheckBox();
            this.chkNotifiesOn = new System.Windows.Forms.CheckBox();
            this.pnlBottom.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabNotifications.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.LightGray;
            this.pnlBottom.Controls.Add(this.splitterBottom);
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 274);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(391, 51);
            this.pnlBottom.TabIndex = 2;
            // 
            // splitterBottom
            // 
            this.splitterBottom.BackColor = System.Drawing.Color.Silver;
            this.splitterBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterBottom.Location = new System.Drawing.Point(0, 0);
            this.splitterBottom.MinExtra = 2;
            this.splitterBottom.MinSize = 5;
            this.splitterBottom.Name = "splitterBottom";
            this.splitterBottom.Size = new System.Drawing.Size(391, 2);
            this.splitterBottom.TabIndex = 1;
            this.splitterBottom.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSave.Location = new System.Drawing.Point(280, 10);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 28);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabNotifications);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(367, 255);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkChangeAlbumInfoAfterDownload);
            this.tabPage1.Controls.Add(this.btnFFmpegPath);
            this.tabPage1.Controls.Add(this.txtFFmpegPath);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtYouTubeDecryptionFunctionRegex);
            this.tabPage1.Controls.Add(this.chkBringWindowToTopWhenLinkCopied);
            this.tabPage1.Controls.Add(this.chkGetInformationAuto);
            this.tabPage1.Controls.Add(this.chkMinimizeToSystemTry);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(359, 229);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Genel";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkChangeAlbumInfoAfterDownload
            // 
            this.chkChangeAlbumInfoAfterDownload.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkChangeAlbumInfoAfterDownload.Location = new System.Drawing.Point(9, 88);
            this.chkChangeAlbumInfoAfterDownload.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.chkChangeAlbumInfoAfterDownload.Name = "chkChangeAlbumInfoAfterDownload";
            this.chkChangeAlbumInfoAfterDownload.Size = new System.Drawing.Size(341, 17);
            this.chkChangeAlbumInfoAfterDownload.TabIndex = 14;
            this.chkChangeAlbumInfoAfterDownload.Text = "iTunes üzerinden basit albüm bilgisi değiştirme penceresi açılsın";
            this.chkChangeAlbumInfoAfterDownload.UseVisualStyleBackColor = true;
            // 
            // btnFFmpegPath
            // 
            this.btnFFmpegPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFFmpegPath.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFFmpegPath.Location = new System.Drawing.Point(314, 141);
            this.btnFFmpegPath.Name = "btnFFmpegPath";
            this.btnFFmpegPath.Size = new System.Drawing.Size(36, 21);
            this.btnFFmpegPath.TabIndex = 13;
            this.btnFFmpegPath.Text = "...";
            this.btnFFmpegPath.UseVisualStyleBackColor = true;
            this.btnFFmpegPath.Click += new System.EventHandler(this.btnFFmpegPath_Click);
            // 
            // txtFFmpegPath
            // 
            this.txtFFmpegPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFFmpegPath.Location = new System.Drawing.Point(9, 141);
            this.txtFFmpegPath.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.txtFFmpegPath.Name = "txtFFmpegPath";
            this.txtFFmpegPath.ReadOnly = true;
            this.txtFFmpegPath.Size = new System.Drawing.Size(299, 21);
            this.txtFFmpegPath.TabIndex = 11;
            this.txtFFmpegPath.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 123);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.label4.Size = new System.Drawing.Size(144, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "\"FFmpeg.exe\" Dosya Yolu :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 181);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(187, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "YouTube adres de-şifre fonksiyonu :";
            this.label1.Visible = false;
            // 
            // txtYouTubeDecryptionFunctionRegex
            // 
            this.txtYouTubeDecryptionFunctionRegex.Location = new System.Drawing.Point(9, 199);
            this.txtYouTubeDecryptionFunctionRegex.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.txtYouTubeDecryptionFunctionRegex.Name = "txtYouTubeDecryptionFunctionRegex";
            this.txtYouTubeDecryptionFunctionRegex.ReadOnly = true;
            this.txtYouTubeDecryptionFunctionRegex.Size = new System.Drawing.Size(341, 21);
            this.txtYouTubeDecryptionFunctionRegex.TabIndex = 6;
            this.txtYouTubeDecryptionFunctionRegex.Text = "Currently deactivated";
            this.txtYouTubeDecryptionFunctionRegex.Visible = false;
            this.txtYouTubeDecryptionFunctionRegex.DoubleClick += new System.EventHandler(this.txtYouTubeDecryptionFunctionRegex_DoubleClick);
            this.txtYouTubeDecryptionFunctionRegex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtYouTubeDecryptionFunctionRegex_KeyPress);
            // 
            // chkBringWindowToTopWhenLinkCopied
            // 
            this.chkBringWindowToTopWhenLinkCopied.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkBringWindowToTopWhenLinkCopied.Location = new System.Drawing.Point(9, 65);
            this.chkBringWindowToTopWhenLinkCopied.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.chkBringWindowToTopWhenLinkCopied.Name = "chkBringWindowToTopWhenLinkCopied";
            this.chkBringWindowToTopWhenLinkCopied.Size = new System.Drawing.Size(341, 17);
            this.chkBringWindowToTopWhenLinkCopied.TabIndex = 5;
            this.chkBringWindowToTopWhenLinkCopied.Text = "YouTube adresi kopyalandığında programı öne çıkar";
            this.chkBringWindowToTopWhenLinkCopied.UseVisualStyleBackColor = true;
            // 
            // chkGetInformationAuto
            // 
            this.chkGetInformationAuto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkGetInformationAuto.Location = new System.Drawing.Point(9, 42);
            this.chkGetInformationAuto.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.chkGetInformationAuto.Name = "chkGetInformationAuto";
            this.chkGetInformationAuto.Size = new System.Drawing.Size(341, 17);
            this.chkGetInformationAuto.TabIndex = 4;
            this.chkGetInformationAuto.Text = "YouTube adresi kopyalandığında bilgileri otomatik al";
            this.chkGetInformationAuto.UseVisualStyleBackColor = true;
            // 
            // chkMinimizeToSystemTry
            // 
            this.chkMinimizeToSystemTry.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMinimizeToSystemTry.Location = new System.Drawing.Point(9, 19);
            this.chkMinimizeToSystemTry.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.chkMinimizeToSystemTry.Name = "chkMinimizeToSystemTry";
            this.chkMinimizeToSystemTry.Size = new System.Drawing.Size(341, 17);
            this.chkMinimizeToSystemTry.TabIndex = 3;
            this.chkMinimizeToSystemTry.Text = "Kapatırken sistem tepsisine küçült";
            this.chkMinimizeToSystemTry.UseVisualStyleBackColor = true;
            // 
            // tabNotifications
            // 
            this.tabNotifications.Controls.Add(this.chkNotifyConverted);
            this.tabNotifications.Controls.Add(this.chkNotifyDownloaded);
            this.tabNotifications.Controls.Add(this.chkNotifiesOn);
            this.tabNotifications.Location = new System.Drawing.Point(4, 22);
            this.tabNotifications.Name = "tabNotifications";
            this.tabNotifications.Padding = new System.Windows.Forms.Padding(3);
            this.tabNotifications.Size = new System.Drawing.Size(359, 229);
            this.tabNotifications.TabIndex = 1;
            this.tabNotifications.Text = "Bildirimler";
            this.tabNotifications.UseVisualStyleBackColor = true;
            // 
            // chkNotifyConverted
            // 
            this.chkNotifyConverted.AutoSize = true;
            this.chkNotifyConverted.Location = new System.Drawing.Point(15, 68);
            this.chkNotifyConverted.Margin = new System.Windows.Forms.Padding(12, 3, 3, 3);
            this.chkNotifyConverted.Name = "chkNotifyConverted";
            this.chkNotifyConverted.Size = new System.Drawing.Size(173, 17);
            this.chkNotifyConverted.TabIndex = 4;
            this.chkNotifyConverted.Text = "Video dönüştürüldüğünde bildir";
            this.chkNotifyConverted.UseVisualStyleBackColor = true;
            this.chkNotifyConverted.CheckedChanged += new System.EventHandler(this.NotificationCheckedChanged);
            // 
            // chkNotifyDownloaded
            // 
            this.chkNotifyDownloaded.AutoSize = true;
            this.chkNotifyDownloaded.Location = new System.Drawing.Point(15, 45);
            this.chkNotifyDownloaded.Margin = new System.Windows.Forms.Padding(12, 3, 3, 3);
            this.chkNotifyDownloaded.Name = "chkNotifyDownloaded";
            this.chkNotifyDownloaded.Size = new System.Drawing.Size(146, 17);
            this.chkNotifyDownloaded.TabIndex = 3;
            this.chkNotifyDownloaded.Text = "Video indirilindiğinde bildir";
            this.chkNotifyDownloaded.UseVisualStyleBackColor = true;
            this.chkNotifyDownloaded.CheckedChanged += new System.EventHandler(this.NotificationCheckedChanged);
            // 
            // chkNotifiesOn
            // 
            this.chkNotifiesOn.AutoSize = true;
            this.chkNotifiesOn.Location = new System.Drawing.Point(9, 19);
            this.chkNotifiesOn.Margin = new System.Windows.Forms.Padding(6, 3, 3, 6);
            this.chkNotifiesOn.Name = "chkNotifiesOn";
            this.chkNotifiesOn.Size = new System.Drawing.Size(92, 17);
            this.chkNotifiesOn.TabIndex = 2;
            this.chkNotifiesOn.Text = "Bildirimler Açık";
            this.chkNotifiesOn.UseVisualStyleBackColor = true;
            this.chkNotifiesOn.CheckedChanged += new System.EventHandler(this.NotificationCheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 325);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ayarlar";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.pnlBottom.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabNotifications.ResumeLayout(false);
            this.tabNotifications.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Splitter splitterBottom;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabNotifications;
        private System.Windows.Forms.CheckBox chkNotifiesOn;
        private System.Windows.Forms.CheckBox chkNotifyDownloaded;
        private System.Windows.Forms.CheckBox chkNotifyConverted;
        private System.Windows.Forms.CheckBox chkMinimizeToSystemTry;
        private System.Windows.Forms.CheckBox chkGetInformationAuto;
        private System.Windows.Forms.CheckBox chkBringWindowToTopWhenLinkCopied;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtYouTubeDecryptionFunctionRegex;
        private System.Windows.Forms.Button btnFFmpegPath;
        private System.Windows.Forms.TextBox txtFFmpegPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkChangeAlbumInfoAfterDownload;
    }
}