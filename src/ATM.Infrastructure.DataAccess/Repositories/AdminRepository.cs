using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using ATM.Application.Abstractions.Repositories;
using ATM.Application.Models.Admins;
using Npgsql;

namespace ATM.Infrastructure.DataAccess.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AdminRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<Admin?> FindAdmin(string password)
    {
        const string sql = """
                           select admin_id, admin_password
                           from admins
                           where admin_password = :password;
                           """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default).ConfigureAwait(false);

        using (var command = new NpgsqlCommand(sql, connection))
        {
            command.AddParameter("password", password);

            using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

            if (await reader.ReadAsync().ConfigureAwait(false) is false)
                return null;

            return new Admin(
                Id: reader.GetInt64(0),
                Password: reader.GetString(1));
        }
    }

    public async void CreateAccount(int number, int pin)
    {
        const string sql = """insert into accounts values (:number, :pin, 0)""";

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default).ConfigureAwait(false);

        using (var command = new NpgsqlCommand(sql, connection))
        {
            command.AddParameter("number", number);
            command.AddParameter("pin", pin);

            await command.ExecuteNonQueryAsync().ConfigureAwait(false);
        }
    }
}