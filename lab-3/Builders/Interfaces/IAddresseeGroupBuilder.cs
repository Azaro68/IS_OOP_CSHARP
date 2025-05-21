using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders.Interfaces;

public interface IAddresseeGroupBuilder
{
    IAddresseeGroupBuilder AddAddressee(IAddressee addressee);

    AddresseeGroup Build();
}