using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ffmpeg.Command
{
    public static class FfmpegExecutor
    {
        public static async Task<bool> RunFFmpegCommand(string arguments)
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
