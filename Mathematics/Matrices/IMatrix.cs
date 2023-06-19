using Mathematics.Vectors;

namespace Mathematics.Matrices;

public interface IMatrix
{
    float[,] ToArray();
    float Item(int i, int j);
    void SetItem(int i, int j, float value);
    IVector Row(int i);
    IVector Column(int j);

    int M_Rows { get; }
    int N_Cols { get; }

    (int, int) Size { get; }
    
    public static IMatrix operator +(IMatrix xs, IMatrix ys)
    {
        return (IMatrix)((Matrix)xs + (Matrix)ys);
    }

    public static IMatrix operator -(IMatrix xs, IMatrix ys)
    {
        return (IMatrix)((Matrix)xs - (Matrix)ys);
    }

    public static IMatrix operator *(IMatrix v, float y)
    {
        return (IMatrix)((Matrix)v * y);
    }

    public static IMatrix operator *(float x, IMatrix v)
    {
        return (IMatrix)(x * (Matrix)v);
    }

    public static IMatrix operator *(IMatrix a, IMatrix v)
    {
        return (IMatrix)((Matrix)a * (Matrix)v);
    }
}
