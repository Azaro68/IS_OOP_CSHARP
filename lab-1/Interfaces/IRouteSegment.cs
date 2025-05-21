using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Interfaces;

public interface IRouteSegment
{
    PassSegmentResult PassTrain(ITrain train);
}