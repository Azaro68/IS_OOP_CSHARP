namespace Lab5.Infrastructure.DataAccess.Repositories;

public abstract record LoginResult
{
    private LoginResult() { }

    public sealed record Success : LoginResult;

    public sealed record NotFound : LoginResult;
}