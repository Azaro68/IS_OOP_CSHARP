using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class Station : IRouteSegment
{
    private readonly float _maxStationSpeed;
    private readonly Workload _workload;

    public Station(Workload workload, float maxStationSpeed)
    {
        _workload = workload;
        _maxStationSpeed = maxStationSpeed;
    }

    public PassSegmentResult PassTrain(ITrain train)
    {
        if (train.Speed > _maxStationSpeed)
        {
            return new PassSegmentResult.PassSegmentFailure(new PassSegmentError());
        }

        return new PassSegmentResult.PassSegmentSuccess(new Time(_workload.Value));
    }
}