namespace Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

public abstract record ExecutionResult
{
    public sealed record Success : ExecutionResult;

    public sealed record Failure(IError Error) : ExecutionResult;
}