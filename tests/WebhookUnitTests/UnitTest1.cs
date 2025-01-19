using System.Diagnostics;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace WebhookUnitTests
{
	public class UnitTest1
	{
		[Fact]
		public void Test1()
		{
			var file = @"C:\temp\git_tag.yaml";
			var fileContent = File.ReadAllText(file);

			var deserializer = new DeserializerBuilder()
				.Build();


			dynamic result = deserializer.Deserialize<dynamic>(fileContent);
		}

	}
}