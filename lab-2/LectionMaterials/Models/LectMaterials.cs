using Itmo.ObjectOrientedProgramming.Lab2.CourseAuthor.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Errors.Sevices;
using Itmo.ObjectOrientedProgramming.Lab2.LectionMaterials.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.LectionMaterials.Models;

public class LectMaterials : ILectionMaterials
{
    public IAuthor Author { get; }

    public long Id { get; }

    public long? ParentId { get; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public string Content { get; private set; }

    public ILectionMaterials Clone(ILectionMaterialsBuilder builder, IAuthor author)
    {
        return builder.SetAuthor(author)
            .SetContent(Content)
            .SetName(Name)
            .SetDescription(Description)
            .Build();
    }

    public LectMaterials(
        IAuthor author,
        long id,
        long? parentId,
        string name,
        string description,
        string content)
    {
        Author = author;
        Id = id;
        ParentId = parentId;
        Name = name;
        Description = description;
        Content = content;
    }

    public ChangingResult Change(string? name, string? description, string? content, IAuthor author)
    {
        if (Author.Id != author.Id)
        {
            return new ChangingResult.ChangingResultFailed(new ChangingError());
        }

        if (name != null) Name = name;
        if (description != null) Description = description;
        if (content != null) Content = content;

        return new ChangingResult.ChangingResultSuccess();
    }
}