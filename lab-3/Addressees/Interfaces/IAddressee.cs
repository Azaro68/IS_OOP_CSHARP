using Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.Interfaces;

public interface IAddressee
{
    void RecieveMessage(Message text);
}