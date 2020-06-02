using System;
using System.Net;
using System.Windows.Forms;

namespace ShareNLearn
{
    public static class Helpers
    {
        public static bool IsClipboardTextValidURL()
        {
            try
            {
                var request = (HttpWebRequest)HttpWebRequest.Create(Clipboard.GetText());
                request.Method = "HEAD";
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    var isValidURL = response.ResponseUri.ToString().Contains("drive.google.com") ? true : false;

                    if (!isValidURL)
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
