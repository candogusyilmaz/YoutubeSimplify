using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFMpegManager
{
    internal static class Arguments
    {
        internal static string Input(FileInfo fileInfo)
        {
            return $"-i \"{ fileInfo.FullName }\" ";
        }

        internal static string Output(string fileInfo)
        {
            return $"\"{ fileInfo }\"";
        }

        internal static string Disable(ChannelTypes channelType)
        {
            switch (channelType)
            {
                case ChannelTypes.Video:
                    return "-vn ";
                case ChannelTypes.Audio:
                    return "-an ";
                default:
                    return "";
            }
        }
    }
}
