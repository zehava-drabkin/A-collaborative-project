﻿using Ffmpeg.Command.Commands;
using Ffmpeg.Command.Requests;

namespace Ffmpeg
{
    public static class Endpoints
    {
        public static void MapEndpoints(this WebApplication app)
        {
            app.MapPost("/add-watermark", async (WatermarkRequest request, WatermarkCommand watermarkCommand) =>
            {
                var result = await watermarkCommand.AddWatermarkAsync(request);
                return result.IsSuccess ? Results.Ok(result.OutputPath) : Results.BadRequest(result.ErrorMessage);
            });
        }
    }
}
