using Ffmpeg.Command.Requests;
using Microsoft.Extensions.Configuration;
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
        private readonly CommandBuilder _commandBuilder;

        public WatermarkCommand(CommandBuilder commandBuilder)
        {
            _commandBuilder = commandBuilder;
        }

        public async Task<Result> Run(WatermarkRequest request)
        {
            var arguments = _commandBuilder
                .SetInput(request.ImageName)
                .SetInput(request.WatermarkImageName)
                .ApplyOverlay(request.XPos, request.YPos)
                .SetOutput(request.OutputImageName)
                .Build();

            var result = await FfmpegExecutor.RunFFmpegCommand(arguments);
            return result
                ? new Result { IsSuccess = true }
                : new Result { IsSuccess = false, ErrorMessage = "Failed to add watermark" };
        }
    }
}
