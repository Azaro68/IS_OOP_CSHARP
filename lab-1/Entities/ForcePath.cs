using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class ForcePath : IRouteSegment
{
    private readonly Length _length;
    private readonly double _force;

    public ForcePath(Length length, double force)
    {
        _length = length;
        _force = force;
    }

    public PassSegmentResult PassTrain(ITrain train)
    {
        ApplyForceResult applyForceResult = train.ApplyForce(_force);

        if (applyForceResult is ApplyForceResult.ApplyForceFailure)
        {
            return new PassSegmentResult.PassSegmentFailure(new ApplyForceError());
        }

        PassSegmentResult passSegmentResult = train.Move(_length.Value);

        train.ApplyForce(0);

        if (passSegmentResult is PassSegmentResult.PassSegmentFailure)
        {
            return new PassSegmentResult.PassSegmentFailure(new ApplyForceError());
        }

        return passSegmentResult;
    }
}