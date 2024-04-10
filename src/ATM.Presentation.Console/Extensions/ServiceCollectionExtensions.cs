using ATM.Presentation.Console.Scenarios.AddAccount;
using ATM.Presentation.Console.Scenarios.AddMoney;
using ATM.Presentation.Console.Scenarios.ExitProgram;
using ATM.Presentation.Console.Scenarios.GetBalance;
using ATM.Presentation.Console.Scenarios.GetTransactions;
using ATM.Presentation.Console.Scenarios.LoginAccount;
using ATM.Presentation.Console.Scenarios.LoginAdmin;
using ATM.Presentation.Console.Scenarios.LogoutAccount;
using ATM.Presentation.Console.Scenarios.LogoutAdmin;
using ATM.Presentation.Console.Scenarios.WithdrawalMoney;
using Microsoft.Extensions.DependencyInjection;

namespace ATM.Presentation.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, LoginAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LogoutAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LoginAdminScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LogoutAdminScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AddAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AddMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, WithdrawalMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, GetBalanceScenarioProvider>();
        collection.AddScoped<IScenarioProvider, GetTransactionsScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ExitScenarioProvider>();

        return collection;
    }
}