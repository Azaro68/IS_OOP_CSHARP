using Itmo.ObjectOrientedProgramming.Lab2.CourseAuthor.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.LaboratoryWork.Models;
using Itmo.ObjectOrientedProgramming.Lab2.LectionMaterials.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subject.Interfaces;

public interface ISubject
{
    long Id { get; }

    long? ParentId { get; }

    IAuthor Author { get; }

    IList<LabWork> LaboratoryWorks { get; }

    IList<ILectionMaterials>? LectionMaterials { get; }

    string Name { get; }

    ChangingResult Change(string name, IEnumerable<ILectionMaterials> lectionMaterials, IAuthor author);
}