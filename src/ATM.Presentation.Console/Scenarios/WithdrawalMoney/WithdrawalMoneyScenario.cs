using ATM.Application.Contracts.Accounts;
using Spectre.Console;

namespace ATM.Presentation.Console.Scenarios.WithdrawalMoney;

public class WithdrawalMoneyScenario : IScenario
{
    private readonly IAccountService _accountService;

    public WithdrawalMoneyScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Withdrawal money";

    public void Run()
    {
        int amount = AnsiConsole.Ask<int>("Enter amount");

        Application.Contracts.WithdrawalResult result = _accountService.WithdrawalMoney(amount).Result;

        string message = result switch
        {
            Application.Contracts.WithdrawalResult.Success => "Money were withdrawn",
            Application.Contracts.WithdrawalResult.Failed => "Not enough money",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };
        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}