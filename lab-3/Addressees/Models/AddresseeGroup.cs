using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.Models;

public class AddresseeGroup : IAddressee
{
    private readonly List<IAddressee> _addressees = new List<IAddressee>();

    public AddresseeGroup(IList<IAddressee> addressees)
    {
        _addressees = (List<IAddressee>)addressees;
    }

    public void RecieveMessage(Message text)
    {
        foreach (IAddressee addressee in _addressees)
        {
            addressee.RecieveMessage(text);
        }
    }
}