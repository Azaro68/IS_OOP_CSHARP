using Itmo.ObjectOrientedProgramming.Lab2.CourseAuthor.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.ID;
using Itmo.ObjectOrientedProgramming.Lab2.LectionMaterials.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.LectionMaterials.Builders;

public class LectionMaterialsBuilder : ILectionMaterialsBuilder
{
    private readonly IdGenerator id;

    public IAuthor? Author { get; private set; }

    public string? Name { get; private set; }

    public string? Description { get; private set; }

    public string? Content { get; private set; }

    public LectionMaterialsBuilder()
    {
        id = new IdGenerator();
    }

    public ILectionMaterialsBuilder SetName(string name)
    {
        Name = name;
        return this;
    }

    public ILectionMaterialsBuilder SetDescription(string description)
    {
        Description = description;
        return this;
    }

    public ILectionMaterialsBuilder SetContent(string content)
    {
        Content = content;
        return this;
    }

    public ILectionMaterialsBuilder SetAuthor(IAuthor author)
    {
        Author = author;
        return this;
    }

    public ILectionMaterials Build()
    {
        return new Models.LectMaterials(
            Author ??
            throw new InvalidOperationException(),
            id.GenerateId(),
            parentId: null,
            Name ?? throw new InvalidOperationException(),
            Description ?? throw new InvalidOperationException(),
            Content ?? throw new InvalidOperationException());
    }
}