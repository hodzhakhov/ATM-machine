using ATM.Application.Accounts;
using ATM.Application.Admins;
using ATM.Application.Contracts.Accounts;
using ATM.Application.Contracts.Admins;
using Microsoft.Extensions.DependencyInjection;

namespace ATM.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IAccountService, AccountService>();
        collection.AddScoped<IAdminService, AdminService>();

        collection.AddScoped<CurrentAccountManager>();
        collection.AddScoped<ICurrentAccountService>(
            p => p.GetRequiredService<CurrentAccountManager>());

        collection.AddScoped<CurrentAdminManager>();
        collection.AddScoped<ICurrentAdminService>(
            p => p.GetRequiredService<CurrentAdminManager>());

        return collection;
    }
}