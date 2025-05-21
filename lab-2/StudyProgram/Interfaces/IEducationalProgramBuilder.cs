using Itmo.ObjectOrientedProgramming.Lab2.CourseAuthor.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Subject.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.StudyProgram.Interfaces;

public interface IEducationalProgramBuilder
{
    IEducationalProgramBuilder SetAuthor(IAuthor author);

    IEducationalProgramBuilder SetName(string name);

    IEducationalProgramBuilder SetSubjects(ISubject subjects);

    IEducationalProgram Build();
}