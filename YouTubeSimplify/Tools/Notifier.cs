using System.Windows.Forms;
using YouTubeSimplify.Properties;

namespace YouTubeSimplify
{
    public class Notifier
    {
        private static NotifyIcon mInstance;
        
        public static NotifyIcon Instance
        {
            get
            {
                if (mInstance == null)
                {
                    mInstance = new NotifyIcon()
                    {
                        Icon = Properties.Resources.mainIcon,
                        Visible = true
                    };
                }

                return mInstance;
            }
        }

        public static void Notify(int timeout, string text)
        {
            Instance.ShowBalloonTip(timeout, "YouTube Simplify", text, ToolTipIcon.Info);
        }

        public static void Enable() => Instance.Visible = true;

        public static void Disable() => Instance.Visible = false;
    }

    public class Notify
    {
        public static void FileDownloaded(string fileName)
        {
            if (Settings.Default.NotifyDownloaded)
                Notifier.Notify(0, $"{fileName} indirildi.");
        }

        public static void FileConverted(string fileName)
        {
            if (Settings.Default.NotifyConverted)
                Notifier.Notify(0, $"{fileName} dönüştürüldü.");
        }
    }
}
