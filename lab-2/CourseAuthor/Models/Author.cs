using Itmo.ObjectOrientedProgramming.Lab2.CourseAuthor.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.CourseAuthor.Models;

public class Author : IAuthor
{
    public long Id { get; }

    public string Name { get; }

    public Author(string name, long id)
    {
        Id = id;
        Name = name;
    }
}