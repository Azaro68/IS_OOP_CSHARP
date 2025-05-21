using Itmo.ObjectOrientedProgramming.Lab2.Subject.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Subject.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subject.BuilderFactory.Services;

public class ExaminationSubjectBuilderFactory : SubjectBuilderFactory
{
    public override ISubjectBuilder CreateBuilder()
    {
        return new ExaminationSubjectBuilder();
    }
}