using Itmo.ObjectOrientedProgramming.Lab2.Errors.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Subject.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.Services;

public abstract record CreateSubjectResult()
{
    public sealed record CreateSubjectSuccess(ISubject Subject) : CreateSubjectResult();

    public sealed record CreateSubjectFailed(IError Error) : CreateSubjectResult();
}