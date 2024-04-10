using ATM.Application.Contracts.Admins;

namespace ATM.Presentation.Console.Scenarios.LogoutAdmin;

public class LogoutAdminScenario : IScenario
{
    private readonly IAdminService _adminService;

    public LogoutAdminScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Admin logout";

    public void Run()
    {
        _adminService.Logout();
    }
}