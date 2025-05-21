using Itmo.ObjectOrientedProgramming.Lab2.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Errors.Sevices;

public class CreateSubjectError : IError
{
    public string Message { get; }

    public CreateSubjectError()
    {
        Message = "Could not create the subject where points don't equal 100";
    }
}