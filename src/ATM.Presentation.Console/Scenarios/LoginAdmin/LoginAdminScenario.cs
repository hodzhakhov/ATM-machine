using ATM.Application.Contracts;
using ATM.Application.Contracts.Admins;
using Spectre.Console;

namespace ATM.Presentation.Console.Scenarios.LoginAdmin;

public class LoginAdminScenario : IScenario
{
    private readonly IAdminService _adminService;

    public LoginAdminScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Admin login";

    public void Run()
    {
        string password = AnsiConsole.Ask<string>("Enter admin password");

        LoginResult result = _adminService.Login(password);

        string message = result switch
        {
            LoginResult.Success => "Successful login",
            LoginResult.NotFound => "Admin not found",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}