using Mathematics.Matrices;
using System.Collections;

namespace Mathematics.Vectors;

public interface IVector
{
    float[] ToArray();
    float Item(int i);
    public float Item0I(int i);
    void SetItem(int i, float value);
    void SetItem0I(int i, float value);

    float Norm { get; }

    public static IVector operator *(IVector v, float y)
    {
        return (Vector)v * y;
    }

    public static IVector operator *(float x, IVector v)
    {
        return x * (Vector)v;
    }

    public static IVector operator +(IVector xs, IVector ys)
    {
        return (Vector)xs + (Vector)ys;
    }

    public static IVector operator -(IVector xs, IVector ys)
    {
        return (Vector)xs - (Vector)ys;
    }

    public static float operator *(IVector xs, IVector ys)
    {
        return (Vector)xs * (Vector)ys;
    }

    public static IVector operator *(IVector v, IMatrix M)
    {
        return (Vector)v * M;
    }

    public static IVector operator *(IMatrix M, IVector v)
    {
        return M * (Vector)v;
    }



    int Size { get; }
}
