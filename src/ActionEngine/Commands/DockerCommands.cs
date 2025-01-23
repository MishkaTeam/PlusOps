using ActionEngine.Contracts;
using Docker;
using Git.Commands;

namespace ActionEngine.Commands;

internal class DockerCommands(IDockerCommands dockerCommands)
{
    internal List<ActionResponse> DockerCommand(KeyValuePair<object, object> item)
    {
        var res = new List<ActionResponse>();
        if (!string.Equals(item.Key.ToString(), "docker", StringComparison.InvariantCultureIgnoreCase))
        {
            return res;
        }

        if (item.Value is Dictionary<object, object> gitSteps)
        {
            foreach (var step in gitSteps)
            {
                res.Add(Build(step));
                res.Add(Run(step));

            }
        }
        return res;

    }

    private ActionResponse Build(KeyValuePair<object, object> step)
    {
        var command = step.Key.ToString();
        if (string.Equals(command, "build", StringComparison.InvariantCultureIgnoreCase))
        {
            if (step.Value is Dictionary<object, object> cloneStep)
            {

                cloneStep.TryGetValue("Tag", out var tag);
                cloneStep.TryGetValue("Dir", out var dir);

                var commandRes = dockerCommands
                           .BuildImage(tag?.ToString(), dir?.ToString());

                return new ActionResponse("Docker Build Image", commandRes);
            }
        }
        return ActionResponse.Empty();
    }

    private ActionResponse Run(KeyValuePair<object, object> step)
    {
        var command = step.Key.ToString();
        if (string.Equals(command, "run", StringComparison.InvariantCultureIgnoreCase))
        {
            if (step.Value is Dictionary<object, object> cloneStep)
            {

                cloneStep.TryGetValue("Name", out var name);
                cloneStep.TryGetValue("Image", out var image);

                var commandRes = dockerCommands
                           .RunContainer(name?.ToString(), image?.ToString());

                return new ActionResponse("Docker Run", commandRes);
            }
        }
        return ActionResponse.Empty();
    }
}
