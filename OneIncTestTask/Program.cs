using Microsoft.AspNetCore.Diagnostics;
using OneIncTestTask.Facade;
using OneIncTestTask.Helpres;
using OneIncTestTask.Models;
using OneIncTestTask.Utils;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var corsOptions = builder.Configuration.GetSection("Cors").Get<CorsSettings>()!;
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(corsOptions.AllowedOrigins)
                .WithMethods(corsOptions.AllowedMethods)
                .WithHeaders(corsOptions.AllowedHeaders);
    });
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureUtilities();
builder.Services.ConfigureFacades();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(appError =>
{
    appError.Run(async context =>
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";
        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
        if (contextFeature != null)
        {
            await context.Response.WriteAsync(
                ErrorHelper.CreateError(HttpStatusCode.InternalServerError, "Internal Server Error."));
        }
    });
});

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
