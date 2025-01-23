
namespace ActionEngine;

public interface IActionManager
{
    List<ActionResponse> Execute(Dictionary<object, object> fileSteps);
    Dictionary<object, object> ParseFile(string file);
}