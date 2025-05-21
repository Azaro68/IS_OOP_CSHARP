using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class Train : ITrain
{
    private readonly Mass _mass;
    private readonly double _maxForce;
    private readonly Precision _precision;
    private double _acceleration;

    public Train(Mass mass, double maxForce, Precision precision)
    {
        _mass = mass;
        _maxForce = maxForce;
        _precision = precision;
        Speed = 0;
        _acceleration = 0;
    }

    public double Speed { get; private set; }

    public ApplyForceResult ApplyForce(double force)
    {
        if (force > _maxForce)
        {
            return new ApplyForceResult.ApplyForceFailure(new ApplyForceError());
        }

        _acceleration = force / _mass.Value;
        return new ApplyForceResult.ApplyForceSuccess();
    }

    public PassSegmentResult Move(double length)
    {
        double totalDistance = length;
        var time = new Time(0);
        while (totalDistance > 0)
        {
            Speed += _acceleration * _precision.Value;
            if (Speed <= 0)
            {
                return new PassSegmentResult.PassSegmentFailure(new PassSegmentError());
            }

            totalDistance -= Speed * _precision.Value;
            time.Value += _precision.Value;
        }

        return new PassSegmentResult.PassSegmentSuccess(time);
    }
}