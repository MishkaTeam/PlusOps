using System.Text.Json;
using ActionEngine.Commands;
using ActionEngine.Contracts;
using Microsoft.Extensions.Logging;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ActionEngine;

internal class ActionManager(ILogger<ActionManager> logger,
GitCommands gitCommands,
ShellCommands shellCommands,
DockerCommands dockerCommands) : IActionManager
{
    public List<ActionResponse> Execute(Dictionary<object, object> fileSteps)
    {
        var res = new List<ActionResponse>();
        foreach (var item in fileSteps)
        {
            res = gitCommands.GitCommand(item);
            Log(res);
            res = dockerCommands.DockerCommand(item);
            Log(res);
            res = shellCommands.Execute(item);
            Log(res);

        }

        return res;
    }

    private void Log(List<ActionResponse> res)
    {
        foreach (var result in res)
        {
            logger.LogInformation("{Command} : {ExitCode}({Error}) - {Output}",
            result.Command,
            result.CommandResult?.ExitCode,
            result.CommandResult?.Error,
            result.CommandResult?.Output);
        }
    }

    public Dictionary<object, object> ParseFile(string file)
    {
        var fileContent = File.ReadAllText(file);

        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .IgnoreUnmatchedProperties()
            .Build();

        var dynamicObject = deserializer.Deserialize<dynamic>(fileContent);
        if (dynamicObject is Dictionary<object, object> dictionary)
        {   
            return dictionary;
        }
        throw new Exception("The dynamic object is not a Dictionary<object,object>.");
    }
}
