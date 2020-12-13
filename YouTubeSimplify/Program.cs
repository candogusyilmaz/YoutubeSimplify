using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace YouTubeSimplify
{
    internal static class Program
    {
        public static string Guid =
            ((GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), false).GetValue(0)).Value.ToString();

        [STAThread]
        private static void Main()
        {
            string mutexId = string.Format("Local\\{{{0}}}", Guid);

            using (var mutex = new Mutex(false, mutexId))
            {
                if (mutex.WaitOne(TimeSpan.Zero))
                    Run();
                else
                    // Send a message to the active program to show itself.
                    NativeMethods.PostMessage((IntPtr)NativeMethods.HWND_BROADCAST, NativeMethods.WM_SHOWYOUTUBESIMPLIFY, IntPtr.Zero, IntPtr.Zero);
            }
        }

        private static void Run()
        {
            // Log exception
            Application.ThreadException += (s, e) => Log(e.Exception.Message);

            // Log exception and quit
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                Log(e.ExceptionObject.ToString());
                Application.Exit();
            };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new MainForm());
        }

        public static void Log(string message)
        {
            string logFile = ".\\log.txt";

            if (!File.Exists(logFile))
            {
                File.Create(logFile).Dispose();
            }

            string error = message;
            string text = $"{DateTime.Now.ToString()} => {error} {Environment.NewLine}";
            string lines = File.ReadAllText(logFile);

            File.WriteAllText(logFile, text + lines);
        }
    }
}
