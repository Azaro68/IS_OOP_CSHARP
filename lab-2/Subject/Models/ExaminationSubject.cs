using Itmo.ObjectOrientedProgramming.Lab2.CourseAuthor.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Errors.Sevices;
using Itmo.ObjectOrientedProgramming.Lab2.LaboratoryWork.Models;
using Itmo.ObjectOrientedProgramming.Lab2.LectionMaterials.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Subject.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Subject.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subject.Models;

public class ExaminationSubject : ISubject, IExamination
{
    public int Points { get; }

    public long Id { get; }

    public long? ParentId { get; }

    public IAuthor Author { get; }

    public IList<LabWork> LaboratoryWorks { get; }

    public IList<ILectionMaterials>? LectionMaterials { get; private set; }

    public string Name { get; private set; }

    public ExaminationSubject(
        IAuthor author,
        long? parentId,
        long id,
        string name,
        int points,
        IList<LabWork> laboratoryWorks,
        IList<ILectionMaterials> lectionMaterials)
    {
        Author = author;
        ParentId = parentId;
        Id = id;
        Name = name;
        Points = points;
        LaboratoryWorks = laboratoryWorks;
        LectionMaterials = lectionMaterials;
    }

    public CreateSubjectResult Clone(ExaminationSubjectBuilder builder, IAuthor author)
    {
        foreach (LabWork labWork in LaboratoryWorks)
        {
            builder.SetLaboratoryWork(labWork);
        }

        if (LectionMaterials != null)
        {
            foreach (ILectionMaterials lectMaterials in LectionMaterials)
            {
                builder.SetLectureMaterials(lectMaterials);
            }
        }

        return builder.SetAuthor(author)
            .SetPoints(Points)
            .SetName(Name)
            .Build();
    }

    public ChangingResult Change(string? name, IEnumerable<ILectionMaterials>? lectionMaterials, IAuthor author)
    {
        if (Author.Id != author.Id)
        {
            return new ChangingResult.ChangingResultFailed(new ChangingError());
        }

        if (name != null) Name = name;
        if (lectionMaterials != null) LectionMaterials = (IList<ILectionMaterials>?)lectionMaterials;

        return new ChangingResult.ChangingResultSuccess();
    }
}