namespace Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

public class ParsingError : IError
{
    public string Message { get; }

    public ParsingError()
    {
        Message = "Could not parse command";
    }
}