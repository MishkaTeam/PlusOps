using Git.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Git;

public static class GitServiceCollectionExtensions
{
	public static IServiceCollection AddGitActionProvider(this IServiceCollection services)
	{
		services.AddScoped<IGitCommands, GitCommands>();
		return services;
	}
}
