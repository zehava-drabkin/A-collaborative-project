using Ffmpeg.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ffmpeg.Core.Service
{
    public interface IWatermarkService
    {
        Task<Result> AddWatermarkAsync(WatermarkRequest request);
    }
}
