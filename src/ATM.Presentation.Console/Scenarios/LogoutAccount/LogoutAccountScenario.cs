using ATM.Application.Contracts.Accounts;

namespace ATM.Presentation.Console.Scenarios.LogoutAccount;

public class LogoutAccountScenario : IScenario
{
    private readonly IAccountService _accountService;

    public LogoutAccountScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Account logout";

    public void Run()
    {
        _accountService.Logout();
    }
}