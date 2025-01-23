using Commandy.Abstractions;

namespace ActionEngine.Contracts;

public class ActionResponse
{
    public ActionResponse(string command, ICommandResult commandResult)
    {
        Command = command;
        CommandResult = commandResult;
    }

    private ActionResponse(string command)
    {
        Command = command;
    }

    public string Command { get; set; }
    public ICommandResult? CommandResult { get; set; }

    public static ActionResponse Empty()
    {
        return new ActionResponse("");
    }
}
