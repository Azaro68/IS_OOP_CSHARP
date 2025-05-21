using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Operations;
using Lab5.Application.Models.Users;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UserRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<bool> WithdrawBalance(long userId, decimal amount)
    {
        const string updateBalanceSql = """
                                        update users
                                        set balance = balance - :amount
                                        where user_id = :userId;
                                        """;

        const string insertOperationSql = """
                                          insert into operation_history (user_id, operation_type, operation_amount, operation_result)
                                          values (:userId, 'withdrawal', :amount, 'success');
                                          """;

        using NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(false);

        using NpgsqlTransaction transaction = await connection.BeginTransactionAsync().ConfigureAwait(false);

        try
        {
            decimal currentBalance = await GetBalanceByUserId(userId).ConfigureAwait(false);
            if (currentBalance < amount)
            {
                return false;
            }

            using NpgsqlCommand updateBalanceCommand = new NpgsqlCommand(updateBalanceSql, connection, transaction)
                .AddParameter("userId", userId)
                .AddParameter("amount", amount);

            await updateBalanceCommand.ExecuteNonQueryAsync().ConfigureAwait(false);

            using NpgsqlCommand insertOperationCommand = new NpgsqlCommand(insertOperationSql, connection, transaction)
                .AddParameter("userId", userId)
                .AddParameter("amount", amount);

            await insertOperationCommand.ExecuteNonQueryAsync().ConfigureAwait(false);

            await transaction.CommitAsync().ConfigureAwait(false);

            return true;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync().ConfigureAwait(false);
            return false;
        }
    }

    public async Task Add(User user)
    {
        const string sql = """
                           insert into users (user_name, pincode)
                           values (:username, :pincode)
                           returning user_id;
                           """;

        using NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(false);

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("username", user.Username)
            .AddParameter("pincode", user.Pincode);

        object? result = await command.ExecuteScalarAsync().ConfigureAwait(false);

        if (result is long userId)
        {
            user = user with { Id = userId };
        }
        else
        {
            throw new InvalidOperationException("Failed to generate user ID.");
        }
    }

    public async Task<List<Operation>> GetOperationHistoryByUserId(long userId)
    {
        const string sql = """
                           select operation_id, operation_type, operation_amount, operation_result
                           from operation_history
                           where user_id = :userId
                           order by operation_id asc;
                           """;

        using NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(false);

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("userId", userId);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        var operationHistory = new List<Operation>();

        while (await reader.ReadAsync().ConfigureAwait(false))
        {
            var operation = new Operation(
                    OperationId: reader.GetInt64(0),
                    UserId: reader.GetInt64(1),
                    OperationType: Enum.TryParse<OperationType>(reader.GetString(2), out OperationType type) ? type : throw new InvalidOperationException("Invalid operation type."),
                    Amount: reader.GetDecimal(3),
                    Result: reader.GetString(4));

            operationHistory.Add(operation);
        }

        return operationHistory;
    }

    public async Task<decimal> GetBalanceByUserId(long userId)
    {
        const string sql = """
                           select balance
                           from users
                           where user_id = :userId;
                           """;

        using NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(false);

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("userId", userId);

        object? result = await command.ExecuteScalarAsync().ConfigureAwait(false);

        if (result is not decimal balance)
            throw new InvalidOperationException("Balance not found for the user.");

        return balance;
    }

    public async Task<bool> ReplenishBalance(long userId, decimal amount)
    {
        const string updateBalanceSql = """
                                        update users
                                        set balance = balance + :amount
                                        where user_id = :userId;
                                        """;

        const string insertOperationSql = """
                                          insert into operation_history (user_id, operation_type, operation_amount, operation_result)
                                          values (:userId, 'replenishment', :amount, 'success');
                                          """;

        using NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(false);

        using NpgsqlTransaction transaction = await connection.BeginTransactionAsync().ConfigureAwait(false);

        try
        {
            using NpgsqlCommand updateBalanceCommand = new NpgsqlCommand(updateBalanceSql, connection, transaction)
                .AddParameter("userId", userId)
                .AddParameter("amount", amount);

            await updateBalanceCommand.ExecuteNonQueryAsync().ConfigureAwait(false);

            using NpgsqlCommand insertOperationCommand = new NpgsqlCommand(insertOperationSql, connection, transaction)
                .AddParameter("userId", userId)
                .AddParameter("amount", amount);

            await insertOperationCommand.ExecuteNonQueryAsync().ConfigureAwait(false);

            await transaction.CommitAsync().ConfigureAwait(false);

            return true;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync().ConfigureAwait(false);
            return false;
        }
    }

    public async Task<User?> FindUserByUsername(string username)
    {
        const string sql = """
                           select user_id, user_name, pincode
                           from users
                           where user_name = :username;
                           """;
        using NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(false);

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("username", username);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        if (await reader.ReadAsync().ConfigureAwait(false) is false)
            return null;

        return new User(
            Id: reader.GetInt64(0),
            Username: reader.GetString(1),
            Pincode: reader.GetString(2));
    }
}