using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public abstract record PassSegmentResult
{
    public sealed record PassSegmentSuccess(Time Time) : PassSegmentResult;

    public sealed record PassSegmentFailure(IError Error) : PassSegmentResult;
}