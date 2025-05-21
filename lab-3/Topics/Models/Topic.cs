using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Topics.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics.Models;

public class Topic : ITopic
{
    private readonly List<IAddressee> _addressees;

    public string Name { get; }

    public Topic(string name)
    {
        Name = name;
        _addressees = new List<IAddressee>();
    }

    public void RecieveMessage(Message message)
    {
        foreach (IAddressee addressee in _addressees)
        {
            addressee.RecieveMessage(message);
        }
    }

    public void AddAddressee(IAddressee addressee)
    {
        _addressees.Add(addressee);
    }
}