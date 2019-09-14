using System.IO;
using System.Threading.Tasks;

namespace FFMpegManager
{
    public class FFMpeg : FFMpegBase
    {
        private readonly string mFFMpegPath;

        public FFMpeg(string FFMpegPath)
        {
            mFFMpegPath = FFMpegPath;
        }

        /// <summary>
        /// Extracts the audio from the given video file
        /// </summary>
        /// <param name="input">Video file</param>
        /// <param name="output">Audio file name without extension</param>
        /// <returns></returns>
        public async Task ExtractAudioAsync(FileInfo input, string output)
        {
            var args = Arguments.Input(input) + Arguments.Output(output);

            await Task.Factory.StartNew(() => Run(args, output));
        }

        public void Stop()
        {
            if (this.IsWorking)
                mProcess.StandardInput.Write('q');
        }

        private void Run(string args, string output)
        {
            base.SetParameters(args, mFFMpegPath, standartOutput: true);
            
            mProcess.Start();
            mProcess.BeginOutputReadLine();
            mProcess.WaitForExit();
        }
    }
}
