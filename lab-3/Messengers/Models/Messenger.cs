namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers.Models;

public class Messenger
{
    public void RecieveMessage(string message)
    {
        PrintMessage(message);
    }

    private void PrintMessage(string message)
    {
        Console.WriteLine("Messenger: " + message);
    }
}