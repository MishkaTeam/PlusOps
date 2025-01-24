
using ActionEngine.Contracts;

namespace ActionEngine;

public interface IActionManager
{
    List<ActionResponse> Execute(Dictionary<object, object> fileSteps);
    string FileEditor(string configFileContent, object content);
    Dictionary<object, object> ParseFile(string fileContent);
}