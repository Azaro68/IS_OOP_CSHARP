using Itmo.ObjectOrientedProgramming.Lab2.CourseAuthor.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.LaboratoryWork.Models;
using Itmo.ObjectOrientedProgramming.Lab2.LectionMaterials.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Subject.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subject.Builders;

public abstract class SubjectBuilderBase : ISubjectBuilder
{
    protected IAuthor? Author { get; set; }

    protected IList<LabWork> LaboratoryWorks { get; } = new List<LabWork>();

    protected IList<ILectionMaterials> LectionMaterials { get; } = new List<ILectionMaterials>();

    protected string? Name { get; set; }

    protected int Points { get; set; }

    public ISubjectBuilder SetAuthor(IAuthor author)
    {
        Author = author;
        return this;
    }

    public ISubjectBuilder SetPoints(int points)
    {
        Points = points;
        return this;
    }

    public ISubjectBuilder SetName(string name)
    {
        Name = name;
        return this;
    }

    public ISubjectBuilder SetLaboratoryWork(LabWork laboratoryWorks)
    {
        LaboratoryWorks.Add(laboratoryWorks);
        return this;
    }

    public ISubjectBuilder SetLectureMaterials(ILectionMaterials lectionMaterials)
    {
        LectionMaterials.Add(lectionMaterials);
        return this;
    }

    public abstract CreateSubjectResult Build();
}