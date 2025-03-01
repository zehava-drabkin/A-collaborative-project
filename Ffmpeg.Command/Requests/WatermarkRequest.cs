using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ffmpeg.Command.Requests
{
    public class WatermarkRequest
    {
        public string ImageName { get; set; }
        public string WatermarkImageName { get; set; }
        public string OutputImageName { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }
    }
}
