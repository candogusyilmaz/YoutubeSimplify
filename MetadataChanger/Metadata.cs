using MetadataChanger.Models;
using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MetadataChanger
{
    public class Metadata
    {
        /// <summary>
        /// Changes the metadata with the iTunes information
        /// </summary>
        /// <param name="filePath">Local .mp3 file path.</param>
        /// <param name="song">iTunes song information</param>
        /// <returns>If successful returns true else false.</returns>
        public static async Task<bool> Change(string filePath, ITunesSong song)
        {
            var audioFile = TagLib.File.Create(filePath);

            audioFile.RemoveTags(TagLib.TagTypes.AllTags);

            audioFile.Save();

            audioFile = TagLib.File.Create(filePath);

            //audioFile.Tag.Pictures = await GetArtwork(await GetArtworkUrl(song.ArtworkUrl100));
            audioFile.Tag.Pictures = await GetArtwork(song.ArtworkUrl100);
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

        /// <summary>
        /// Gets the artwork url from the album page
        /// </summary>
        /// <param name="url">Album url</param>
        /// <returns>Artwork/Image url</returns>
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

            var match = Regex.Match(html, "270w,(.+?) 300w,").Groups[1].Value;

            return match;
        }

        /// <summary>
        /// Downloads the given artwork and turns it into a IPicture array.
        /// </summary>
        /// <param name="artworkUrl">ITunes artwork url.</param>
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
