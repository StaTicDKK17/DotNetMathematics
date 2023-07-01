using Mathematics.Matrices;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.Serialization;

namespace Mathematics.Vectors;

public class Vector : IVector
{
    private readonly float[] xs;

    public int Size => xs.Length;

    public float Norm => MathF.Sqrt(xs.Select(x => MathF.Pow(x, 2)).Sum());

    public Vector(int n)
    {
        Contract.Requires(n > 0);
        xs = new float[n];
    }

    public Vector(IEnumerable xs)
    {
        this.xs = (float[])xs;
    }

    public Vector(IVector v)
    {
        xs = new float[v.Size];

        Enumerable.Range(0, v.Size)
            .ToList()
            .ForEach(i => xs[i] = v.ToArray()[i]);
    }

    public float Item(int i) => xs[i - 1];
    public float Item0I(int i) => xs[i];

    public void SetItem0I(int i, float value)
    {
        xs[i] = value;
    }

    public void SetItem(int i, float value)
    {
        xs[i - 1] = value;
    }

    public float[] ToArray()
    {
        return xs;
    }

    public static IVector operator *(Vector v, float y)
    {
        float[] new_elements = v
            .ToArray()
            .Select(e => e * y)
            .ToArray();

        return new Vector(new_elements);
    }

    public static IVector operator *(float x, Vector v)
    {
        float[] new_elements = v
            .ToArray()
            .Select(e => e * x)
            .ToArray();
        
        return new Vector(new_elements);
    }

    public static IVector operator +(Vector xs, Vector ys)
    {
        float[] new_elements = xs
            .ToArray()
            .Zip(ys.ToArray(), (x, y) => x + y)
            .ToArray();

        return new Vector(new_elements);
    }

    public static IVector operator -(Vector xs, Vector ys)
    {
        float[] new_elements = xs
            .ToArray()
            .Zip(ys.ToArray(), (x, y) => x - y)
            .ToArray();

        return new Vector(new_elements);
    }

    public static float operator *(Vector xs, Vector ys)
    {
        return xs
            .ToArray()
            .Zip(ys.ToArray(), (x, y) => x * y)
            .Sum();
    }

    public static IVector operator *(Vector v, IMatrix M)
    {
        Contract.Requires(M.NCols == v.Size);

        float[] res = Enumerable.Range(0, M.MRows)
            .Select(
            i => M.Row(i + 1)
              .ToArray()
              .Zip(v.ToArray(), (x, y) => x * y)
              .Sum()
            )
            .ToArray();
            ;
        return new Vector(res);
    }

    public static IVector operator *(IMatrix M, Vector v)
    {
        Contract.Requires(M.NCols == v.Size);
        float[] res = Enumerable.Range(0, M.MRows)
            .Select(
            i => M.Row(i + 1)
              .ToArray()
              .Zip(v.ToArray(), (x, y) => x * y)
              .Sum()
            )
            .ToArray();
        ;
        return new Vector(res);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Vector)
            return false;
        
        Vector retval = (Vector)obj;

        if (retval.Size != Size) return false;

        for (int i = 0; i < retval.Size; i++)
            if (retval.Item0I(i) != Item0I(i))
                return false;
        
        return true;
        
    }

    public override int GetHashCode()
    {
        return xs.GetHashCode();
    }

    public IEnumerator GetEnumerator()
    {
        return xs.GetEnumerator();
    }
}
