using Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics.Interfaces;

public interface ITopic
{
    string Name { get; }

    void RecieveMessage(Message message);
}