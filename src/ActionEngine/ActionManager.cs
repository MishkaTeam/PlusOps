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
            if(res.Any(x => x.CommandResult?.ExitCode != 0))
                return res;

            res = dockerCommands.DockerCommand(item);
            Log(res);
            if (res.Any(x => x.CommandResult?.ExitCode != 0))
                return res;

            res = dockerCommands.DockerComposeCommand(item);
            Log(res);
            if (res.Any(x => x.CommandResult?.ExitCode != 0))
                return res;

            res = shellCommands.Execute(item);
            Log(res);
            if (res.Any(x => x.CommandResult?.ExitCode != 0))
                return res;
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

    public Dictionary<object, object> ParseFile(string fileContent)
    {
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

    public string FileEditor(string configFileContent, object content)
    {
        if (content is null)
        {
            return configFileContent;
        }

        var properties = content.GetType().GetProperties();
        foreach (var property in properties)
        {
            var propertyName = property.Name;
            var propertyValue = property.GetValue(content);
            if (property.PropertyType == typeof(string)
            || property.PropertyType == typeof(int)
            || property.PropertyType == typeof(DateTime))
            {
                configFileContent = configFileContent
                            .Replace($"$[{propertyName}]", propertyValue?.ToString() ?? "''",
                            StringComparison.InvariantCultureIgnoreCase);
            }
            else if (property.PropertyType == typeof(object))
            {
                logger.LogError("[FileEditor] object type is not valid:  property => {property}", propertyName);
            }
            else
            {
                configFileContent = FileEditor(configFileContent, propertyValue);
            }


        }

        return configFileContent;

    }
}
