using Ffmpeg.Command.Requests;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ffmpeg.Command.Commands
{
    public class WatermarkCommand : ICommandRunner<WatermarkRequest>
    {
        public async Task<Result> Run(WatermarkRequest request)
        {
            var outputFilePath = Path.Combine(Path.GetDirectoryName(request.ImagePath), "output.jpg");

            var arguments = new CommandBuilder()
                .SetInput(request.ImagePath)
                .SetInput(request.WatermarkPath)
                .ApplyOverlay(request.XPos, request.YPos)
                .SetOutput(outputFilePath)
                .Build();

            var result = await FfmpegExecutor.RunFFmpegCommand(arguments);
            return result
                ? new Result { IsSuccess = true, OutputPath = outputFilePath }
                : new Result { IsSuccess = false, ErrorMessage = "Failed to add watermark" };
        }
    }
}
