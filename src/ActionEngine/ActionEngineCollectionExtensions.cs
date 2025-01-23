using ActionEngine.Commands;
using Docker;
using Microsoft.Extensions.DependencyInjection;

namespace ActionEngine;

public static class ActionEngineCollectionExtensions
{
    public static IServiceCollection AddActionEngineProvider(this IServiceCollection services)
    {
        services.AddScoped<GitCommands>();
        services.AddScoped<ShellCommands>();
        services.AddScoped<DockerCommands>();

        services.AddScoped<IActionManager, ActionManager>();
        return services;
    }
}
