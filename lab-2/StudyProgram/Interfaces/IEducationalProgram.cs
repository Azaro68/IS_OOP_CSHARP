using Itmo.ObjectOrientedProgramming.Lab2.CourseAuthor.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Subject.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.StudyProgram.Interfaces;

public interface IEducationalProgram
{
    long Id { get; }

    IAuthor Author { get; }

    IReadOnlyCollection<ISubject> Subjects { get; }

    string? Name { get; }
}