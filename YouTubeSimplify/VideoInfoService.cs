using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoLibrary;

namespace YouTubeSimplify
{
    public static class VideoInfoService
    {
        public static async Task<IEnumerable<YouTubeVideo>> GetVideoInfo(this string URL)
        {
            try
            {
                using (var client = Client.For(YouTube.Default))
                {
                    var videos = await client.GetAllVideosAsync(URL);

                    if (videos.FirstOrDefault() != null)
                        return videos;
                    else
                        return null;
                }
            }
            catch { return null; }
        }

        public static string[] GetVideoTypes(this IEnumerable<YouTubeVideo> videoInfo)
            => videoInfo.Where(s => s.FileExtension.Length > 0)
                .Select(s => s.FileExtension)
                .Distinct()
                .ToArray();

        public static string[] GetVideoResolutions(this IEnumerable<YouTubeVideo> videoInfo)
            => videoInfo.Where(s => s.Title != null)
                .Select(s => s.Resolution.ToString())
                .Distinct()
                .OrderByDescending(s => s)
                .ToArray();

        public static string[] GetAudioBitrates(this IEnumerable<YouTubeVideo> videoInfo)
            => videoInfo.Where(s => s.Title != null)
                .Select(s => s.AudioBitrate.ToString())
                .Distinct()
                .OrderByDescending(s => s)
                .ToArray();

        public static YouTubeVideo SelectVideo(this IEnumerable<YouTubeVideo> collection, string type, string resolution, string bitrate)
        {
            // If type is .mp3 then get the .mp4 video with Resolution: -1, Bitrate: 128
            if (type == ".mp3")
                return collection.FirstOrDefault(s => s.FileExtension.Equals(".mp4")
                                                                && s.Resolution == -1
                                                                && s.AudioBitrate == 128);
            else
                return collection.FirstOrDefault(s => s.FileExtension.Equals(type)
                                                                && s.Resolution == int.Parse(resolution)
                                                                && s.AudioBitrate == int.Parse(bitrate));
        }
    }
}
