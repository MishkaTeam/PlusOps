using System.Text.Json;
using FastEndpoints;
using FastEndpoints.Swagger;
using Git;
using Docker;
using Shell;
using ActionEngine;
using Commandy.DependencyInjection;
using SharedFramework;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument();
builder.Services.AddLogging(cfg => cfg.AddConsole());
builder.Services.AddCommandy();
builder.Services.AddGitActionProvider();
builder.Services.AddDockerActionProvider();
builder.Services.AddShellActionProvider();
builder.Services.AddActionEngineProvider();
builder.Services.AddWebHooksProvider();

builder.Services.Configure<Configs>
    (builder.Configuration.GetSection(key: Configs.Key))
    .AddSingleton
    (implementationFactory: serviceType =>
    {
        var result =
            serviceType.GetRequiredService
            <Microsoft.Extensions.Options.IOptions
            <Configs>>().Value;

        return result;
    });
var app = builder.Build();
app.UseFastEndpoints();
app.UseSwaggerGen();

app.Run();