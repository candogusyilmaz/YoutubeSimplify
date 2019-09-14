using System.IO;

namespace YouTubeSimplify
{
    public static class StringExtensions
    {
        public static string RemoveInvalidChars(this string value)
        {
           foreach (char c in Path.GetInvalidFileNameChars())
                value = value.Replace(c, ' ');

            foreach (char c in Path.GetInvalidPathChars())
                value = value.Replace(c, ' ');

            return value;
        }
    }
}
