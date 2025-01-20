using WebHooks.GitHub.Contracts;

namespace WebHooks.GitHub.ActionLogics;

internal class TagActionLogic
{
	public static Task ExecuteAsync(GithubWebhookRequest request, CancellationToken cancellationToken)
	{
		
		return Task.CompletedTask;
	}
}
