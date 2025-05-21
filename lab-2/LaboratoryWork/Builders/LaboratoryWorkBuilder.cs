using Itmo.ObjectOrientedProgramming.Lab2.CourseAuthor.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.ID;
using Itmo.ObjectOrientedProgramming.Lab2.LaboratoryWork.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.LaboratoryWork.Builders;

public class LaboratoryWorkBuilder
{
    private readonly IdGenerator _id;

    private long? _parentId;

    private string? name;

    private string? description;

    private string? assessmentCriteria;

    private IAuthor? author;

    private int points;

    public LaboratoryWorkBuilder()
    {
        _id = new IdGenerator();
    }

    public LaboratoryWorkBuilder SetAuthor(IAuthor author)
    {
        this.author = author;
        return this;
    }

    public LaboratoryWorkBuilder SetName(string? name)
    {
        this.name = name;
        return this;
    }

    public LaboratoryWorkBuilder SetParentId(long? parentId)
    {
        this._parentId = parentId;
        return this;
    }

    public LaboratoryWorkBuilder SetDescription(string? description)
    {
        this.description = description;
        return this;
    }

    public LaboratoryWorkBuilder SetAssessmentCriteria(string assessmentCriteria)
    {
        this.assessmentCriteria = assessmentCriteria;
        return this;
    }

    public LaboratoryWorkBuilder SetPoints(int points)
    {
        this.points = points;
        return this;
    }

    public LabWork Build()
    {
        return new LabWork(
            author ?? throw new InvalidOperationException(),
            id: _id.GenerateId(),
            parentId: _parentId,
            name ?? throw new InvalidOperationException(),
            description ?? throw new InvalidOperationException(),
            assessmentCriteria ?? throw new InvalidOperationException(),
            points);
    }
}