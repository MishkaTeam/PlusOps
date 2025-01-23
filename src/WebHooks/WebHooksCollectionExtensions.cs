using Microsoft.Extensions.DependencyInjection;
using WebHooks.GitHub;
using WebHooks.GitHub.ActionLogics;

namespace ActionEngine;

public static class WebHooksCollectionExtensions
{
    public static IServiceCollection AddWebHooksProvider(this IServiceCollection services)
    {
        services.AddScoped<TagActionLogic>();
        services.AddScoped<IGitHubWebhookLogic, GitHubWebhookLogic>();
        return services;
    }
}
