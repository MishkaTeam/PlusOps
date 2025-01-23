using System.Text.Json;
using ActionEngine.Commands;
using Commandy.Abstractions;
using Microsoft.Extensions.Logging;
using YamlDotNet.Serialization;

namespace ActionEngine;

internal class ActionManager(ILogger<ActionManager> logger, GitCommands gitCommands) : IActionManager
{
    public List<ActionResponse> Execute(Dictionary<object, object> fileSteps)
    {
        var res = new List<ActionResponse>();
        foreach (var item in fileSteps)
        {
            res = gitCommands.GitCommand(item);
            foreach (var result in res)
            {
                logger.LogInformation("{Command} : {ExitCode}({Error}) - {Output}", 
                result.Command, 
                result.CommandResult.ExitCode, 
                result.CommandResult.Error, 
                result.CommandResult.Output);
            }
        }

        return res;
    }

    public Dictionary<object, object> ParseFile(string file)
    {
        var fileContent = File.ReadAllText(file);

        var deserializer = new DeserializerBuilder()
            .Build();

        var dynamicObject = deserializer.Deserialize<dynamic>(fileContent);
        if (dynamicObject is Dictionary<object, object> dictionary)
        {
            return dictionary;
        }
        throw new Exception("The dynamic object is not a Dictionary<object,object>.");
    }
}

public class ActionResponse
{
    public ActionResponse(string command, ICommandResult commandResult)
    {
        Command = command;
        CommandResult = commandResult;
    }

    public string Command { get; set; }
    public ICommandResult CommandResult { get; set; }
}
