using HtmlAgilityPack;
using MetadataChanger.Models;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MetadataChanger
{
    public class Metadata
    {
        public static async Task<bool> Change(string filePath, ITunesSong song)
        {
            var audioFile = TagLib.File.Create(filePath);

            audioFile.RemoveTags(TagLib.TagTypes.AllTags);

            audioFile.Save();

            audioFile = TagLib.File.Create(filePath);

            audioFile.Tag.Pictures = await GetArtwork(await GetArtworkUrl(song.CollectionViewUrl));
            audioFile.Tag.Album = song.CollectionName;
            audioFile.Tag.Performers = new[] { song.ArtistName };
            audioFile.Tag.Genres = new[] { song.PrimaryGenreName };
            audioFile.Tag.Year = uint.Parse(song.ReleaseDate.ToString("yyyy"));
            audioFile.Tag.Title = song.TrackName;

            audioFile.Save();

            ChangeFilename(filePath, song.ArtistName, song.TrackName);

            return true;
        }

        private static void ChangeFilename(string filePath, string artist, string track)
        {
            // Ex: something.mp3
            string currentFilename = Path.GetFileName(filePath);

            // Ex: Eminem - Killshot.mp3
            string newFileName = $"{artist} - {track}" + Path.GetExtension(filePath);

            // Ex: C:\Something\
            string directory = Path.GetDirectoryName(filePath) + Path.DirectorySeparatorChar;

            // Ex: C:\\Something\NewFileName.mp3
            string newFilePath = $"{directory}{newFileName}";

            for (int i = 0; File.Exists(newFilePath) && newFilePath != filePath; i++)
                newFilePath = directory + $"{i} - {newFileName}";

            File.Move(filePath, newFilePath);
        }

        private static async Task<string> GetArtworkUrl(string url)
        {
            var html = string.Empty;

            using (var response = await WebRequest.CreateHttp(url).GetResponseAsync())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    html = await reader.ReadToEndAsync();
                }
            }

            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var imageURL = doc.DocumentNode.Descendants("meta")
                .FirstOrDefault(s => s.GetAttributeValue("name", null) == "twitter:image")
                .Attributes[1].Value;

            return imageURL;
        }

        private static async Task<TagLib.IPicture[]> GetArtwork(string artworkUrl)
        {
            TagLib.Id3v2.AttachedPictureFrame pic = new TagLib.Id3v2.AttachedPictureFrame
            {
                TextEncoding = TagLib.StringType.Latin1,
                MimeType = System.Net.Mime.MediaTypeNames.Image.Jpeg,
                Type = TagLib.PictureType.FrontCover
            };

            using (var client = new WebClient())
            {
                var buffer = await client.DownloadDataTaskAsync(artworkUrl);

                using (var stream = new MemoryStream(buffer))
                    pic.Data = TagLib.ByteVector.FromStream(stream);
            }

            return new TagLib.IPicture[1] { pic };
        }
    }
}
