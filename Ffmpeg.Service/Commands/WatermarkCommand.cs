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

            var result = await RunFFmpegCommand(arguments);
            return result
                ? new Result { IsSuccess = true, OutputPath = outputFilePath }
                : new Result { IsSuccess = false, ErrorMessage = "Failed to add watermark" };
        }

        private async Task<bool> RunFFmpegCommand(string arguments)
        {
            //צריך לעוף מפה
            var ffmpegPath = @"C:\Program Files\ffmpeg-2025-02-17-git-b92577405b-full_build\bin\ffmpeg.exe";
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = ffmpegPath,
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.Start();
            await process.WaitForExitAsync();

            return process.ExitCode == 0;
        }
    }
}
