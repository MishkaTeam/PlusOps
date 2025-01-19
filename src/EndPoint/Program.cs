using System.Text.Json;
using FastEndpoints;
using FastEndpoints.Swagger;
using Git;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument();
builder.Services.AddLogging();
builder.Services.AddGitActionProvider();


var app = builder.Build();
app.UseFastEndpoints();
app.UseSwaggerGen();

app.Run();