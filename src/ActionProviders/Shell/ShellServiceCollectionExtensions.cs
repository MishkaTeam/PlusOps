using Microsoft.Extensions.DependencyInjection;

namespace Shell;

public static class ShellServiceCollectionExtensions
{
	public static IServiceCollection AddShellActionProvider(this IServiceCollection services)
	{
		services.AddScoped<IShellCommands, ShellCommands>();
		return services;
	}
}
