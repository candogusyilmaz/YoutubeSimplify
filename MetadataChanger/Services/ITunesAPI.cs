using MetadataChanger.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MetadataChanger.Services
{
    public static class ITunesAPI
    {
        /// <summary>
        /// Find songs by keyword
        /// </summary>
        /// <param name="keyword"> Keyword</param>
        public static async Task<List<ITunesSong>> Find(string keyword)
        {
            var jsonContent = string.Empty;
            var songResult = new ITunesSongResult();

            try
            {
                using (var wc = new WebClient() { Encoding = Encoding.UTF8 })
                    jsonContent = await wc.DownloadStringTaskAsync($"https://itunes.apple.com/search?term={ keyword }&entity=song");

                songResult = JsonConvert.DeserializeObject<ITunesSongResult>(jsonContent);
            }
            catch (Exception)
            {
                return null;
            }

            return songResult.Songs;
        }
    }
}
