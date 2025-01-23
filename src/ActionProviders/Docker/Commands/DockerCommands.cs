using Commandy.Abstractions;

namespace Docker;


internal class DockerCommands : IDockerCommands
{
    private readonly ICommandProvider _commandProvider;
    public DockerCommands(ICommandProvider commandProvider)
    {
        _commandProvider = commandProvider;
    }

    public string RunContainer(string containerName, string imageName)
    {
        var command = _commandProvider.CreateCommand("docker", opt => opt
            .AddArgument("run")
            .AddArgument("-d")
            .AddArgument("--name")
            .AddArgument(containerName)
            .AddArgument(imageName)
        );
        var result = command.Execute();
        return result.Output;
    }

    public string ListContainers()
    {
        var command = _commandProvider.CreateCommand("docker", opt => opt
            .AddArgument("ps")
        );
        var result = command.Execute();
        return result.Output;
    }

    public string StopContainer(string containerName)
    {
        var command = _commandProvider.CreateCommand("docker", opt => opt
            .AddArgument("stop")
            .AddArgument(containerName)
        );
        var result = command.Execute();
        return result.Output;
    }

    public string RemoveContainer(string containerName)
    {
        var command = _commandProvider.CreateCommand("docker", opt => opt
            .AddArgument("rm")
            .AddArgument(containerName)
        );
        var result = command.Execute();
        return result.Output;
    }

    public string PullImage(string imageName)
    {
        var command = _commandProvider.CreateCommand("docker", opt => opt
            .AddArgument("pull")
            .AddArgument(imageName)
        );
        var result = command.Execute();
        return result.Output;
    }

    public string InspectLogs(string containerName)
    {
        var command = _commandProvider.CreateCommand("docker", opt => opt
            .AddArgument("logs")
            .AddArgument(containerName)
        );
        var result = command.Execute();
        return result.Output;
    }

    public string BuildImage(string imageName, string dockerfilePath)
    {
        var command = _commandProvider.CreateCommand("docker", opt => opt
            .AddArgument("build")
            .AddArgument("-t")
            .AddArgument(imageName)
            .AddArgument(".")
            .WorkingDirectory(dockerfilePath)
        );
        var result = command.Execute();
        return result.Output;
    }

    public string ExecuteCommandInContainer(string containerName, string commandToExecute)
    {
        var command = _commandProvider.CreateCommand("docker", opt => opt
            .AddArgument("exec")
            .AddArgument(containerName)
            .AddArgument(commandToExecute)
        );
        var result = command.Execute();
        return result.Output;
    }


}