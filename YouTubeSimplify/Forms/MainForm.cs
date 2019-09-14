using FFMpegManager;
using MetadataChanger;
using MetadataChanger.Forms;
using MetadataChanger.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoLibrary;
using YouTubeSimplify.Forms;
using YouTubeSimplify.Properties;

namespace YouTubeSimplify
{
    public partial class MainForm : Form
    {
        #region Private Fields

        private IEnumerable<YouTubeVideo> videoInfos;
        private WebClient _webClient;
        private string savePath;

        #endregion

        #region Constructor

        public MainForm()
        {
            InitializeComponent();

            _webClient = new WebClient();
            _webClient.UseDefaultCredentials = true;
            _webClient.DownloadProgressChanged += DownloadProgressChanged;

            this.Icon = Properties.Resources.mainIcon;
            ClearControls();
        }

        private void DownloadProgressChanged3(object sender, DownloadProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Form Events

        private void MainForm_Load(object sender, EventArgs e)
        {
            txtSaveFolder.Text = Settings.Default.FolderPath;

            ClipboardMonitor.Instance.ClipboardChanged += ClipboardChanged;
            Notifier.Instance.Click += Notifier_Click;
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
                btnGetVideoInfo_Click(this, e);
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
            var downloadedFileInfo = await DownloadVideo(video, txtSaveFolder.Text);

            if (downloadedFileInfo == null) return;

            var mp3File = await ConsiderConvertingToMp3(cmbType.Text, downloadedFileInfo);
            Notify.FileConverted(video.Title);

            ClearControls();

            if (Settings.Default.ChangeAlbumInfoAfterDownload)
                using (var form = new SearchForm(mp3File.FullName, Resources.mainIcon))
                    form.ShowDialog();
        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            if (!_webClient.IsBusy) return;

            var dResult = MessageBox.Show($"{videoInfos.FirstOrDefault().FullName} indirmesi iptal edilsin mi?", "İndirme İptal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dResult == DialogResult.Yes)
            {
                _webClient.CancelAsync();

                if (File.Exists(savePath))
                    File.Delete(savePath);

                ClearControls();
            }
        }

        #endregion

        private async Task<FileInfo> DownloadVideo(YouTubeVideo video, string path)
        {
            try
            {
                string nameWithExtension = video.FullName.RemoveInvalidChars();
                savePath = Path.Combine(path, nameWithExtension);
                await _webClient.DownloadFileTaskAsync(video.Uri, savePath);

                //Notify.FileDownloaded(video.FullName);

                return new FileInfo(savePath);
            }
            catch (WebException exception)
            {
                if (exception.Status == WebExceptionStatus.RequestCanceled)
                    return null;

                MessageBox.Show($"Video bilgileri alınırken bir hata oluştu.\n\nHata Bilgileri: {exception.Message}\nYouTube adres de-şifre fonksiyonu bozulmuş olabilir."
                    , "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.Log(exception.Message);
                return null;
            }
        }

        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            pbDownloadProgress.Value = e.ProgressPercentage;
            this.Text = $"{videoInfos.FirstOrDefault().Title} - {e.ProgressPercentage}%";
        }

        private async Task<FileInfo> ConsiderConvertingToMp3(string fileExtension, FileInfo file)
        {
            // If file extension isn't mp3 and there isn't an mp4 file return null
            if (fileExtension != ".mp3" && file != null)
                return null;

            string fileNameAsMp3 = file.FullName.Replace(".mp4", ".mp3");

            // If there is already a file called "fileNameAsMp3" then ask the user what to do
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

            // Notify user about the convert progress
            pbDownloadProgress.Style = ProgressBarStyle.Marquee;
            lblDownloading.Text = "Dönüştürülüyor:";

            var ffmpeg = new FFMpeg(Settings.Default.FFmpegPath);

            // Start converting
            await ffmpeg.ExtractAudioAsync(file, fileNameAsMp3);

            // Delete the .mp4 file
            file.Delete();

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

            btnAutoDownload.Enabled = false;
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
            pbDownloadProgress.Value = 0;
            pbDownloadProgress.Style = ProgressBarStyle.Blocks;

            btnDownload.Enabled = true;
            lblCancel.Enabled = false;
            lblCancel.Visible = false;

            btnAutoDownload.Enabled = true;
            btnAutoDownload.Text = "Otomatik İndirme";
        }

        #endregion

        private async void btnAutoDownload_Click(object sender, EventArgs e)
        {
            var downloadQueue = new Queue<AutoDownloadModel>();

            using (var form = new AutoDownloadForm())
            {
                form.ShowDialog();
                downloadQueue = form.VideoURLs;
            }

            int totalCount = downloadQueue.Count;
            
            while (downloadQueue.Count > 0)
            {
                DisableControls();

                var model = downloadQueue.Dequeue();
                btnAutoDownload.Text = $"Otomatik İndirme {totalCount - downloadQueue.Count}/{totalCount}";
                await Auto_GetVideoInfo(model);

                ClearControls();
            }
        }

        private async Task Auto_GetVideoInfo(AutoDownloadModel model)
        {
            var videoInfo = await model.URL.GetVideoInfo();
            PopulateVideoTypes(videoInfo.GetVideoTypes());
            
            txtYouTubeURL.Text = model.URL;
            this.Text = videoInfo.First().Title;

            var video = videoInfo.SelectVideo(cmbType.Text, cmbResolution.Text, cmbAudioBitrate.Text);
            this.videoInfos = videoInfo;
            var downloadedFileInfo = await DownloadVideo(video, txtSaveFolder.Text);

            if (downloadedFileInfo == null) return;

            var mp3File = await ConsiderConvertingToMp3(cmbType.Text, downloadedFileInfo);
            Notify.FileConverted(downloadedFileInfo.FullName);

            if (model.Keyword != null)
            {
                var songToFind = (await ITunesAPI.Find(model.Keyword)).FirstOrDefault();

                if (songToFind == null) return;

                await Metadata.Change(mp3File.FullName, songToFind);
            }
        }
    }
}