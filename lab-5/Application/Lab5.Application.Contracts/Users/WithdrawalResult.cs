namespace Lab5.Application.Contracts.Users;

public abstract record WithdrawalResult
{
    public sealed record Success : WithdrawalResult;

    public sealed record Failure : WithdrawalResult;
}