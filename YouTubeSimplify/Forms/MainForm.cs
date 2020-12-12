using FFMpegManager;
using MetadataChanger.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoLibrary;
using YouTubeSimplify.Properties;

namespace YouTubeSimplify
{
    public partial class MainForm : Form
    {
        #region Private Fields

        private IEnumerable<YouTubeVideo> videoInfos;
        private DownloadManager _manager;

        #endregion

        #region Constructor

        public MainForm()
        {
            InitializeComponent();

            _manager = new DownloadManager();
            _manager.DownloadProgressChanged += _manager_DownloadProgressChanged;
            _manager.DownloadCompleted += _manager_DownloadCompleted;

            this.Icon = Properties.Resources.mainIcon;
            ClearControls();
        }

        #endregion

        #region Form Events

        private void MainForm_Load(object sender, EventArgs e)
        {
            txtSaveFolder.Text = Settings.Default.FolderPath;

            ClipboardMonitor.Instance.ClipboardChanged += ClipboardChanged;
            //Notifier.Instance.Click += Notifier_Click;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Settings.Default.MinimizeToSystemTray)
            {
                e.Cancel = true;
                this.Visible = false;
            }
        }

        #endregion

        #region Helper Events

        private void Notifier_Click(object sender, EventArgs e)
        {
            if (this.Visible)
                return;

            this.Visible = true;

            Helpers.BringWindowToTop(this);
        }

        private void ClipboardChanged(object sender, EventArgs e)
        {
            if (!Helpers.IsClipboardTextYoutubeURL())
                return;

            txtYouTubeURL.Text = Clipboard.GetText();

            if (Settings.Default.BringWindowToTopWhenLinkCopied)
                Helpers.BringWindowToTop(this);

            if (Settings.Default.GetInformationAuto)
                btnGetVideoInfo_Click(null, new EventArgs());
        }

        #endregion

        #region Control Events

        private void btnSettings_Click(object sender, EventArgs e)
        {
            using (var form = new SettingsForm())
                form.ShowDialog();
        }

        private void btnChangeAlbum_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Multiselect = false;
                var dResult = ofd.ShowDialog();

