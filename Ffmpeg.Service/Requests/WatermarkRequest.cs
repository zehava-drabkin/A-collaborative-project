using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ffmpeg.Command.Requests
{
    public class WatermarkRequest
    {
        public string ImagePath { get; set; }
        public string WatermarkPath { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }
    }
}
