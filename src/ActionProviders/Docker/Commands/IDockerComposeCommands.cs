using Commandy.Abstractions;

namespace Docker.Commands;

public interface IDockerComposeCommands
{
    ICommandResult Down(string workingDirectory, bool removeVolumes = false, bool removeImages = false);
    ICommandResult Exec(string workingDirectory, string serviceName, string commandToExecute);
    ICommandResult Logs(string workingDirectory, string serviceName = null, bool follow = false);
    ICommandResult Ps(string workingDirectory);
    ICommandResult Pull(string workingDirectory);
    ICommandResult Restart(string workingDirectory, string serviceName = null);
    ICommandResult Scale(string workingDirectory, string serviceName, int instances);
    ICommandResult Up(string workingDirectory, bool build = false, bool detach = false);
}