using Git.Commands;

namespace ActionEngine.Commands;

internal class GitCommands(IGitCommands gitCommands)
{
	internal List<ActionResponse> GitCommand(KeyValuePair<object, object> item)
	{
		var res = new List<ActionResponse>();
		if (!string.Equals(item.Key.ToString(), "git", StringComparison.InvariantCultureIgnoreCase))
		{
			return res;
		}

		if (item.Value is Dictionary<object, object> gitSteps)
		{
			foreach (var step in gitSteps)
			{
				var command = step.Key.ToString();
				if (string.Equals(command, "clone", StringComparison.InvariantCultureIgnoreCase))
				{
					if (step.Value is Dictionary<object, object> cloneStep)
					{

						cloneStep.TryGetValue("Url", out var url);
						cloneStep.TryGetValue("Dir", out var dir);

						if(!Directory.Exists(dir.ToString()))
							Directory.CreateDirectory(dir.ToString());

						 var commandRes= gitCommands
									.CloneRepository(url?.ToString(), dir?.ToString());

						res.Add(new ActionResponse("Clone", commandRes));
					}
				}

			}
		}
		return res;

	}
}
