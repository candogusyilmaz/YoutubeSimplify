using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFMpegManager
{
    public class CustomDataReceivedEventHandler : EventArgs
    {
        public string Data { get; private set; }

        public CustomDataReceivedEventHandler(string data)
        {
            this.Data = data;
        }
    }
}
