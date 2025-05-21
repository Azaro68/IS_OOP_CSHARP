namespace Itmo.ObjectOrientedProgramming.Lab4.Visitor;

public class Outputer
{
    private readonly IOutputer _output;
    private readonly string _horizontalSpace;
    private readonly string _connector;

    public Outputer(IOutputer output, string horizontalSpace = "   ", string connector = "|-->")
    {
        _output = output;
        _horizontalSpace = horizontalSpace;
        _connector = connector;
    }

    public void WriteIndented(string value, int depth)
    {
        if (depth > 0)
        {
            _output.Write(new string(_horizontalSpace[0], depth * _horizontalSpace.Length));
            _output.Write(_connector);
        }

        _output.WriteLine(value);
    }
}