                if (dResult == DialogResult.OK)
                    using (var form = new SearchForm(ofd.FileName, Resources.mainIcon))
                        form.ShowDialog();
            }
        }

        private async void btnGetVideoInfo_Click(object sender, EventArgs e)
        {
            pbVideoInfo.Visible = true;
            videoInfos = await txtYouTubeURL.Text.GetVideoInfo();
            pbVideoInfo.Visible = false;

            if (videoInfos != null)
            {
                PopulateVideoTypes(videoInfos.GetVideoTypes());
                this.Text = videoInfos.First().Title;
            }
            else
            {
                MessageBox.Show("Verilen URL'ye ait video bilgileri bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearControls();
                return;
            }
        }

        private void txtSaveFolder_DoubleClick(object sender, EventArgs e)
        {
            if (Directory.Exists(txtSaveFolder.Text))
                Process.Start(txtSaveFolder.Text);
        }

        private void btnFolderPath_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.ShowDialog();

                if (fbd.SelectedPath != null)
                {
                    txtSaveFolder.Text = fbd.SelectedPath;

                    Settings.Default.FolderPath = txtSaveFolder.Text;
                    Settings.Default.Save();
                }
            }
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            if (videoInfos == null) return;

            DisableControls();

            var video = videoInfos.SelectVideo(cmbType.Text, cmbResolution.Text, cmbAudioBitrate.Text);

            _manager.SetDownloadParameters(video.FullName, video.Uri, txtSaveFolder.Text);
            await _manager.StartAsync();
        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            var dResult = MessageBox.Show($"{videoInfos.FirstOrDefault().FullName} indirmesi iptal edilsin mi?", "İndirme İptal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dResult == DialogResult.Yes)
            {
                _manager.CancelAsync();
            }
        }

        private async void _manager_DownloadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            var mp3File = await ConsiderConvertingToMp3(cmbType.Text, _manager.GetDownloadedFileInfo());

            if (Settings.Default.ChangeAlbumInfoAfterDownload && mp3File != null)
                using (var form = new SearchForm(mp3File.FullName, Resources.mainIcon))
                    form.ShowDialog();

            Notify.FileConverted(_manager.GetDownloadedFileInfo().Name);

            ClearControls();
        }

        private void _manager_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            pbDownloadProgress.Value = e.ProgressPercentage;
            lblPercentage.Text = $"{e.ProgressPercentage.ToString()}%";
        }
        #endregion

        private async Task<FileInfo> ConsiderConvertingToMp3(string fileExtension, FileInfo file)
        {
            if (fileExtension != ".mp3")
                return null;

            string fileNameAsMp3 = file.FullName.Replace(".mp4", ".mp3");

            if (File.Exists(fileNameAsMp3))
            {
                var dResult = MessageBox.Show("Dönüştürülmek üzere olan dosya isminde başka bir dosya bulunuyor. Üzerine yazılsın mı?"
                                                , "Simplify", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // If answer is yes delete the file
                if (dResult == DialogResult.Yes)
                    File.Delete(fileNameAsMp3);
                else
                {
                    // Delete the downloaded .mp4 file
                    file.Delete();
                    return null;
                }
            }

            pbDownloadProgress.Style = ProgressBarStyle.Marquee;
            lblDownloading.Text = "Dönüştürülüyor:";

            var ffmpeg = new FFMpeg(Settings.Default.FFmpegPath);

            await ffmpeg.ExtractAudioAsync(file, fileNameAsMp3);

            file.Delete();

            ffmpeg.Dispose();
            return new FileInfo(fileNameAsMp3);
        }

        #region Populate ComboBoxes

        private void PopulateVideoTypes(string[] videoTypes)
        {
            cmbType.Items.Clear();

            cmbType.Items.Add(".mp3");
            cmbType.Items.AddRange(videoTypes);
            cmbType.SelectedItem = cmbType.Items[0];
            cmbType.Enabled = true;
        }

        private void PopulateResolutions(object sender, EventArgs e)
        {
            cmbResolution.Items.Clear();
            string[] videoQualities;

            if (cmbType.Text != ".mp3")
                videoQualities = videoInfos.Where(s => s.FileExtension == cmbType.Text).GetVideoResolutions();
            else
                videoQualities = new string[] { "-1" };

            cmbResolution.Items.AddRange(videoQualities);
            cmbResolution.SelectedItem = cmbResolution.Items[0];
            cmbResolution.Enabled = true;
        }

        private void PopulateAudioBitrates(object sender, EventArgs e)
        {
            cmbAudioBitrate.Items.Clear();
            string[] audioBitrates;

            if (cmbType.Text != ".mp3")
                audioBitrates = videoInfos.Where(s => s.FileExtension == cmbType.Text && s.Resolution == int.Parse(cmbResolution.Text)).GetAudioBitrates();
            else
                audioBitrates = new string[] { "128" };

            cmbAudioBitrate.Items.AddRange(audioBitrates);
            cmbAudioBitrate.SelectedItem = cmbAudioBitrate.Items[0];
            cmbAudioBitrate.Enabled = true;
        }

        #endregion

        #region Overrides

        [DebuggerStepThrough]
        protected override void WndProc(ref Message m)
        {
            // Bring active program to top when program is started more than once
            if (m.Msg == NativeMethods.WM_SHOWYOUTUBESIMPLIFY)
                Helpers.BringWindowToTop(this);

            base.WndProc(ref m);
        }

        #endregion

        #region Helpers

        private void DisableControls()
        {
            txtYouTubeURL.ReadOnly = true;

            // Enable cancel label
            lblCancel.Enabled = true;
            lblCancel.Visible = true;

            // Disable controls that can interfere with download
            btnGetVideoInfo.Enabled = false;

            cmbType.Enabled = cmbResolution.Enabled = cmbAudioBitrate.Enabled = false;

            btnFolderPath.Enabled = false;

            btnDownload.Enabled = false;
        }

        private void ClearControls()
        {
            this.Text = (string)this.Tag;

            txtYouTubeURL.ReadOnly = false;
            txtYouTubeURL.ResetText();

            btnGetVideoInfo.Enabled = true;

            cmbType.Enabled = cmbResolution.Enabled = cmbAudioBitrate.Enabled = false;

            cmbType.Items.Clear();
            cmbResolution.Items.Clear();
            cmbAudioBitrate.Items.Clear();

            btnFolderPath.Enabled = true;

            lblDownloading.Text = "İndiriliyor:";
            lblPercentage.ResetText();
            pbDownloadProgress.Value = 0;
            pbDownloadProgress.Style = ProgressBarStyle.Blocks;

            btnDownload.Enabled = true;
            lblCancel.Enabled = false;
            lblCancel.Visible = false;
        }

        #endregion
    }
}