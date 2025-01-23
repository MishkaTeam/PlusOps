using FastEndpoints;
using WebHooks.GitHub;
using WebHooks.GitHub.Contracts;

namespace EndPoint.EndPoints;

public class GitHubWebhookEndPoint(IGitHubWebhookLogic gitHubWebhookLogic) : Endpoint<GithubWebhookRequest>

{
    public override void Configure()
    {
        Post("/Webhook/GitHub");
        AllowAnonymous();
    }
    public override Task HandleAsync(GithubWebhookRequest req, CancellationToken ct)
    {
        _  = Task.Run(() =>  gitHubWebhookLogic.ExecuteAsync(req, ct));
        return Task.CompletedTask;
    }
}
