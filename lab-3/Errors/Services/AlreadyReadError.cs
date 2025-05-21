using Itmo.ObjectOrientedProgramming.Lab3.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Errors.Services;

public class AlreadyReadError : IError
{
    public string Message { get; }

    public AlreadyReadError()
    {
        Message = "Message is already read";
    }
}