using System;
using System.Diagnostics;
using System.Linq;

namespace FFMpegManager
{
    public class FFMpegBase : IDisposable
    {
        public Process mProcess;

        public void SetParameters(string args, string ffmpegPath,
            bool standartInput = false,
            bool standartOutput = false,
            bool standartError = false)
        {
            if (IsWorking)
                throw new InvalidOperationException("FFMpeg is already working and can't make any other operation. Create another instance for simultaneous operations.");

            mProcess = new Process();

            mProcess.StartInfo.FileName = ffmpegPath;
            mProcess.StartInfo.Arguments = args;

            mProcess.StartInfo.CreateNoWindow = true;
            mProcess.StartInfo.UseShellExecute = false;
            mProcess.EnableRaisingEvents = true;

            mProcess.StartInfo.RedirectStandardInput = standartInput;
            mProcess.StartInfo.RedirectStandardOutput = standartOutput;
            mProcess.StartInfo.RedirectStandardError = standartError;
        }

        public bool IsWorking
        {
            get
            {
                bool hasExited;

                try { hasExited = mProcess.HasExited; }
                catch (NullReferenceException) { hasExited = true; }

                return !hasExited && Process.GetProcesses().Any(s => s.Id == mProcess.Id);
            }
        }

        public void Dispose()
        {
            mProcess?.Dispose();
        }
    }
}
