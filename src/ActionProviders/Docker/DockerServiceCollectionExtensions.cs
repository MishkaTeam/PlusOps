using Docker.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Docker;

public static class DockerServiceCollectionExtensions
{
	public static IServiceCollection AddDockerActionProvider(this IServiceCollection services)
	{
		services.AddScoped<IDockerCommands, DockerCommands>();
        services.AddScoped<IDockerComposeCommands, DockerComposeCommands>();

        return services;
	}

}

