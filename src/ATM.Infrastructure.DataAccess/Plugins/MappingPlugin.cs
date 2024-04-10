using Itmo.Dev.Platform.Postgres.Plugins;
using ATM.Application.Models.Transactions;
using Npgsql;

namespace ATM.Infrastructure.DataAccess.Plugins;

public class MappingPlugin : IDataSourcePlugin
{
    public void Configure(NpgsqlDataSourceBuilder builder)
    {
        builder.MapEnum<TransactionType>();
    }
}