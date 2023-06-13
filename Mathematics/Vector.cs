using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathematics;

public class Vector : IVector
{
    private float[] xs;

    public int Size => xs.Length;

    public Vector(int n)
    {
        xs = new float[n];
    }

    public Vector(float[] xs)
    {
        this.xs = xs;
    }

    public Vector(Vector v)
    {
        xs = new float[v.Size];

        for(int i = 0; i < v.Size; i++)
            xs[i] = v.xs[i];
        
    }

    public float Item(int i) => xs[i];

    public void SetItem(int i, float value)
    {
        xs[i] = value;
    }

    public float[] ToArray()
    {
        return xs;
    }

    public static Vector operator *(Vector v, float y)
    {
        Vector retval = new Vector(v.Size);

        for (int i = 0; i < v.Size; i++)
            retval.SetItem(i, v.Item(i) * y);

        return retval;
    } 

    public static Vector operator *(float x, Vector v)
    {
        Vector retval = new Vector(v.Size);

        for (int i = 0; i < v.Size; i++)
            retval.SetItem(i, v.Item(i) * x);

        return retval;
    }

    public static Vector operator +(Vector xs, Vector ys)
    {
        Vector retval = new Vector(Math.Min(xs.Size, ys.Size));

        for (int i = 0; i < Math.Min(xs.Size, ys.Size); i++)
            retval.SetItem(i, xs.Item(i) + ys.Item(i));

        return retval;
    }

    public static Vector operator -(Vector xs, Vector ys)
    {
        Vector retval = new Vector(Math.Min(xs.Size, ys.Size));

        for (int i = 0; i < Math.Min(xs.Size, ys.Size); i++)
            retval.SetItem(i, xs.Item(i) - ys.Item(i));

        return retval;
    }

    public static float operator *(Vector xs, Vector ys)
    {
        float retval = 0.0f;

        for (int i = 0; i < Math.Min(xs.Size, ys.Size); i++)
            retval += xs.Item(i) * ys.Item(i);

        return retval;
    }
}
