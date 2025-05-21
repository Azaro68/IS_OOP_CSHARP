using Itmo.ObjectOrientedProgramming.Lab2.CourseRepository.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.CourseRepository.Models;

public class Repository<T> where T : IIdentifiable
{
    private readonly Dictionary<long, T> _items;

    public Repository()
    {
        _items = new Dictionary<long, T>();
    }

    public void Add(T item)
    {
        _items[item.Id] = item;
    }

    public T? FindById(long id)
    {
        _items.TryGetValue(id, out T? item);
        return item;
    }
}