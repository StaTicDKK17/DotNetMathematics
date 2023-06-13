using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public Set(Set<T> other)
    {
        collection = new List<T>();
        foreach (T element in other.collection)
        {
            collection.Add(element);
        }
    }

    public Set<T> Intersection(Set<T> other)
    {
        return new Set<T>(collection.Intersect(other.collection));
    }

    public Set<T> Union(Set<T> other)
    {
        return new Set<T>(collection.Union(other.collection));
    }

    public bool Contains(T element)
    {
        return collection.Contains(element);
    }

    public void AddElement(T element)
    {
        collection.Add(element);
    }

    public Set<T> Minus(Set<T> other)
    {
        Set<T> newSet = new Set<T>();

        foreach (T element in collection)
            if (!other.Contains(element))
                newSet.AddElement(element);

        return newSet;
    }

    public Set<T> SymmetricDifference(Set<T> other)
    {
        Set<T> set1 = this.Minus(other);
        return new Set<T>(set1.Union(other.Minus(this)));
    }
}
