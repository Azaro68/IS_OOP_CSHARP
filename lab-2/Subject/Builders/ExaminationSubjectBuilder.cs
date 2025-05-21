using Itmo.ObjectOrientedProgramming.Lab2.Errors.Sevices;
using Itmo.ObjectOrientedProgramming.Lab2.ID;
using Itmo.ObjectOrientedProgramming.Lab2.LaboratoryWork.Models;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Subject.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subject.Builders;

public class ExaminationSubjectBuilder : SubjectBuilderBase
{
    private readonly IdGenerator _id = new IdGenerator();

    public ExaminationSubjectBuilder()
    {
        _id = new IdGenerator();
    }

    public override CreateSubjectResult Build()
    {
        int sum = 0;
        int requiredPoints = 100;

        foreach (LabWork laboratoryWork in LaboratoryWorks)
        {
            sum += laboratoryWork.Points;
        }

        sum += Points;
        if (sum != requiredPoints)
        {
            return new CreateSubjectResult.CreateSubjectFailed(new CreateSubjectError());
        }

        return new CreateSubjectResult.CreateSubjectSuccess(
            new ExaminationSubject(
                Author ?? throw new InvalidOperationException(),
                parentId: null,
                _id.GenerateId(),
                Name ?? throw new InvalidOperationException(),
                Points,
                LaboratoryWorks,
                LectionMaterials ?? throw new InvalidOperationException()));
    }
}