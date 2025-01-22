using System.ComponentModel.DataAnnotations;
using ActionEngine;
using WebHooks.GitHub.Contracts;

namespace WebHooks.GitHub.ActionLogics;

internal class TagActionLogic
{
	public static Task ExecuteAsync(GithubWebhookRequest request, CancellationToken cancellationToken)
	{
		var file = @"C:\temp\git_tag.yaml";
		var fileStep = ActionManager.ParseFile(file);
		var result = ActionManager.Execute(fileStep);
		return Task.CompletedTask;
	}
}
