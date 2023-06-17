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

    public static Matrix operator +(Matrix A, Matrix B)
    {
        Contract.Requires(A.M_Rows == B.M_Rows);
        Contract.Requires(A.N_Cols == B.N_Cols);

        Matrix M = new Matrix(A.M_Rows, A.N_Cols);

        for (int i = 0; i < A.M_Rows-1; i++)
            for (int j = 0; j < A.N_Cols-1; j++)
                M.SetItem0I(i, j, A.Item0I(i, j) + B.Item0I(i, j));
            
        return M;
    }

    public static Matrix operator -(Matrix A,  Matrix B)
    {
        Contract.Requires(A.M_Rows == B.M_Rows);
        Contract.Requires(A.N_Cols == B.N_Cols);

        Matrix M = new Matrix(A.M_Rows, A.N_Cols);

        for (int i = 0; i < A.M_Rows - 1; i++)
            for (int j = 0; j < A.N_Cols - 1; j++)
                M.SetItem0I(i, j, A.Item0I(i, j) - B.Item0I(i, j));

        return M;
    }

    public static Matrix operator *(float x, Matrix M)
    {
        Matrix A = new Matrix(M.M_Rows, M.N_Cols);

        for (int i = 0; i < M.M_Rows - 1; i++)
            for (int j = 0; j < M.N_Cols - 1; j++)
                A.SetItem0I(i, j, M.Item0I(i, j) * x);

        return A;
    }

    public static Matrix operator *(Matrix M, float x)
    {
        Matrix A = new Matrix(M.M_Rows, M.N_Cols);

        for (int i = 0; i < M.M_Rows - 1; i++)
            for (int j = 0; j < M.N_Cols - 1; j++)
                A.SetItem0I(i, j, x * M.Item0I(i, j));

        return A;
    }

    public static Matrix operator *(Matrix A, Matrix B)
    {
        Contract.Requires(A.N_Cols == B.M_Rows);

        Matrix M = new Matrix(A.M_Rows, B.N_Cols);

        for (int i = 0; i < A.M_Rows - 1; i++)
        {
            for (int j = 0; j < B.N_Cols-1; j++)
            {
                float rowRes = 0;
                IVector row = A.Row(i + 1);
                IVector col = B.Column(j + 1);

                foreach (float e1 in row.ToArray())
                {
                    foreach(float e2 in col.ToArray())
                    {
                        rowRes += e1 * e2;
                    }
                }
                M.SetItem0I(i, j, rowRes);
            }
        }

        return M;
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
