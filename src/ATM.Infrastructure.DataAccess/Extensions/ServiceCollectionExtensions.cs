﻿using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Models;
using Itmo.Dev.Platform.Postgres.Plugins;
using ATM.Application.Abstractions.Repositories;
using ATM.Infrastructure.DataAccess.Plugins;
using ATM.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ATM.Infrastructure.DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureDataAccess(
        this IServiceCollection collection,
        Action<PostgresConnectionConfiguration> configuration)
    {
        collection.AddPlatformPostgres(builder => builder.Configure(configuration));
        collection.AddPlatformMigrations(typeof(ServiceCollectionExtensions).Assembly);

        collection.AddSingleton<IDataSourcePlugin, MappingPlugin>();

        collection.AddScoped<IAccountRepository, AccountRepository>();
        collection.AddScoped<IAdminRepository, AdminRepository>();
        collection.AddScoped<ITransactionRepository, TransactionRepository>();

        return collection;
    }
}