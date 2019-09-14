using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace YouTubeSimplify.Forms
{
    public partial class AutoDownloadForm : Form
    {
        public Queue<AutoDownloadModel> VideoURLs { get; set; } = new Queue<AutoDownloadModel>();

        public AutoDownloadForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var model = new AutoDownloadModel() { URL = txtVideoURL.Text, Keyword = txtKeyword.Text };
            VideoURLs.Enqueue(model);
            lstVideoURLs.Items.Add(model);
            Clear();
        }

        private void Clear()
        {
            txtVideoURL.Text = txtKeyword.Text = string.Empty;
            txtVideoURL.Focus();
        }
    }
}
