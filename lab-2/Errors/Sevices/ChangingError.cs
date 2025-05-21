using Itmo.ObjectOrientedProgramming.Lab2.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Errors.Sevices;

public class ChangingError : IError
{
    public string Message { get; }

    public ChangingError()
    {
        Message = "Only the author can change the laboratory work.";
    }
}