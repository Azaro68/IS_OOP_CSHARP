using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class Route : IRoute
{
    private readonly float _maxRouteSpeed;
    private readonly IReadOnlyCollection<IRouteSegment> _route;

    public Route(IReadOnlyCollection<IRouteSegment> route, float maxSpeed)
    {
        _route = route;
        _maxRouteSpeed = maxSpeed;
    }

    public RideTrainResult RideTrain(ITrain train)
    {
        var time = new Time(0);
        foreach (IRouteSegment segment in _route)
        {
            PassSegmentResult passSegmentResult = segment.PassTrain(train);
            if (passSegmentResult is PassSegmentResult.PassSegmentFailure)
            {
                return new RideTrainResult.Failure(new PassSegmentError());
            }

            if (passSegmentResult is PassSegmentResult.PassSegmentSuccess passSegmentSuccess)
            {
                time.Value += passSegmentSuccess.Time.Value;
            }
        }

        if (train.Speed > _maxRouteSpeed)
        {
            return new RideTrainResult.Failure(new PassRouteError());
        }

        return new RideTrainResult.Success(time);
    }
}