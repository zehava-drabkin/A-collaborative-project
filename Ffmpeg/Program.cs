using Ffmpeg.Command.Commands;
using Ffmpeg.Command.Requests;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<WatermarkCommand>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty;
    });
}

app.MapPost("/add-watermark", async (WatermarkRequest request, WatermarkCommand watermarkCommand) =>
{
    var result = await watermarkCommand.AddWatermarkAsync(request);
    return result.IsSuccess ? Results.Ok(result.OutputPath) : Results.BadRequest(result.ErrorMessage);
});

app.Run();
