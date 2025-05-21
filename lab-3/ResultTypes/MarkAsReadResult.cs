using Itmo.ObjectOrientedProgramming.Lab3.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;

public abstract record MarkAsReadResult()
{
    public sealed record MarkAsReadSuccess() : MarkAsReadResult();

    public sealed record MarkAsReadFailure(IError Error) : MarkAsReadResult();
}