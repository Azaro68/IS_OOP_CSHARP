using Itmo.ObjectOrientedProgramming.Lab2.CourseAuthor.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.LectionMaterials.Interfaces;

public interface ILectionMaterialsBuilder
{
    ILectionMaterialsBuilder SetName(string name);

    ILectionMaterialsBuilder SetDescription(string description);

    ILectionMaterialsBuilder SetContent(string content);

    ILectionMaterialsBuilder SetAuthor(IAuthor author);

    ILectionMaterials Build();
}