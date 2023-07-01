using Mathematics.Vectors;
using System.Collections;
using System.Diagnostics.Contracts;

namespace Mathematics.Matrices;

public class Matrix : IMatrix
{
    private readonly float[][] xs;

    public int MRows => xs.GetLength(0);

    public int NCols => xs[0].Length;

    public (int, int) Size => (MRows, NCols);

    public Matrix(int mRows, int nCols)
    {
        Contract.Requires(mRows > 0);
        Contract.Requires(nCols > 0);
        xs = new float[mRows][];
        SetupMatrixArray(nCols);
    }

    public Matrix(float[,] xs)
    {
        this.xs = new float[xs.GetLength(0)][];

        SetupMatrixArray(xs.GetLength(1));

        Enumerable.Range(0, xs.GetLength(0))
            .ToList()
            .ForEach(i => Enumerable.Range(0, xs.GetLength(1))
                .ToList()
                .ForEach(j => this.xs[i][j] = xs[i, j]));
    }

    public Matrix(float[][] xs)
    {
        this.xs = xs;
    }

    public Matrix(IMatrix A)
    {
        xs = new float[A.MRows][];

        SetupMatrixArray(A.NCols);

        Enumerable.Range(0, A.MRows)
            .ToList()
            .ForEach(i => xs[i] = A.Row(i + 1).ToArray());
    }

    private void SetupMatrixArray(int cols)
    {
        Enumerable.Range(0, MRows)
            .ToList()
            .ForEach(i => xs[i] = new float[cols]);
    }

    private float Item0I(int i, int j) => xs[i][j];
    public float Item(int i, int j) => xs[i - 1][j - 1];

    private void SetItem0I(int i, int j, float value)
    {
        xs[i][j] = value;
    }


    public void SetItem(int i, int j, float value)
    {
        xs[i - 1][j - 1] = value;
    }

    public IVector Row(int i)
    {
        return new Vector(xs[i-1]);
    }

    public void SetRow(int i, IVector v)
    {
        xs[i - 1] = v.ToArray();
    }

    public float[][] ToArray()
    {
        return xs;
    }

    public IVector Column(int j)
    {
        return new Vector(Enumerable.Range(0, MRows)
            .Select(e => Item0I(e, j - 1))
            .ToArray());
    }

    public static Matrix Transpose(Matrix M)
    {
        Matrix A = new(M.NCols, M.MRows);

        Enumerable.Range(0, M.MRows)
            .ToList()
            .ForEach(
              i => Enumerable.Range(0, M.NCols)
                .ToList()
                .ForEach(j => A.SetItem0I(j, i, M.Item0I(i, j)))
        );

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

    public void ElemetaryRowScaling(int row, float multiplier)
    {   
        float[] TransformedRow = Row(row)
            .ToArray()
            .Select(p => p * multiplier)
            .ToArray();
        xs[row] = TransformedRow;
       
    }

    public void ElementaryRowReplacement(int row, float multiplier, int row2)
    {
        Contract.Requires(row != row2);
        float[] TransformedRow = Row(row)
            .ToArray()
            .Zip(Row(row2).ToArray(), (e1, e2) => e1 + e2 * multiplier)
            .ToArray();
        xs[row] = TransformedRow;
    }

    public static Matrix operator +(Matrix A, Matrix B)
    {
        Contract.Requires(A.MRows == B.MRows);
        Contract.Requires(A.NCols == B.NCols);

        float[][] floats = A.xs
            .Zip(B.xs, (row1, row2) => row1
                .Zip(row2, (e1, e2) => e1 + e2)
                .ToArray()
            )
            .ToArray();
            
        return new Matrix(floats);
    }

    public static Matrix operator -(Matrix A,  Matrix B)
    {
        Contract.Requires(A.MRows == B.MRows);
        Contract.Requires(A.NCols == B.NCols);

        float[][] floats = A.xs
            .Zip(
                B.xs, (row1, row2) => row1.Zip(row2, (e1, e2) => e1 - e2)
                .ToArray()
            ).ToArray();

        return new Matrix(floats);
    }

    public static Matrix operator *(float x, Matrix M)
    { 
        float[][] floats = M.xs
            .Select(row => row.Select(p => p * x).ToArray()).ToArray();

        return new Matrix(floats);
    }

    public static Matrix operator *(Matrix M, float x)
    {
        float[][] floats = M.xs
            .Select(row => row.Select(p => p * x).ToArray()).ToArray();

        return new Matrix(floats);
    }

    public static Matrix operator *(Matrix A, Matrix B)
    {
        Contract.Requires(A.NCols == B.MRows);

        Matrix M = new(A.MRows, B.NCols);

        Enumerable.Range(0, A.MRows)
          .ToList()
          .ForEach(num1 => Enumerable.Range(0, B.NCols)
            .ToList()
              .ForEach(num2 =>
                {
                  float res = A.Row(num1 + 1)
                    .ToArray()
                    .Zip(B.Column(num2 + 1).ToArray(), (e1, e2) => e1 * e2)
                    .Sum();
                  M.SetItem0I(num1, num2, res);
                }
              )
        );

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

    internal static IMatrix ArgumentRight(Matrix A, IVector v)
    {
        Contract.Requires(A.MRows == v.Size);

        IMatrix M = new Matrix(A.MRows, A.NCols + 1);

        Enumerable.Range(0, A.MRows)
            .ToList()
            .ForEach(
            i => Enumerable.Range(0, A.NCols)
              .ToList()
              .ForEach(
                j =>
                {
                    M.SetItem(i + 1, j + 1, A.Item0I(i, j));
                    M.SetItem(i + 1, A.NCols, v.Item0I(i));
                }
              ));

        return M;
    }

    public IEnumerator GetEnumerator()
    {
        return xs.GetEnumerator();
    }
}
