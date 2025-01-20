using System.Text.Json;
using FastEndpoints;
using FastEndpoints.Swagger;
using Git;
using Docker;
using Shell;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument();
builder.Services.AddLogging();
builder.Services.AddGitActionProvider();
builder.Services.AddDockerActionProvider();
builder.Services.AddShellActionProvider();

var app = builder.Build();
app.UseFastEndpoints();
app.UseSwaggerGen();

app.Run();