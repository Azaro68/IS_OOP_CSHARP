using Itmo.Dev.Platform.Postgres.Connection;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.ConnectionProvider;

public class PostgresConnectionProvider : IPostgresConnectionProvider
{
    public string ConnectionString { get; }

    public PostgresConnectionProvider(string connectionString)
    {
        ConnectionString = connectionString;
    }

    public async ValueTask<NpgsqlConnection> GetConnectionAsync(CancellationToken cancellationToken)
    {
        var connection = new NpgsqlConnection(ConnectionString);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
        return connection;
    }
}