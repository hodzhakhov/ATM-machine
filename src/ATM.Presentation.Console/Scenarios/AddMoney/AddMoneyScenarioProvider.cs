using System.Diagnostics.CodeAnalysis;
using ATM.Application.Contracts.Accounts;
using ATM.Application.Contracts.Admins;

namespace ATM.Presentation.Console.Scenarios.AddMoney;

public class AddMoneyScenarioProvider : IScenarioProvider
{
    private readonly IAccountService _service;
    private readonly ICurrentAdminService _currentAdmin;
    private readonly ICurrentAccountService _currentAccount;

    public AddMoneyScenarioProvider(
        IAccountService service,
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
        if (_currentAccount.Account is null || _currentAdmin.Admin is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new AddMoneyScenario(_service);
        return true;
    }
}