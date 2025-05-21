using Itmo.ObjectOrientedProgramming.Lab2.Subject.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Subject.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subject.BuilderFactory.Services;

public class TestSubjectBuilderFactory : SubjectBuilderFactory
{
    public override ISubjectBuilder CreateBuilder()
    {
        return new TestSubjectBuilder();
    }
}