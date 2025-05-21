using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Interfaces;

public interface ITrain
{
    double Speed { get; }

    ApplyForceResult ApplyForce(double force);

    PassSegmentResult Move(double length);
}