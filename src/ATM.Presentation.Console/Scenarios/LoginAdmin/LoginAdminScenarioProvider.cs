using System.Diagnostics.CodeAnalysis;
using ATM.Application.Contracts.Accounts;
using ATM.Application.Contracts.Admins;

namespace ATM.Presentation.Console.Scenarios.LoginAdmin;

public class LoginAdminScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _service;
    private readonly ICurrentAdminService _currentAdmin;
    private readonly ICurrentAccountService _currentAccount;

    public LoginAdminScenarioProvider(
        IAdminService service,
        ICurrentAdminService currentAdmin,
        ICurrentAccountService currentAccount)
    {
        _service = service;
        _currentAdmin = currentAdmin;
        _currentAccount = currentAccount;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAdmin.Admin is not null || _currentAccount.Account is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new LoginAdminScenario(_service);
        return true;
    }
}