using ActionEngine.Contracts;
using Shell;

namespace ActionEngine.Commands;

internal class ShellCommands(IShellCommands shellCommands)
{
    internal List<ActionResponse> Execute(KeyValuePair<object, object> item)
    {
        var res = new List<ActionResponse>();
        if (!string.Equals(item.Key.ToString(), "shell", StringComparison.InvariantCultureIgnoreCase))
        {
            return res;
        }

        if (item.Value is Dictionary<object, object> cmdSteps)
        {
            foreach (var step in cmdSteps)
            {
                var command = step.Key.ToString();
                if (string.Equals(command, "cmd", StringComparison.InvariantCultureIgnoreCase))
                {

                    var commandRes = shellCommands
                               .Execute(step.Value?.ToString());

                    res.Add(new ActionResponse("Clone", commandRes));
                }

            }
        }
        return res;

    }

}
