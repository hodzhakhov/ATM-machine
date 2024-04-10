using System.Diagnostics.CodeAnalysis;

namespace ATM.Presentation.Console;

public interface IScenarioProvider
{
    bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario);
}