using Commandy.Abstractions;

namespace Git.Commands;


internal class GitCommands : IGitCommands
{
    private readonly ICommandProvider _commandProvider;
    private string _workingDirectory;

    public GitCommands(ICommandProvider commandProvider, string workingDirectory)
    {
        _commandProvider = commandProvider;
        _workingDirectory = workingDirectory;
    }

    public ICommandResult InitializeRepository()
    {
        var command = _commandProvider.CreateCommand("git", opt => opt
            .AddArgument("init")
            .WorkingDirectory(_workingDirectory)
        );
        return command.Execute();
    }

    public ICommandResult CloneRepository(string repoUrl, string destinationPath)
    {
        var command = _commandProvider.CreateCommand("git", opt => opt
            .AddArgument("clone")
            .AddArgument(repoUrl)
            .WorkingDirectory(destinationPath)
            .Timeout(TimeSpan.FromMinutes(5))
        );
        return command.Execute();
    }

    public ICommandResult CheckStatus()
    {
        var command = _commandProvider.CreateCommand("git", opt => opt
            .AddArgument("status")
            .WorkingDirectory(_workingDirectory)
        );
        return command.Execute();
    }

    public ICommandResult AddFilesToStaging()
    {
        var command = _commandProvider.CreateCommand("git", opt => opt
            .AddArgument("add")
            .AddArgument(".")
            .WorkingDirectory(_workingDirectory)
        );
        return command.Execute();
    }

    public ICommandResult CommitChanges(string commitMessage)
    {
        var command = _commandProvider.CreateCommand("git", opt => opt
            .AddArgument("commit")
            .AddArgument("-m")
            .AddArgument($"\"{commitMessage}\"")
            .WorkingDirectory(_workingDirectory)
        );
        return command.Execute();
    }

    public ICommandResult PushChanges(string remoteName, string branchName)
    {
        var command = _commandProvider.CreateCommand("git", opt => opt
            .AddArgument("push")
            .AddArgument(remoteName)
            .AddArgument(branchName)
            .WorkingDirectory(_workingDirectory)
        );
        return command.Execute();
    }

    public ICommandResult PullChanges(string remoteName, string branchName)
    {
        var command = _commandProvider.CreateCommand("git", opt => opt
            .AddArgument("pull")
            .AddArgument(remoteName)
            .AddArgument(branchName)
            .WorkingDirectory(_workingDirectory)
        );
        return command.Execute();
    }

    public ICommandResult CreateBranch(string branchName)
    {
        var command = _commandProvider.CreateCommand("git", opt => opt
            .AddArgument("checkout")
            .AddArgument("-b")
            .AddArgument(branchName)
            .WorkingDirectory(_workingDirectory)
        );
        return command.Execute();
    }

    public ICommandResult SwitchBranch(string branchName)
    {
        var command = _commandProvider.CreateCommand("git", opt => opt
            .AddArgument("checkout")
            .AddArgument(branchName)
            .WorkingDirectory(_workingDirectory)
        );
        return command.Execute();
    }

    public ICommandResult MergeBranch(string branchName)
    {
        var command = _commandProvider.CreateCommand("git", opt => opt
            .AddArgument("merge")
            .AddArgument(branchName)
            .WorkingDirectory(_workingDirectory)
        );
        return command.Execute();
    }

    public ICommandResult ViewLog(bool concise = false)
    {
        var command = _commandProvider.CreateCommand("git", opt => opt
            .AddArgument("log")
            .AddArgument(concise ? "--oneline" : "")
            .WorkingDirectory(_workingDirectory)
        );
        return command.Execute();
    }

    public ICommandResult StashChanges()
    {
        var command = _commandProvider.CreateCommand("git", opt => opt
            .AddArgument("stash")
            .WorkingDirectory(_workingDirectory)
        );
        return command.Execute();
    }

    public ICommandResult ApplyStashedChanges()
    {
        var command = _commandProvider.CreateCommand("git", opt => opt
            .AddArgument("stash")
            .AddArgument("apply")
            .WorkingDirectory(_workingDirectory)
        );
        return command.Execute();
    }

    public ICommandResult DeleteBranch(string branchName)
    {
        var command = _commandProvider.CreateCommand("git", opt => opt
            .AddArgument("branch")
            .AddArgument("-d")
            .AddArgument(branchName)
            .WorkingDirectory(_workingDirectory)
        );
        return command.Execute();
    }

    public ICommandResult FetchRemoteChanges()
    {
        var command = _commandProvider.CreateCommand("git", opt => opt
            .AddArgument("fetch")
            .WorkingDirectory(_workingDirectory)
        );
        return command.Execute();
    }

    public ICommandResult ResetToCommit(string commitHash)
    {
        var command = _commandProvider.CreateCommand("git", opt => opt
            .AddArgument("reset")
            .AddArgument("--hard")
            .AddArgument(commitHash)
            .WorkingDirectory(_workingDirectory)
        );
        return command.Execute();
    }

    public ICommandResult RebaseBranch(string branchName)
    {
        var command = _commandProvider.CreateCommand("git", opt => opt
            .AddArgument("rebase")
            .AddArgument(branchName)
            .WorkingDirectory(_workingDirectory)
        );
        return command.Execute();
    }

    public ICommandResult ViewRemotes()
    {
        var command = _commandProvider.CreateCommand("git", opt => opt
            .AddArgument("remote")
            .AddArgument("-v")
            .WorkingDirectory(_workingDirectory)
        );
        return command.Execute();
    }

    public ICommandResult AddRemote(string remoteName, string remoteUrl)
    {
        var command = _commandProvider.CreateCommand("git", opt => opt
            .AddArgument("remote")
            .AddArgument("add")
            .AddArgument(remoteName)
            .AddArgument(remoteUrl)
            .WorkingDirectory(_workingDirectory)
        );
        return command.Execute();
    }

    public ICommandResult TagCommit(string tagName)
    {
        var command = _commandProvider.CreateCommand("git", opt => opt
            .AddArgument("tag")
            .AddArgument(tagName)
            .WorkingDirectory(_workingDirectory)
        );
        return command.Execute();
    }
}