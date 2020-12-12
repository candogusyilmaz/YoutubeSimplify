using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace YouTubeSimplify
{
    public class DownloadManager
    {
        private string _address;
        private FileInfo _fileInfo;
        private DirectoryInfo _directory;

        private FileInfo _downloadedFileInfo = null;

        private WebClient _webClient;

        public event DownloadProgressChangedEventHandler DownloadProgressChanged;
        public event AsyncCompletedEventHandler DownloadCompleted;

        public DownloadManager()
        {

        }

        #region Public

        public void SetDownloadParameters(string fileName, string address, string fileSaveLocation)
        {
            SetDirectory(fileSaveLocation);
            SetFileInfo(fileName);

            _address = address;
        }

        public FileInfo GetDownloadedFileInfo()
        {
            return _downloadedFileInfo;
        }

        public async Task StartAsync()
        {
            _webClient = new WebClient()
            {
                UseDefaultCredentials = true
            };

            _webClient.DownloadFileCompleted += _webClient_DownloadFileCompleted;
            _webClient.DownloadProgressChanged += _webClient_DownloadProgressChanged;

            try
            {
                await _webClient.DownloadFileTaskAsync(_address, _fileInfo.FullName);
            }
            catch (WebException ex) when (ex.Status == WebExceptionStatus.RequestCanceled)
            {

            }
        }

        public void CancelAsync()
        {
            if (_webClient.IsBusy)
                _webClient.CancelAsync();
        }

        #endregion

        #region Private

        private int progress = 0;
        private void _webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // lets not do something if change isn't significant.
            if ((e.ProgressPercentage - progress) < 1)
                return;

            progress = e.ProgressPercentage;

            DownloadProgressChanged?.Invoke(null, e);
        }

        private void _webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            _fileInfo.Refresh();

            if (_fileInfo.Exists)
            {
                if (e.Cancelled)
                {
                    _fileInfo.Delete();
                    _downloadedFileInfo = null;
                }
                else
                {
                    // Are we gonna do something after completion?
                    _downloadedFileInfo = _fileInfo;
                }
            }

            DownloadCompleted?.Invoke(null, e);
            this.Dispose();
        }

        #endregion

        #region Helpers

        private void SetDirectory(string path)
        {
            _directory = new DirectoryInfo(path);

            if (!_directory.Exists)
                _directory.Create();
        }

        private void SetFileInfo(string fileName)
        {
            string fullPath = Path.Combine(_directory.FullName, fileName.RemoveInvalidChars());
            _fileInfo = new FileInfo(fullPath);

            if (_fileInfo.Exists)
                throw new IOException($"{_fileInfo.Name} named file already exists.");
        }

        private void Dispose()
        {
            progress = 0;
            _address = null;
            _fileInfo = null;
            _directory = null;
            _webClient.Dispose();
        }
        #endregion
    }
}
