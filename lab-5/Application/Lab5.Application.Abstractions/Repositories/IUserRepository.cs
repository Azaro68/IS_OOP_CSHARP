using Lab5.Application.Models.Operations;
using Lab5.Application.Models.Users;

namespace Lab5.Application.Abstractions.Repositories;

public interface IUserRepository
{
    Task<User?> FindUserByUsername(string username);

    Task<decimal> GetBalanceByUserId(long userId);

    Task<bool> ReplenishBalance(long userId, decimal amount);

    Task<bool> WithdrawBalance(long userId, decimal amount);

    Task<List<Operation>> GetOperationHistoryByUserId(long userId);

    Task Add(User user);
}