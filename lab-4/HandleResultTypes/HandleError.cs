namespace Itmo.ObjectOrientedProgramming.Lab4.HandleResultTypes;

public class HandleError : IError
{
    public string Message { get; }

    public HandleError()
    {
        Message = "Could not handle command";
    }
}