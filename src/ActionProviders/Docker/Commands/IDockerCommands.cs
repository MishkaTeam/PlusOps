namespace Docker;
public interface IDockerCommands
{
    string BuildImage(string imageName, string dockerfilePath);
    string ExecuteCommandInContainer(string containerName, string commandToExecute);
    string InspectLogs(string containerName);
    string ListContainers();
    string PullImage(string imageName);
    string RemoveContainer(string containerName);
    string RunContainer(string containerName, string imageName);
    string StopContainer(string containerName);
}