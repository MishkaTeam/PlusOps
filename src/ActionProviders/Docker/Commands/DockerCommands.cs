using Commandy.Abstractions;

namespace Docker;


internal class DockerCommands : IDockerCommands
{
    private readonly ICommandProvider _commandProvider;
    public DockerCommands(ICommandProvider commandProvider)
    {
        _commandProvider = commandProvider;
    }

    public ICommandResult RunContainer(string containerName, string imageName)
    {
        var command = _commandProvider.CreateCommand("docker", opt => opt
            .AddArgument("run")
            .AddArgument("-d")
            .AddArgument("--name")
            .AddArgument(containerName)
            .AddArgument(imageName)
        );
        var result = command.Execute();
        return result;
    }

    public ICommandResult ListContainers()
    {
        var command = _commandProvider.CreateCommand("docker", opt => opt
            .AddArgument("ps")
        );
        var result = command.Execute();
        return result;
    }

    public ICommandResult StopContainer(string containerName)
    {
        var command = _commandProvider.CreateCommand("docker", opt => opt
            .AddArgument("stop")
            .AddArgument(containerName)
        );
        var result = command.Execute();
        return result;
    }

    public ICommandResult RemoveContainer(string containerName)
    {
        var command = _commandProvider.CreateCommand("docker", opt => opt
            .AddArgument("rm")
            .AddArgument(containerName)
        );
        var result = command.Execute();
        return result;
    }

    public ICommandResult PullImage(string imageName)
    {
        var command = _commandProvider.CreateCommand("docker", opt => opt
            .AddArgument("pull")
            .AddArgument(imageName)
        );
        var result = command.Execute();
        return result;
    }

    public ICommandResult InspectLogs(string containerName)
    {
        var command = _commandProvider.CreateCommand("docker", opt => opt
            .AddArgument("logs")
            .AddArgument(containerName)
        );
        var result = command.Execute();
        return result;
    }

    public ICommandResult BuildImage(string imageName, string dockerfilePath)
    {
        var command = _commandProvider.CreateCommand("docker", opt => opt
            .AddArgument("build")
            .AddArgument("-t")
            .AddArgument(imageName)
            .AddArgument(".")
            .WorkingDirectory(dockerfilePath)
        );
        var result = command.Execute();
        return result;
    }

    public ICommandResult ExecuteCommandInContainer(string containerName, string commandToExecute)
    {
        var command = _commandProvider.CreateCommand("docker", opt => opt
            .AddArgument("exec")
            .AddArgument(containerName)
            .AddArgument(commandToExecute)
        );
        var result = command.Execute();
        return result;
    }


}