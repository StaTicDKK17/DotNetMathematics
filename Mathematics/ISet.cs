namespace Mathematics;

public interface ISet<T>
{
    Set<T> Intersection(ISet<T> other);
    Set<T> Union(ISet<T> other);
    bool Contains(T element);
    Set<T> Minus(ISet<T> other);
    void AddElement(T element);
    Set<T> SymmetricDifference(ISet<T> other);
    T[] ToArray();

    int Size {  get; }
}
