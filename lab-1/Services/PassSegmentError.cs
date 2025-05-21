using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class PassSegmentError : IError
{
    public string Message { get; }

    public PassSegmentError()
    {
        Message = "Could not pass through route segment";
    }
}