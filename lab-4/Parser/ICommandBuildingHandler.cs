using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public interface ICommandBuildingHandler<T>
{
    ICommand Handle(IEnumerator<string> command, T builder);

    ICommandBuildingHandler<T> SetNextHandler(ICommandBuildingHandler<T> handler);
}