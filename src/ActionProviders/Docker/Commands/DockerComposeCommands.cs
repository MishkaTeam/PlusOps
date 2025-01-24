using Commandy.Abstractions;

namespace Docker.Commands;

internal class DockerComposeCommands : IDockerComposeCommands
{
    private readonly ICommandProvider _commandProvider;

    public DockerComposeCommands(ICommandProvider commandProvider)
    {
        _commandProvider = commandProvider;
    }

    /// <summary>
    /// Build and start all services defined in the docker-compose.yml file.
    /// </summary>
    public ICommandResult Up(string workingDirectory, bool build = false, bool detach = false)
    {
        var command = _commandProvider.CreateCommand("docker", opt =>
        {
            opt.AddArgument("compose")
               .AddArgument("up");

            if (build)
            {
                opt.AddArgument("--build");
            }

            if (detach)
            {
                opt.AddArgument("-d");
            }

            opt.UseShell(false)
               .WorkingDirectory(workingDirectory);

            return opt;

        });

        var result = command.Execute(); // Synchronous execution
        return result;
    }

    /// <summary>
    /// Stop and remove all running containers, networks, and volumes.
    /// </summary>
    public ICommandResult Down(string workingDirectory, bool removeVolumes = false, bool removeImages = false)
    {
        var command = _commandProvider.CreateCommand("docker", opt =>
        {
            opt.AddArgument("compose")
               .AddArgument("down");

            if (removeVolumes)
            {
                opt.AddArgument("--volumes");
            }

            if (removeImages)
            {
                opt.AddArgument("--rmi")
                   .AddArgument("all");
            }

            opt.UseShell(false)
               .WorkingDirectory(workingDirectory);

            return opt;

        });

        var result = command.Execute(); // Synchronous execution
        return result;
    }

    /// <summary>
    /// Restart all or a specific service.
    /// </summary>
    public ICommandResult Restart(string workingDirectory, string serviceName = null)
    {
        var command = _commandProvider.CreateCommand("docker", opt =>
        {
            opt.AddArgument("compose")
               .AddArgument("restart");

            if (!string.IsNullOrEmpty(serviceName))
            {
                opt.AddArgument(serviceName);
            }

            opt.UseShell(false)
               .WorkingDirectory(workingDirectory);

            return opt;

        });

        var result = command.Execute(); // Synchronous execution
        return result;
    }

    /// <summary>
    /// View logs for all or a specific service.
    /// </summary>
    public ICommandResult Logs(string workingDirectory, string serviceName = null, bool follow = false)
    {
        var command = _commandProvider.CreateCommand("docker", opt =>
        {
            opt.AddArgument("compose")
               .AddArgument("logs");

            if (follow)
            {
                opt.AddArgument("-f");
            }

            if (!string.IsNullOrEmpty(serviceName))
            {
                opt.AddArgument(serviceName);
            }

            opt.UseShell(false)
               .WorkingDirectory(workingDirectory);

            return opt;
        });

        var result = command.Execute(); // Synchronous execution
        return result;
    }

    /// <summary>
    /// Execute a command inside a running container.
    /// </summary>
    public ICommandResult Exec(string workingDirectory, string serviceName, string commandToExecute)
    {
        var command = _commandProvider.CreateCommand("docker", opt =>
        {
            opt.AddArgument("compose")
               .AddArgument("exec")
               .AddArgument(serviceName)
               .AddArgument(commandToExecute)
               .UseShell(false)
               .WorkingDirectory(workingDirectory);

            return opt;

        });

        var result = command.Execute(); // Synchronous execution
        return result;
    }

    /// <summary>
    /// Pull the latest images for all services.
    /// </summary>
    public ICommandResult Pull(string workingDirectory)
    {
        var command = _commandProvider.CreateCommand("docker", opt =>
        {
            opt.AddArgument("compose")
               .AddArgument("pull")
               .UseShell(false)
               .WorkingDirectory(workingDirectory);

            return opt;

        });

        var result = command.Execute(); // Synchronous execution
        return result;
    }

    /// <summary>
    /// List running containers managed by Docker Compose.
    /// </summary>
    public ICommandResult Ps(string workingDirectory)
    {
        var command = _commandProvider.CreateCommand("docker", opt =>
        {
            opt.AddArgument("compose")
               .AddArgument("ps")
               .UseShell(false)
               .WorkingDirectory(workingDirectory);

            return opt;

        });

        var result = command.Execute(); // Synchronous execution
        return result;
    }

    /// <summary>
    /// Scale a specific service to multiple instances.
    /// </summary>
    public ICommandResult Scale(string workingDirectory, string serviceName, int instances)
    {
        var command = _commandProvider.CreateCommand("docker", opt =>
        {
            opt.AddArgument("compose")
               .AddArgument("up")
               .AddArgument("--scale")
               .AddArgument($"{serviceName}={instances}")
               .UseShell(false)
               .WorkingDirectory(workingDirectory);

            return opt;

        });

        var result = command.Execute(); // Synchronous execution
        return result;
    }
}
