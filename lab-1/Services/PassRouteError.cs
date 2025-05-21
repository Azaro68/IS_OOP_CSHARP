using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class PassRouteError : IError
{
    public string Message { get; }

    public PassRouteError()
    {
        Message = "Speed is bigger than max route speed";
    }
}