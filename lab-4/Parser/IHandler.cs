using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public interface IHandler
{
    ICommand Handle(IEnumerator<string> command);

    IHandler SetNextExternalHandler(IHandler? handler);
}