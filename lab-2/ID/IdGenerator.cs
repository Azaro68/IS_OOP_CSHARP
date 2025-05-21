namespace Itmo.ObjectOrientedProgramming.Lab2.ID;

public class IdGenerator
{
    private long _currentId;

    public IdGenerator(long startId = 1)
    {
        _currentId = startId;
    }

    public long GenerateId()
    {
        return _currentId++;
    }
}