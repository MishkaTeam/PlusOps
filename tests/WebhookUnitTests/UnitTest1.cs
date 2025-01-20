using Commandy;
using YamlDotNet.Serialization;

namespace WebhookUnitTests
{
	public class UnitTest1
	{
		[Fact]
		public void Test1()
		{
			var file = @"C:\temp\git_tag.yaml";
			var res = ParseFile(file);
			foreach (var item in res)
			{
				GitCommand(item);
			}

		}

		private void GitCommand(KeyValuePair<object, object> item)
		{
			if (!string.Equals(item.Key.ToString(), "git", StringComparison.InvariantCultureIgnoreCase))
			{
				return;
			}

			if (item.Value is Dictionary<object, object> gitSteps)
			{
				foreach (var step in gitSteps)
				{
					var command = step.Key.ToString();
					if (string.Equals(command, "clone", StringComparison.InvariantCultureIgnoreCase))
					{
						if (step.Value is Dictionary<object, object> cloneStep)
						{

							cloneStep.TryGetValue("Url", out var url);
							cloneStep.TryGetValue("Dir", out var dir);

							bool gitCloneResult = Clone(url?.ToString(), dir?.ToString());
						}
					}

				}
			}
		}

		private bool Clone(string? url, string? dir)
		{
			var command = CommandProvider.CreateCommand("git", opt => opt
				.AddArgument("clone")
				.AddArgument(url)
				.WorkingDirectory(dir)
				.Timeout(TimeSpan.FromMinutes(5))
			);
			var res = command.Execute();
			return res.ExitCode == 0;
		}

		private static Dictionary<object, object> ParseFile(string file)
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
}