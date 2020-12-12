using MetadataChanger.Models;
using MetadataChanger.Services;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MetadataChanger.Forms
{
    public partial class SearchForm : Form
    {
        private string keyword;
        private string filePath;
        private ITunesSong song;

        public SearchForm(string filePath, Icon icon)
        {
            InitializeComponent();

            this.Text = new FileInfo(filePath).Name;
            this.filePath = filePath;

            if (icon != null)
                this.Icon = icon;
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            BringWindowToTop();
            txtKeyword.Focus();
            searchTimer.Enabled = true;
        }

        private void BringWindowToTop()
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;

            bool top = this.TopMost;
            this.TopMost = true;
            this.TopMost = top;
        }

        private async void btnChange_Click(object sender, EventArgs e)
        {
            btnChange.Enabled = false;

            try
            {
                await Metadata.Change(filePath, song);
                Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnChange.Enabled = true;
            }
        }

        private async void searchTimer_Tick(object sender, EventArgs e)
        {
            string flagWord = txtKeyword.Text.Trim();

            if (flagWord.Replace(" ", "").Length < 3 || flagWord.Replace(" ","") == keyword.Replace(" ",""))
                return;

            keyword = Regex.Replace(txtKeyword.Text, @"\s+", " ");

            song = (await ITunesAPI.Find(keyword)).FirstOrDefault();

            if (song == null)
            {
                lblSongName.ResetText();
                btnChange.Enabled = false;
            }
            else
            {
                lblSongName.Text = $"1. {song.ArtistName} - {song.TrackName}";
                btnChange.Enabled = true;
            }
        }
    }
}
