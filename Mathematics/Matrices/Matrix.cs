using Mathematics.Vectors;

using System.Diagnostics.Contracts;

namespace Mathematics.Matrices;

public class Matrix : IMatrix
{
    private readonly float[,] xs;

    public int MRows => xs.GetLength(0);

    public int NCols => xs.GetLength(1);

    public (int, int) Size => (MRows, NCols);

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
        xs = new float[A.MRows, A.NCols];

        for (int i = 0; i < A.MRows; i++)
            for (int j = 0; j < A.NCols; j++)
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
        IVector vec = new Vector(MRows);
        for (int j = 0; j < MRows; j++)
            vec.SetItem0I(j, Item0I(j, i-1));

        return vec;
    }

    public float[,] ToArray()
    {
        return xs;
    }

    public IVector Column(int j)
    {
        IVector vec = new Vector(NCols);

        for (int i = 0; i < NCols; i++)
            vec.SetItem0I(i, Item0I(j-1, i));

        return vec;
    }

    public static Matrix Transpose(Matrix M)
    {
        Matrix A = new(M.NCols, M.MRows);

        for (int i = 0; i < M.MRows; i++)
        {
            for (int j = 0; j < M.NCols; j++)
            {
                A.SetItem0I(j, i, M.Item0I(i, j));
            }
        }

        return A;
    }

    public bool IsSymmetric()
    {
        return Transpose(this).Equals(this);
    }

    public bool IsSkewSymmetric()
    {
        return Transpose(this).Equals(-1f * this);
    }

    public static Matrix operator +(Matrix A, Matrix B)
    {
        Contract.Requires(A.MRows == B.MRows);
        Contract.Requires(A.NCols == B.NCols);

        Matrix M = new(A.MRows, A.NCols);

        for (int i = 0; i < A.MRows; i++)
            for (int j = 0; j < A.NCols; j++)
                M.SetItem0I(i, j, A.Item0I(i, j) + B.Item0I(i, j));
            
        return M;
    }

    public static Matrix operator -(Matrix A,  Matrix B)
    {
        Contract.Requires(A.MRows == B.MRows);
        Contract.Requires(A.NCols == B.NCols);

        Matrix M = new(A.MRows, A.NCols);

        for (int i = 0; i < A.MRows; i++)
            for (int j = 0; j < A.NCols; j++)
                M.SetItem0I(i, j, A.Item0I(i, j) - B.Item0I(i, j));

        return M;
    }

    public static Matrix operator *(float x, Matrix M)
    {
        Matrix A = new(M.MRows, M.NCols);

        for (int i = 0; i < M.MRows; i++)
            for (int j = 0; j < M.NCols; j++)
                A.SetItem0I(i, j, M.Item0I(i, j) * x);

        return A;
    }

    public static Matrix operator *(Matrix M, float x)
    {
        Matrix A = new(M.MRows, M.NCols);

        for (int i = 0; i < M.MRows; i++)
            for (int j = 0; j < M.NCols; j++)
                A.SetItem0I(i, j, x * M.Item0I(i, j));

        return A;
    }

    public static Matrix operator *(Matrix A, Matrix B)
    {
        Contract.Requires(A.NCols == B.MRows);

        Matrix M = new(A.MRows, B.NCols);

        for (int i = 0; i < A.MRows; i++)
        {
            for (int j = 0; j < B.NCols; j++)
            {
                float rowRes = 0;
                IVector row = A.Column(i + 1);
                IVector col = B.Row(j + 1);

                for (int e1 = 0; e1 < row.Size; e1++)
                {
                    rowRes += row.ToArray()[e1] * col.ToArray()[e1];
                }

                
                M.SetItem0I(i, j, rowRes);
            }
        }

        return M;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Matrix)
            return false;

        Matrix M = (Matrix)obj;

        for (int i = 0; i < MRows; i++)
            for (int j = 0; j < NCols; j++)
                if (Item0I(i, j) != M.Item0I(i, j))
                    return false;

        return true;
    }

    public override int GetHashCode()
    {
        return xs.GetHashCode();
    }
}
