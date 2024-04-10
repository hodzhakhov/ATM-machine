using ATM.Application.Contracts.Admins;
using Spectre.Console;

namespace ATM.Presentation.Console.Scenarios.AddAccount;

public class AddAccountScenario : IScenario
{
    private readonly IAdminService _adminService;

    public AddAccountScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Add account";

    public void Run()
    {
        int number = AnsiConsole.Ask<int>("Enter account number");
        int pin = AnsiConsole.Ask<int>("Enter account pin");
        _adminService.CreateAccount(number, pin);

        AnsiConsole.Ask<string>("Ok");
    }
}