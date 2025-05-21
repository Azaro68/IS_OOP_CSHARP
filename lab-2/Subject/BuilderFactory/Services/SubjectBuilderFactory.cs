using Itmo.ObjectOrientedProgramming.Lab2.Subject.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subject.BuilderFactory.Services;

public abstract class SubjectBuilderFactory
{
    public abstract ISubjectBuilder CreateBuilder();
}