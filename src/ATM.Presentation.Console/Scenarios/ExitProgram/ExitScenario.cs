namespace ATM.Presentation.Console.Scenarios.ExitProgram;

public class ExitScenario : IScenario
{
    public string Name => "Exit";

    public void Run()
    {
        Environment.Exit(0);
    }
}