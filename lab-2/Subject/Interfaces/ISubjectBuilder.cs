using Itmo.ObjectOrientedProgramming.Lab2.CourseAuthor.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.LaboratoryWork.Models;
using Itmo.ObjectOrientedProgramming.Lab2.LectionMaterials.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subject.Interfaces;

public interface ISubjectBuilder
{
    ISubjectBuilder SetAuthor(IAuthor author);

    ISubjectBuilder SetName(string name);

    ISubjectBuilder SetPoints(int points);

    ISubjectBuilder SetLaboratoryWork(LabWork laboratoryWorks);

    ISubjectBuilder SetLectureMaterials(ILectionMaterials lectionMaterials);

    CreateSubjectResult Build();
}