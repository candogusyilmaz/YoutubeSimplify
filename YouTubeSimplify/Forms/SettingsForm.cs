using System;
using System.Windows.Forms;
using VideoLibrary;
using YouTubeSimplify.Properties;

namespace YouTubeSimplify
{
    public partial class SettingsForm : Form
    {

        public SettingsForm()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.mainIcon;
        }

        private void SettingsForm_Load(object sender, System.EventArgs e)
        {
            LoadSettings();
        }

        private void LoadSettings()
        {
            chkMinimizeToSystemTry.Checked = Settings.Default.MinimizeToSystemTray;
            chkGetInformationAuto.Checked = Settings.Default.GetInformationAuto;
            chkBringWindowToTopWhenLinkCopied.Checked = Settings.Default.BringWindowToTopWhenLinkCopied;
            chkChangeAlbumInfoAfterDownload.Checked = Settings.Default.ChangeAlbumInfoAfterDownload;

            txtFFmpegPath.Text = Settings.Default.FFmpegPath;
            txtYouTubeDecryptionFunctionRegex.Text = Settings.Default.DecryptionFunctionRegex;

            // To amuse myself
            chkNotifiesOn.Checked = true;
            chkNotifiesOn.Checked = (Settings.Default.NotifyDownloaded || Settings.Default.NotifyConverted);

            chkNotifyDownloaded.Checked = Settings.Default.NotifyDownloaded;
            chkNotifyConverted.Checked = Settings.Default.NotifyConverted;
        }

        private void btnFFmpegPath_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Multiselect = false;
                ofd.ShowDialog();

                if (ofd.FileName != null)
                {
                    txtFFmpegPath.Text = ofd.FileName;

                    Settings.Default.FFmpegPath = txtFFmpegPath.Text;
                    Settings.Default.Save();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Settings.Default.MinimizeToSystemTray = chkMinimizeToSystemTry.Checked;
            Settings.Default.GetInformationAuto = chkGetInformationAuto.Checked;
            Settings.Default.BringWindowToTopWhenLinkCopied = chkBringWindowToTopWhenLinkCopied.Checked;
            Settings.Default.ChangeAlbumInfoAfterDownload = chkChangeAlbumInfoAfterDownload.Checked;

            Settings.Default.FFmpegPath = txtFFmpegPath.Text;
            Settings.Default.DecryptionFunctionRegex = txtYouTubeDecryptionFunctionRegex.Text;

            Settings.Default.NotifyDownloaded = chkNotifyDownloaded.Checked;
            Settings.Default.NotifyConverted = chkNotifyConverted.Checked;

            Settings.Default.Save();

            Close();
        }

        private void NotificationCheckedChanged(object sender, EventArgs e)
        {
            if (chkNotifiesOn.Checked)
            {
                chkNotifiesOn.Text = "Bildirimler Açık";

                chkNotifyDownloaded.Enabled = true;
                chkNotifyConverted.Enabled = true;
            }
            else
            {
                chkNotifiesOn.Text = "Bildirimler Kapalı";

                chkNotifyDownloaded.Checked = false;
                chkNotifyConverted.Checked = false;

                chkNotifyDownloaded.Enabled = false;
                chkNotifyConverted.Enabled = false;
            }
        }

        #region Lock DecryptionFunctionRegex for safe-guard

        private bool doubleClicked = false;
        private void txtYouTubeDecryptionFunctionRegex_DoubleClick(object sender, EventArgs e)
        {
            doubleClicked = true;
        }

        private string password;
        private void txtYouTubeDecryptionFunctionRegex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!doubleClicked)
                return;

            if(e.KeyChar == (char)Keys.Enter)
            {
                if (password == "change")
                    txtYouTubeDecryptionFunctionRegex.ReadOnly = false;
                else
                {
                    doubleClicked = false;
                    password = null;
                }
            }
            else
            {
                password += e.KeyChar;
            }
        }

        #endregion
    }
}
