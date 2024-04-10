using System.Globalization;
using ATM.Application.Contracts.Accounts;
using Spectre.Console;

namespace ATM.Presentation.Console.Scenarios.GetBalance;

public class GetBalanceScenario : IScenario
{
    private readonly IAccountService _accountService;

    public GetBalanceScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Get balance";

    public void Run()
    {
        AnsiConsole.WriteLine(CultureInfo.CurrentCulture, _accountService.GetBalance());

        AnsiConsole.Ask<string>("Ok");
    }
}