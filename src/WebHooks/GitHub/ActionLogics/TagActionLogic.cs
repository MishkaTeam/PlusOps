using WebHooks.GitHub.Contracts;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;

namespace WebHooks.GitHub.ActionLogics;

internal class TagActionLogic
{
	public static Task ExecuteAsync(GithubWebhookRequest request, CancellationToken cancellationToken)
	{

		return Task.CompletedTask;
	}
}
