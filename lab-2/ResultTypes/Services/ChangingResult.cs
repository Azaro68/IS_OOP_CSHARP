using Itmo.ObjectOrientedProgramming.Lab2.Errors.Sevices;

namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.Services;

public abstract record ChangingResult()
{
    public sealed record ChangingResultSuccess() : ChangingResult();

    public sealed record ChangingResultFailed(ChangingError Error) : ChangingResult();
}