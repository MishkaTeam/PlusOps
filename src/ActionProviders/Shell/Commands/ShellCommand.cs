using Commandy;
using Commandy.Abstractions;

namespace Shell;

internal class ShellCommands(ICommandProvider _commandProvider) : IShellCommands
{
	public ICommandResult Execute(string command)
	{
		var commandResult = _commandProvider.CreateCommand(command);

		return commandResult.Execute();
	}
}
