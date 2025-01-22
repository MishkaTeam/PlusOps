using ActionEngine.Commands;
using Commandy.Abstractions;
using YamlDotNet.Serialization;

namespace ActionEngine;

public class ActionManager
{
	public static List<ActionResponse> Execute(Dictionary<object,object> fileSteps)
    {
		foreach (var item in fileSteps)
		{
			GitCommands.GitCommand(item);
		}

		return new();
    }

	public static Dictionary<object, object> ParseFile(string file)
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
