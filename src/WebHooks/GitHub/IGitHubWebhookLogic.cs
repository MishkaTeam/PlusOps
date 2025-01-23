using WebHooks.GitHub.Contracts;

namespace WebHooks.GitHub
{
    public interface IGitHubWebhookLogic
    {
        Task ExecuteAsync(GithubWebhookRequest request, CancellationToken cancellationToken);
    }
}