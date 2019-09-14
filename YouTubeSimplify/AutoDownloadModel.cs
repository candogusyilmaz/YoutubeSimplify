using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary;

namespace YouTubeSimplify
{
    public class AutoDownloadModel
    {
        public string URL { get; set; }
        public string Keyword { get; set; }

        public override string ToString()
        {
            return Keyword + " " + URL;
        }
    }
}
