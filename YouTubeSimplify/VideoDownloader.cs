using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace YouTubeSimplify
{
    public class VideoDownloader
    {
        #region Events

        public event DownloadProgressChangedEventHandler ProgressChanged;
        public event AsyncCompletedEventHandler DownloadCompleted;

        #endregion

        #region Public Properties

        public string FullName { get; private set; }
        public string FullPath { get; private set; }

        #endregion

        #region Private Members

        private WebClient webClient;

        #endregion

        public VideoDownloader(string fullNameWithExtension)
        {
            this.FullName = fullNameWithExtension.RemoveInvalidChars();
        }

        public async Task Download(string URL, string downloadDirectory)
        {
            CreateWebClient();

            this.FullPath = $"{downloadDirectory}\\{this.FullName}";

            webClient.Credentials = CredentialCache.DefaultNetworkCredentials;

            if (ProgressChanged != null)
                webClient.DownloadProgressChanged += (s, e) => { OnProgressChanged(e); };
            if (DownloadCompleted != null)
                webClient.DownloadFileCompleted += (s, e) => { OnDownloadCompleted(e); };

            CreateDirectoryIfNotExists(downloadDirectory);
            await webClient.DownloadFileTaskAsync(URL, this.FullPath);

            DisposeWebClient();
        }

        public void CancelAsync()
        {
            if (webClient != null && webClient.IsBusy)
                webClient.CancelAsync();
        }

        /// <summary>
        /// Fires when download progress changed
        /// </summary>
        protected virtual void OnProgressChanged(DownloadProgressChangedEventArgs e) => ProgressChanged?.Invoke(this, e);

        /// <summary>
        /// Fires when download completed
        /// </summary>
        protected virtual void OnDownloadCompleted(AsyncCompletedEventArgs e) => DownloadCompleted?.Invoke(this, e);

        /// <summary>
        /// Creates the webClient
        /// </summary>
        private void CreateWebClient()
        {
            if (webClient == null)
                webClient = new WebClient();
        }

        /// <summary>
        /// Disposes the webClient
        /// </summary>
        private void DisposeWebClient()
        {
            if (webClient != null)
                webClient.Dispose();
        }

        /// <summary>
        /// Creates the download directory
        /// </summary>
        private void CreateDirectoryIfNotExists(string directory)
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
        }
    }
}
