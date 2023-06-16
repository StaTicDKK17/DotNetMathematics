namespace Mathematics;

public class Set<T> : ISet<T>
{
    public int Size => collection.Count;

    private List<T> collection;

    public Set()
    {
        collection = new List<T>();
    }

    public Set(IEnumerable<T> elements)
    {
        collection = new List<T>(elements);
    }

    public Set(T[] elements) {
        collection = new List<T>();
        foreach (T element in elements)
        {
            collection.Add(element);
        }
    }

    public Set(ISet<T> other)
    {
        collection = new List<T>();
        foreach (T element in other.ToArray())
        {
            collection.Add(element);
        }
    }

    public Set<T> Intersection(ISet<T> other)
    {
        return new Set<T>(collection.Intersect(other.ToArray()));
    }

    public Set<T> Union(ISet<T> other)
    {
        return new Set<T>(collection.Union(other.ToArray()));
    }

    public bool Contains(T element)
    {
        return collection.Contains(element);
    }

    public void AddElement(T element)
    {
        collection.Add(element);
    }

    public Set<T> Minus(ISet<T> other)
    {
        ISet<T> newSet = new Set<T>();

        foreach (T element in collection)
            if (!other.Contains(element))
                newSet.AddElement(element);

        return (Set<T>)newSet;
    }

    public Set<T> SymmetricDifference(ISet<T> other)
    {
        ISet<T> set1 = Minus(other);
        return new Set<T>(set1.Union(other.Minus(this)));
    }

    public T[] ToArray()
    {
        return collection.ToArray();
    }
}
