using Itmo.Dev.Platform.Postgres.Connection;
using Lab5.Application.Abstractions.Repositories;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AdminRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<string> GetAdminPassword()
    {
        const string sql = "select password from admins limit 1;";

        using NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        using var command = new NpgsqlCommand(sql, connection);

        object? result = await command.ExecuteScalarAsync().ConfigureAwait(false);

        if (result is not string password)
            throw new InvalidOperationException("Admin password not set in the database.");

        return password;
    }
}