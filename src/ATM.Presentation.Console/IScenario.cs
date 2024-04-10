namespace ATM.Presentation.Console;

public interface IScenario
{
    string Name { get; }

    void Run();
}