using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public abstract record RideTrainResult()
{
    public sealed record Success(Time Time) : RideTrainResult();

    public sealed record Failure(IError Error) : RideTrainResult();
}