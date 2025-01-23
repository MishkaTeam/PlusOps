using System.Text.Json;
using FastEndpoints;
using FastEndpoints.Swagger;
using Git;
using Docker;
using Shell;
using ActionEngine;
using Commandy.DependencyInjection;

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

var app = builder.Build();
app.UseFastEndpoints();
app.UseSwaggerGen();

app.Run();