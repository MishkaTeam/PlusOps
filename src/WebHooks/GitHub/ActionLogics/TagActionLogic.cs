using System.ComponentModel.DataAnnotations;
using ActionEngine;
using Microsoft.Extensions.Logging;
using SharedFramework;
using WebHooks.GitHub.Contracts;

namespace WebHooks.GitHub.ActionLogics;

internal class TagActionLogic(ILogger<TagActionLogic> logger,IActionManager actionManager,Configs configs)
{
	public Task ExecuteAsync(GithubWebhookRequest request, CancellationToken cancellationToken)
	{

		logger.LogInformation("Github webhook tag request {name} {tag} {branch}", request.Repository.Name,request.Ref,request.MasterBranch);

		if(string.IsNullOrWhiteSpace(configs.GitConfigFolder))
		{
			logger.LogError("GitConfigFolder is not provided");
            return Task.CompletedTask;
        }

		var file = Path.Join(configs.GitConfigFolder, $"{request.Repository.Name}_{request.MasterBranch}_tag.yaml");

		if(!File.Exists(file))
		{
            logger.LogError($"Github Config file ({file}) is not found");
            return Task.CompletedTask;

        }

        var fileContent = File.ReadAllText(file);
		var fileContentWithVariables = actionManager.FileEditor(fileContent,request);
		var fileStep = actionManager.ParseFile(fileContentWithVariables);
		 _ = actionManager.Execute(fileStep);
		return Task.CompletedTask;
	}
}
