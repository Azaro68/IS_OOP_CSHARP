using Itmo.ObjectOrientedProgramming.Lab2.CourseAuthor.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Errors.Sevices;
using Itmo.ObjectOrientedProgramming.Lab2.LaboratoryWork.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.LaboratoryWork.Models;

public class LabWork
{
    public IAuthor Author { get; }

    public long Id { get; }

    public long? ParentId { get; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public string AssessmentCriteria { get; private set; }

    public int Points { get; }

    public LabWork(
        IAuthor author,
        long id,
        long? parentId,
        string name,
        string description,
        string assessmentCriteria,
        int points)
    {
        Id = id;
        Author = author;
        ParentId = parentId;
        Name = name;
        Description = description;
        AssessmentCriteria = assessmentCriteria;
        Points = points;
    }

    public LabWork Clone(LaboratoryWorkBuilder builder, IAuthor author)
    {
        return builder.SetAuthor(author)
            .SetName(Name)
            .SetParentId(Id)
            .SetDescription(Description)
            .SetPoints(Points)
            .SetAssessmentCriteria(AssessmentCriteria)
            .Build();
    }

    public ChangingResult Change(string name, string description, string assessmentCriteria, IAuthor author)
    {
        if (Author != author)
        {
            return new ChangingResult.ChangingResultFailed(new ChangingError());
        }

        Name = name;
        Description = description;
        AssessmentCriteria = assessmentCriteria;

        return new ChangingResult.ChangingResultSuccess();
    }
}