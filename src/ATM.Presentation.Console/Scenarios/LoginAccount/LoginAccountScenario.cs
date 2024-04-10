using ATM.Application.Contracts;
using ATM.Application.Contracts.Accounts;
using Spectre.Console;

namespace ATM.Presentation.Console.Scenarios.LoginAccount;

public class LoginAccountScenario : IScenario
{
    private readonly IAccountService _accountService;

    public LoginAccountScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Account login";

    public void Run()
    {
        int number = AnsiConsole.Ask<int>("Enter account number");
        int pin = AnsiConsole.Ask<int>("Enter account pin");

        LoginResult result = _accountService.Login(number, pin);

        string message = result switch
        {
            LoginResult.Success => "Successful login",
            LoginResult.NotFound => "Account not found",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}