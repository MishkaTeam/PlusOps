using WebHooks.GitHub.ActionLogics;
using WebHooks.GitHub.Contracts;

namespace WebHooks.GitHub;

public class GitHubWebhookLogic
{
	public Task ExecuteAsync(GithubWebhookRequest request, CancellationToken cancellationToken)
	{
		switch (request.RefType)
		{
			case Constants.Tag:
			TagActionLogic.ExecuteAsync(request, cancellationToken);
			break;
			default:
			throw new NotSupportedException();
		}
		return Task.CompletedTask;
	}
}
