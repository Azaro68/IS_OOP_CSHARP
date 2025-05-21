using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class ApplyForceError : IError
{
    public string Message { get; }

    public ApplyForceError()
    {
        Message = "Could not apply the force more than maximal available force";
    }
}