using Commandy.Abstractions;

namespace Docker;
public interface IDockerCommands
{
    ICommandResult BuildImage(string imageName, string dockerfilePath);
    ICommandResult ExecuteCommandInContainer(string containerName, string commandToExecute);
    ICommandResult InspectLogs(string containerName);
    ICommandResult ListContainers();
    ICommandResult PullImage(string imageName);
    ICommandResult RemoveContainer(string containerName);
    ICommandResult RunContainer(string containerName, string imageName);
    ICommandResult StopContainer(string containerName);
}