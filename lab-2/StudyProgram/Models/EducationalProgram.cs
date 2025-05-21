using Itmo.ObjectOrientedProgramming.Lab2.CourseAuthor.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.StudyProgram.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Subject.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.StudyProgram.Models;

public class EducationalProgram : IEducationalProgram
{
    public long Id { get; }

    public IAuthor Author { get; }

    public IReadOnlyCollection<ISubject> Subjects { get; }

    public string? Name { get; }

    public EducationalProgram(
        IReadOnlyCollection<ISubject> subjects,
        IAuthor author,
        string name,
        long id)
    {
        Author = author;
        Subjects = subjects;
        Name = name;
        Id = id;
    }
}