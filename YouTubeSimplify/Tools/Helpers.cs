using System;
using System.Net;
using System.Windows.Forms;

namespace YouTubeSimplify
{
    public static class Helpers
    {
        public static bool IsClipboardTextYoutubeURL()
        {
            try
            {
                var request = (HttpWebRequest)HttpWebRequest.Create(Clipboard.GetText());
                request.Method = "HEAD";
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    var isYoutubeURL = response.ResponseUri.ToString().Contains("youtube.com") ? true : false;

                    if (!isYoutubeURL)
                        return false;

                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public static void BringWindowToTop(Form form)
        {
            if (form.WindowState == FormWindowState.Minimized)
                form.WindowState = FormWindowState.Normal;

            bool top = form.TopMost;
            form.TopMost = true;
            form.TopMost = top;
        }
    }
}
