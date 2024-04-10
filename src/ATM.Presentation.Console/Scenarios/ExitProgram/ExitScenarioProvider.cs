using System.Diagnostics.CodeAnalysis;

namespace ATM.Presentation.Console.Scenarios.ExitProgram;

public class ExitScenarioProvider : IScenarioProvider
{
    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new ExitScenario();
        return true;
    }
}