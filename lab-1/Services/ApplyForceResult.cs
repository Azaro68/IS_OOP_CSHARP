using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public abstract record ApplyForceResult
{
    public sealed record ApplyForceSuccess() : ApplyForceResult;

    public sealed record ApplyForceFailure(IError Error) : ApplyForceResult;
}