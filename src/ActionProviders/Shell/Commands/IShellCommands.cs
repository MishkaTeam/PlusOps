using Commandy.Abstractions;

namespace Shell;

public interface IShellCommands
{
	ICommandResult Execute(string command);
}