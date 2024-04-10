﻿using System.Diagnostics.CodeAnalysis;
using ATM.Application.Contracts.Accounts;
using ATM.Application.Contracts.Admins;

namespace ATM.Presentation.Console.Scenarios.LogoutAdmin;

public class LogoutAdminScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _service;
    private readonly ICurrentAdminService _currentAdmin;
    private readonly ICurrentAccountService _currentAccount;

    public LogoutAdminScenarioProvider(
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
        if (_currentAdmin.Admin is null)
        {
            scenario = null;
            return false;
        }

        scenario = new LogoutAdminScenario(_service);
        return true;
    }
}