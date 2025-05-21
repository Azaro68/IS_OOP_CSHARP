using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Builders.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders.Services;

public class AddresseeGroupBuilder : IAddresseeGroupBuilder
{
    private readonly List<IAddressee> _addressees = new List<IAddressee>();

    public IAddresseeGroupBuilder AddAddressee(IAddressee addressee)
    {
        _addressees.Add(addressee);

        return this;
    }

    public AddresseeGroup Build()
    {
        return new AddresseeGroup(_addressees);
    }
}