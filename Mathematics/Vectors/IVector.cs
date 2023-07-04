using Mathematics.Matrices;
using System.Collections;

namespace Mathematics.Vectors;

public interface IVector : IEnumerable
{
    /// <returns>An array representation of the vector</returns>
    float[] ToArray();

    /// <summary>
    /// 1-Indexed - Returns the ith item in the vector
    /// </summary>
    /// <param name="i"></param>
    float Item(int i);

    /// <summary>
    /// 0-Indexed - Returns the ith item in the vector
    /// </summary>
    /// <param name="i"></param>
    float Item0I(int i);

    /// <summary>
    /// 1-Indexed - Sets the ith item in the vector to value
    /// </summary>
    /// <param name="i"></param>
    /// <param name="value"></param>s
    void SetItem(int i, float value);

    /// <summary>
    /// 0-Indexed - Sets the ith item in the vector to value
    /// </summary>
    /// <param name="i"></param>
    /// <param name="value"></param>
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
