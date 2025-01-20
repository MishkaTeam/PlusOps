using Microsoft.Extensions.DependencyInjection;

namespace Docker;

public static class DockerServiceCollectionExtensions
{
	public static IServiceCollection AddDockerActionProvider(this IServiceCollection services)
	{
		services.AddScoped<IDockerCommands, DockerCommands>();
		return services;
	}

}

