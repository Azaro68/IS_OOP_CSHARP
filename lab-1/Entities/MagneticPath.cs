using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class MagneticPath : IRouteSegment
{
    private readonly Length _length;

    public MagneticPath(Length length)
    {
        _length = length;
    }

    public PassSegmentResult PassTrain(ITrain train)
    {
        PassSegmentResult passSegmentResult = train.Move(_length.Value);
        if (passSegmentResult is PassSegmentResult.PassSegmentFailure failure)
        {
            return new PassSegmentResult.PassSegmentFailure(new PassSegmentError());
        }

        return passSegmentResult;
    }
}