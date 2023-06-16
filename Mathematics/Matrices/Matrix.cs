using Mathematics.Vectors;

using System.Diagnostics.Contracts;

namespace Mathematics.Matrices;

public class Matrix : IMatrix
{
    private float[,] xs;

    public int M_Rows => xs.GetLength(0);

    public int N_Cols => xs.GetLength(1);

    public (int, int) Size => (M_Rows, N_Cols);

    public Matrix(int mRows, int nCols)
    {
        Contract.Requires(mRows > 0);
        Contract.Requires(nCols > 0);
        xs = new float[mRows, nCols];
    }

    public Matrix(float[,] xs)
    {
        this.xs = xs;
    }

    public Matrix(IMatrix A)
    {
        xs = new float[A.M_Rows, A.N_Cols];

        for (int i = 0; i < A.M_Rows; i++)
            for (int j = 0; j < A.N_Cols; j++)
                xs[i, j] = A.ToArray()[i, j];
    }

    private float Item0I(int i, int j) => xs[i, j];
    public float Item(int i, int j) => xs[i - 1, j - 1];

    private void SetItem0I(int i, int j, float value)
    {
        xs[i, j] = value;
    }


    public void SetItem(int i, int j, float value)
    {
        xs[i - 1, j - 1] = value;
    }

    public IVector Row(int i)
    {
        IVector vec = new Vector(M_Rows);
        for (int j = 0; j < M_Rows; j++)
            vec.SetItem0I(j, Item0I(j, i-1));

        return vec;
    }

    public float[,] ToArray()
    {
        return xs;
    }

    public IVector Column(int j)
    {
        IVector vec = new Vector(N_Cols);

        for (int i = 0; i < N_Cols; i++)
            vec.SetItem0I(i, Item0I(j-1, i));

        return vec;
    }

    public override bool Equals(object? obj)
    {
        if (!(obj is Matrix))
            return false;

        Matrix M = (Matrix)obj;

        for (int i = 0; i < M_Rows; i++)
            for (int j = 0; j < N_Cols; j++)
                if (Item0I(i, j) != M.Item0I(i, j))
                    return false;

        return true;
    }
}
