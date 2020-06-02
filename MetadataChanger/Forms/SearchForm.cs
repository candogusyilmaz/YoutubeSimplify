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
        }

        private void BringWindowToTop()
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;

            bool top = this.TopMost;
            this.TopMost = true;
            this.TopMost = top;
        }

        private async void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            string flagWord = txtKeyword.Text.Trim();

            // Return if; length is lower than 3 or length isn't divisible by 2
            if (flagWord.Length < 3 || flagWord.Replace(" ","").Length % 2 != 1)
                return;

            lblSongName.ResetText();

            keyword = Regex.Replace(txtKeyword.Text, @"\s+", " ");

            var list = await ITunesAPI.Find(keyword);

            if (list.Count < 1)
                return;

            song = list.First();
            lblSongName.Text = $"1. {song.ArtistName} - {song.TrackName}";
        }

        private async void btnChange_Click(object sender, EventArgs e)
        {
            DisableControls();
            await Metadata.Change(filePath, song);
            Close();
        }

        private void DisableControls()
        {
            txtKeyword.Enabled = false;
            btnChange.Enabled = false;
        }
    }
}
