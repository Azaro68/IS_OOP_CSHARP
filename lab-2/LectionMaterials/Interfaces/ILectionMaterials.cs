using Itmo.ObjectOrientedProgramming.Lab2.CourseAuthor.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.LectionMaterials.Interfaces;

public interface ILectionMaterials
{
    IAuthor Author { get; }

    long Id { get; }

    long? ParentId { get; }

    string Name { get; }

    string Description { get; }

    string Content { get; }

    ILectionMaterials Clone(ILectionMaterialsBuilder builder, IAuthor author);

    ChangingResult Change(string name, string description, string content, IAuthor author);
}