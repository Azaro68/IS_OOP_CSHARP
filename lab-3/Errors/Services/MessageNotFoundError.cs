using Itmo.ObjectOrientedProgramming.Lab3.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Errors.Services;

public class MessageNotFoundError : IError
{
    public string Message { get; }

    public MessageNotFoundError()
    {
        Message = "Message not found";
    }
}