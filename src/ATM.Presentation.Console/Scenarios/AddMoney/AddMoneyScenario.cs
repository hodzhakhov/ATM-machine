using ATM.Application.Contracts.Accounts;
using Spectre.Console;

namespace ATM.Presentation.Console.Scenarios.AddMoney;

public class AddMoneyScenario : IScenario
{
    private readonly IAccountService _accountService;

    public AddMoneyScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Add money";

    public void Run()
    {
        int amount = AnsiConsole.Ask<int>("Enter amount");

        _accountService.AddMoney(amount);

        AnsiConsole.Ask<string>("Ok");
    }
}