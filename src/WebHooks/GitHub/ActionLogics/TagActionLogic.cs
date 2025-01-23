using System.ComponentModel.DataAnnotations;
using ActionEngine;
using WebHooks.GitHub.Contracts;

namespace WebHooks.GitHub.ActionLogics;

internal class TagActionLogic(IActionManager actionManager)
{
	public Task ExecuteAsync(GithubWebhookRequest request, CancellationToken cancellationToken)
	{
		var file = @"C:\temp\git_tag.yaml";
		var fileStep = actionManager.ParseFile(file);
		 _ = actionManager.Execute(fileStep);
		return Task.CompletedTask;
	}
}
