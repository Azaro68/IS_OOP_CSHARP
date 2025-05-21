using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Interfaces;

public interface IRoute
{
    RideTrainResult RideTrain(ITrain train);
}