using WebHooks.GitHub.ActionLogics;
using WebHooks.GitHub.Contracts;

namespace WebHooks.GitHub;

internal class GitHubWebhookLogic(TagActionLogic tagActionLogic) : IGitHubWebhookLogic
{
    public Task ExecuteAsync(GithubWebhookRequest request, CancellationToken cancellationToken)
    {
        switch (request.RefType)
        {
            case Constants.Tag:
            tagActionLogic.ExecuteAsync(request, cancellationToken);
            break;
            default:
            throw new NotSupportedException();
        }
        return Task.CompletedTask;
    }
}
