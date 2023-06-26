using Mathematics.Vectors;

namespace Mathematics.Matrices;

public interface IMatrix
{
    float[,] ToArray();
    float Item(int i, int j);
    void SetItem(int i, int j, float value);
    IVector Row(int i);
    IVector Column(int j);

    static IMatrix Transpose(IMatrix M)
    {
        return Matrix.Transpose((Matrix)M);
    }

    int MRows { get; }
    int NCols { get; }

    (int, int) Size { get; }

    public bool IsSymmetric();
    public bool IsSkewSymmetric();
    
    public static IMatrix operator +(IMatrix xs, IMatrix ys)
    {
        return (Matrix)xs + (Matrix)ys;
    }

    public static IMatrix operator -(IMatrix xs, IMatrix ys)
    {
        return (Matrix)xs - (Matrix)ys;
    }

    public static IMatrix operator *(IMatrix v, float y)
    {
        return (Matrix)v * y;
    }

    public static IMatrix operator *(float x, IMatrix v)
    {
        return x * (Matrix)v;
    }

    public static IMatrix operator *(IMatrix a, IMatrix v)
    {
        return (Matrix)a * (Matrix)v;
    }
}
