using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using ATM.Application.Abstractions.Repositories;
using ATM.Application.Models.Transactions;
using Npgsql;

namespace ATM.Infrastructure.DataAccess.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public TransactionRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async void AddTransaction(Transaction transaction)
    {
        const string sql = """insert into transactions(account_number, transaction_type, transaction_amount) values (:number, :type, :amount)""";

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default).ConfigureAwait(false);

        using (var command = new NpgsqlCommand(sql, connection))
        {
            command.AddParameter("number", transaction.AccountNumber);
            command.AddParameter("type", transaction.Type);
            command.AddParameter("amount", transaction.Amount);

            await command.ExecuteNonQueryAsync().ConfigureAwait(false);
        }
    }
}