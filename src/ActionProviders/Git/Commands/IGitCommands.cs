using Commandy.Abstractions;

namespace Git.Commands
{
    public interface IGitCommands
    {
        ICommandResult AddFilesToStaging();
        ICommandResult AddRemote(string remoteName, string remoteUrl);
        ICommandResult ApplyStashedChanges();
        ICommandResult CheckStatus();
        ICommandResult CloneRepository(string repoUrl, string destinationPath);
        ICommandResult CommitChanges(string commitMessage);
        ICommandResult CreateBranch(string branchName);
        ICommandResult DeleteBranch(string branchName);
        ICommandResult FetchRemoteChanges();
        ICommandResult InitializeRepository();
        ICommandResult MergeBranch(string branchName);
        ICommandResult PullChanges(string remoteName, string branchName);
        ICommandResult PushChanges(string remoteName, string branchName);
        ICommandResult RebaseBranch(string branchName);
        ICommandResult ResetToCommit(string commitHash);
        ICommandResult StashChanges();
        ICommandResult SwitchBranch(string branchName);
        ICommandResult TagCommit(string tagName);
        ICommandResult ViewLog(bool concise = false);
        ICommandResult ViewRemotes();
    }
}