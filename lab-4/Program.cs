using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Program
{
    public static void Main()
    {
        var parser = new CreateParser();
        IHandler root = parser.Create();
        var context = new Context(new FileSystem());

        string firstCom = "connect /Users/mihailrozkov/Desktop -m local";
        var firstListCommands = new List<string>(firstCom.Split(' '));

        IEnumerator<string> firstIterator = firstListCommands.GetEnumerator();
        firstIterator.MoveNext();

        ICommand firstCommand = root.Handle(firstIterator);

        if (firstCommand is not NullCommand)
        {
            if (firstCommand.Execute(context) is ExecutionResult.Failure failure)
            {
                Console.WriteLine(failure.Error);
            }
        }

        string secondCom = "file rename /Users/mihailrozkov/Desktop/testOne/cristal.txt crystal.txt";
        var secondListCommand = new List<string>(secondCom.Split(' '));
        IEnumerator<string> secondIterator = secondListCommand.GetEnumerator();
        secondIterator.MoveNext();

        ICommand secondCommand = root.Handle(secondIterator);

        if (secondCommand is not NullCommand)
        {
            if (secondCommand.Execute(context) is ExecutionResult.Failure failure)
            {
                Console.WriteLine(failure.Error);
            }
        }

        string thirdCom = "file move /testOne/crystal.txt /testTwo/crystal.txt";
        var thirdListCommand = new List<string>(thirdCom.Split(' '));
        IEnumerator<string> thirdIterator = thirdListCommand.GetEnumerator();
        thirdIterator.MoveNext();

        ICommand thirdCommand = root.Handle(thirdIterator);

        if (thirdCommand is not NullCommand)
        {
            if (thirdCommand.Execute(context) is ExecutionResult.Failure failure)
            {
                Console.WriteLine(failure.Error);
            }
        }

        string fourthCom = "tree goto /testOne";
        var fourthListCommand = new List<string>(fourthCom.Split(' '));
        IEnumerator<string> fourthIterator = fourthListCommand.GetEnumerator();
        fourthIterator.MoveNext();

        ICommand fourthCommand = root.Handle(fourthIterator);

        if (fourthCommand is not NullCommand)
        {
            if (fourthCommand.Execute(context) is ExecutionResult.Failure failure)
            {
                Console.WriteLine(failure.Error);
            }
        }

        string fifthCom = "tree list -d 2";
        var fifthhListCommand = new List<string>(fifthCom.Split(' '));
        IEnumerator<string> fifthIterator = fifthhListCommand.GetEnumerator();
        fifthIterator.MoveNext();

        ICommand fifthCommand = root.Handle(fifthIterator);

        if (fifthCommand is not NullCommand)
        {
            if (fifthCommand.Execute(context) is ExecutionResult.Failure failure)
            {
                Console.WriteLine(failure.Error);
            }
        }
    }
}
