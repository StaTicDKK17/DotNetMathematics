namespace Mathematics;

public class Set<T> : ISet<T>
{
    public int Size => collection.Count;

    private readonly List<T> collection;

    public Set() => collection = new List<T>();

    public Set(IEnumerable<T> elements) => collection = new List<T>(elements);

    public Set(T[] elements) {
        collection = new List<T>();
        foreach (T element in elements)
            collection.Add(element);
    }

    public Set(ISet<T> other)
    {
        collection = new List<T>();
        foreach (T element in other.ToArray())
            collection.Add(element);
    }

    /// <summary>
    /// Returns the intersection between two sets
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public Set<T> Intersection(ISet<T> other) => new Set<T>(collection.Intersect(other.ToArray()));

    /// <summary>
    /// Returns the union between two sets
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public Set<T> Union(ISet<T> other) => new Set<T>(collection.Union(other.ToArray()));
    

    /// <summary>
    /// 
    /// </summary>
    /// <param name="element"></param>
    /// <returns>true if the element is in the set, false otherwise</returns>
    public bool Contains(T element) => collection.Contains(element);

    /// <summary>
    /// Adds element to the set
    /// </summary>
    /// <param name="element"></param>
    public void AddElement(T element) => collection.Add(element);

    /// <summary>
    /// Returns the subtraction of two sets
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public Set<T> Minus(ISet<T> other)
    {
        ISet<T> newSet = new Set<T>();

        foreach (T element in collection)
            if (!other.Contains(element))
                newSet.AddElement(element);

        return (Set<T>)newSet;
    }

    /// <summary>
    /// Returns the symmetric difference between two sets
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public Set<T> SymmetricDifference(ISet<T> other)
    {
        ISet<T> set1 = Minus(other);
        return new Set<T>(set1.Union(other.Minus(this)));
    }

    public T[] ToArray() => collection.ToArray();
}
