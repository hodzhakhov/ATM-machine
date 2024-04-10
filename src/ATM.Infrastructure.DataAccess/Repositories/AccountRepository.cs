using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using ATM.Application.Abstractions.Repositories;
using ATM.Application.Models.Accounts;
using ATM.Application.Models.Transactions;
using Npgsql;

namespace ATM.Infrastructure.DataAccess.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<Account?> FindAccountByNumber(int number)
    {
        const string sql = """
                           select account_number, account_pin, account_balance
                           from accounts
                           where account_number = :number;
                           """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default).ConfigureAwait(false);

        using (var command = new NpgsqlCommand(sql, connection))
        {
            command.AddParameter("number", number);

            using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

            if (await reader.ReadAsync().ConfigureAwait(false) is false)
                return null;

            return new Account(
                Number: reader.GetInt64(0),
                Pin: reader.GetInt32(1),
                Balance: reader.GetInt64(2));
        }
    }

    public async Task AddMoney(long amount, Account account)
    {
        const string sql = """
                           update accounts set account_balance = account_balance + :amount
                           where account_number = :number
                           """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default).ConfigureAwait(false);

        using (var command = new NpgsqlCommand(sql, connection))
        {
            command.AddParameter("amount", amount);
            command.AddParameter("number", account.Number);

            await command.ExecuteNonQueryAsync().ConfigureAwait(false);
        }
    }

    public async Task WithdrawalMoney(long amount, Account account)
    {
        const string sql = """
                           update accounts set account_balance = account_balance - :amount
                           where account_number = :number
                           """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default).ConfigureAwait(false);

        using (var command = new NpgsqlCommand(sql, connection))
        {
            command.AddParameter("amount", amount);
            command.AddParameter("number", account.Number);

            await command.ExecuteNonQueryAsync().ConfigureAwait(false);
        }
    }

    public async Task<long> GetBalance(Account account)
    {
        const string sql = """
                           select account_balance
                           from accounts
                           where account_number = :number;
                           """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default).ConfigureAwait(false);

        using (var command = new NpgsqlCommand(sql, connection))
        {
            command.AddParameter("number", account.Number);

            using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

            if (await reader.ReadAsync().ConfigureAwait(false) is false)
                return -1;

            return reader.GetInt64(0);
        }
    }

    public async Task<IEnumerable<Transaction>> GetAllTransactions(Account account)
    {
        const string sql = """
                           select account_number, transaction_type, transaction_amount
                           from transactions
                           where account_number = :number;
                           """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default).ConfigureAwait(false);

        using (var command = new NpgsqlCommand(sql, connection))
        {
            command.AddParameter("number", account.Number);

            using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

            if (await reader.ReadAsync().ConfigureAwait(false) is false)
                return new List<Transaction>();

            var result = new List<Transaction>();
            while (await reader.ReadAsync().ConfigureAwait(false))
            {
                result.Add(new Transaction(reader.GetInt64(0), await reader.GetFieldValueAsync<TransactionType>(1).ConfigureAwait(false), reader.GetInt64(2)));
            }

            return result;
        }
    }
}