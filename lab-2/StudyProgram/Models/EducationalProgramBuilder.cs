using Itmo.ObjectOrientedProgramming.Lab2.CourseAuthor.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.ID;
using Itmo.ObjectOrientedProgramming.Lab2.StudyProgram.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Subject.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.StudyProgram.Models;

public class EducationalProgramBuilder : IEducationalProgramBuilder
{
    private readonly List<ISubject> _subjects = new List<ISubject>();
    private readonly IdGenerator id;
    private IAuthor? _author;
    private string? _name;

    public EducationalProgramBuilder()
    {
        id = new IdGenerator();
    }

    public IEducationalProgramBuilder SetAuthor(IAuthor author)
    {
        _author = author;
        return this;
    }

    public IEducationalProgramBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public IEducationalProgramBuilder SetSubjects(ISubject subjects)
    {
        this._subjects.Add(subjects);
        return this;
    }

    public IEducationalProgram Build()
    {
        return new EducationalProgram(
            _subjects,
            _author ?? throw new InvalidOperationException(),
            _name ?? throw new InvalidOperationException(),
            id.GenerateId());
    }
}