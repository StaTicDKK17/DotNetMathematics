using Mathematics.Vectors;
using System.Data;
using System.Diagnostics.Contracts;

namespace Mathematics.Matrices;

public class Matrix : IMatrix
{
    private readonly float[][] xs;

    public int MRows => xs.Length;

    public int NCols => xs[0].Length;

    public (int, int) Size => (MRows, NCols);

    #region CONSTRUCTORS

    /// <summary>
    /// Creates a matrix with the dimensions gives in the parameters.
    /// the parameters are structured as (number of rows, number of columns)
    /// </summary>
    /// <param name="mRows"></param>
    /// <param name="nCols"></param>
    public Matrix(int mRows, int nCols)
    {
        Contract.Requires(mRows > 0);
        Contract.Requires(nCols > 0);
        xs = new float[mRows][];
        SetupMatrixArray(nCols);
    }

    /// <summary>
    /// Creates a matrix using the provides 2-dimensional float array
    /// </summary>
    /// <param name="xs"></param>
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

    /// <summary>
    /// Creates a matrix using the provides 2-dimensional float array
    /// </summary>
    /// <param name="xs"></param>
    public Matrix(float[][] xs)
    {
        this.xs = xs;
    }

    /// <summary>
    /// Copy-Constructor
    /// </summary>
    /// <param name="A"></param>
    public Matrix(IMatrix A)
    {
        xs = new float[A.MRows][];

        SetupMatrixArray(A.NCols);

        Enumerable.Range(0, A.MRows)
            .ToList()
            .ForEach(i => xs[i] = A.Row(i + 1).ToArray());
    }

    /// <summary>
    /// Sets up the xs property with correct size in all inner arrays
    /// </summary>
    /// <param name="cols"></param>
    private void SetupMatrixArray(int cols)
    {
        Enumerable.Range(0, MRows)
            .ToList()
            .ForEach(i => xs[i] = new float[cols]);
    }

    #endregion

    #region SETTERS

    public void SetItem0I(int i, int j, float value)
    {
        Contract.Requires(i < MRows && i >= 0);
        Contract.Requires(j < NCols && j >= 0);

        xs[i][j] = value;
    }

    public void SetItem(int i, int j, float value)
    {
        Contract.Requires(i <= MRows && i > 0);
        Contract.Requires(j <= NCols && j > 0);

        xs[i - 1][j - 1] = value;
    }

    public void SetRow0I(int i, IVector v)
    {
        Contract.Requires(i < MRows && i >= 0);
        Contract.Requires(v.Size == NCols);

        xs[i] = v.ToArray();
    }

    public void SetRow(int i, IVector v)
    {
        Contract.Requires(i <= MRows && i > 0);
        Contract.Requires(v.Size == NCols);

        xs[i - 1] = v.ToArray();
    }

    public void SetColumn0I(IVector v, int j)
    {
        for (int i = 0; i < MRows; i++)
            SetItem0I(i, j, v.Item0I(i));
    }

    public void SetColumn(IVector v, int j)
    {
        for (int i = 1; i <= MRows; i++)
            SetItem(i, j, v.Item(i));
    }

    #endregion

    #region ROW_OPERATIONS

    /// <summary>
    /// Transforms a row my mapping each element multiplied by the second parameter
    /// </summary>
    /// <param name="row"></param>
    /// <param name="multiplier"></param>
    /// <returns></returns>
    private static float[] TransformRowScaling(float[] row, float multiplier)
    {
        return row
            .Select(p => p * multiplier)
            .ToArray();
    }

    /// <summary>
    /// 1-Indexed - Scales a row by some constant
    /// </summary>
    /// <param name="row"></param>
    /// <param name="multiplier"></param>
    public void ElemetaryRowScaling(int row, float multiplier)
    {
        Contract.Requires(row <= MRows && row > 0);
        Contract.Requires(multiplier != 0);

        
        xs[row - 1] = TransformRowScaling(xs[row - 1], multiplier);
    }

    /// <summary>
    /// Returns the result of row operations row1 + multiplier * row2
    /// </summary>
    /// <param name="row1"></param>
    /// <param name="row2"></param>
    /// <param name="multiplier"></param>
    /// <returns></returns>
    private static float[] TransformRowReplacement(float[] row1, float[] row2, float multiplier)
    {
        return row1
           .Zip(row2, (e1, e2) => e1 + e2 * multiplier)
           .ToArray();
    }
    
    /// <summary>
    /// 1-Indexed - Does row replacement in the form row -> row + multiplier * row2
    /// </summary>
    /// <param name="row"></param>
    /// <param name="multiplier"></param>
    /// <param name="row2"></param>
    public void ElementaryRowReplacement(int row, float multiplier, int row2)
    {
        Contract.Requires(row <= MRows && row > 0);
        Contract.Requires(row2 <= MRows && row2 > 0);
        Contract.Requires(row != row2);
        Contract.Requires(multiplier != 0);

        xs[row - 1] = TransformRowReplacement(xs[row - 1], xs[row2 - 1], multiplier);
    }

    /// <summary>
    /// 1-Indexed - Interchanges two rows in the matrix
    /// </summary>
    /// <param name="row1"></param>
    /// <param name="row2"></param>
    public void ElementaryRowInterchange(int row1, int row2)
    {
        Contract.Requires(row1 != row2);
        Contract.Requires(row2 <= MRows);
        Contract.Requires(row1 <= MRows);

        if (row1 == row2) return;
        
        (xs[row2 - 1], xs[row1 - 1]) = (xs[row1 - 1], xs[row2 - 1]);
    }

    #endregion

    #region GAUSS_ELIMINATION

    /// <summary>
    /// 0-Indexed - Eliminates below or above a pivot if the entry is not zero in the pivots column
    /// </summary>
    /// <param name="rowNum"></param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    private void EliminateRow(int rowNum, int row, int col)
    {
        float item = Item0I(rowNum, col);

        float tolerance = 1e-5f;

        if (Math.Abs(item) > tolerance)
        {
            float value = Math.Abs(item / Item0I(row, col));

            value = DetermineRowFactor(value, item, Item0I(row, col));

            ElementaryRowReplacement(rowNum+1, value, row+1);
        }
    }

    /// <summary>
    /// 0-Indexed - Eliminates all rows below a pivot point using iteration
    /// </summary>
    /// <param name="top_row"></param>
    /// <param name="col"></param>
    private void EliminateBelowPivot(int top_row, int col)
    {
        for (int i = top_row+1; i < MRows; i++)
            EliminateRow(i, top_row, col);
    }

    /// <summary>
    /// 1-Indexed - Eliminates all rows above a pivot | Used for backwards reduction
    /// </summary>
    /// <param name="tolerance"></param>
    /// <param name="top_col"></param>
    /// <param name="row"></param>
    private void EliminateAbovePivot(float tolerance, int top_col, int row)
    {
        for (int i = 1; i < row; i++)
        {
            int other_row = row - i;

            float item = Item0I(other_row - 1, top_col - 1);

            if (Math.Abs(item) > tolerance)
            {
                float value = Math.Abs(item / Item(row, top_col));
                value = DetermineRowFactor(value, item, Item(row, top_col));

                ElementaryRowReplacement(other_row, value, row);
            }
        }
    } 
    
    /// <summary>
    /// Returns the first non-zero entry in the column after the number "row"
    /// </summary>
    /// <param name="row"></param>
    /// <param name="column"></param>
    /// <returns>-1 if no non-zero elements, otherwise the row the non-zero number was found on (1-Indexed)</returns>
    private static int Pivot(int row, IVector column)
    {
        for (int i = row; i < column.Size; i++)
            if (MathF.Abs(column.Item0I(i)) > 1e-6f)
                return i+1;
        
        return -1;
    }

    /// <summary>
    /// Transform the instance to an upper triangular matrix using recursion
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    public void ForwardReduction(int row = 0, int col = 0)
    {
        if (row == MRows || col == NCols)
            return;

        IVector column = Column(col+1);

        int pivot = Pivot(row, column);
        if (pivot != -1)
        {
            ElementaryRowInterchange(row+1, pivot);
            EliminateBelowPivot(row, col);
            ForwardReduction(row + 1, col + 1);
        } else
        {
            ForwardReduction(row, col + 1);
        }

        CleanMatrix();
    }

    public void ForwardReduction()
    {
        ForwardReduction(0, 0);
    }

    public void BackwardReduction()
    {
        float tolerance = 1e-6f;

        int top_col = NCols - 1;

        for (int i = 0; i < MRows; i++)
        {
            int row = MRows - i;
            bool br = false;

            for (int j = 0; j < top_col; j++)
            {
                float item = Item(row, j + 1);
                if (Math.Abs(item) > tolerance && !br && IsPivot(row, j + 1, 1e-6f))
                {
                    ElemetaryRowScaling(row, 1.0f / Item(row, j + 1));

                    EliminateAbovePivot(tolerance, j + 1, row);

                    br = true;
                    top_col--;
                    CleanMatrix();
                }
            }
        }
    }

    public IVector GaussElimination(IVector? b)
    {
        Matrix M;
        if (b is null)
            M = new Matrix(this);
        else
            M = (Matrix)ArgumentRight(this, b);

        M.ForwardReduction();
        M.BackwardReduction();

        return new Vector(M.Column(M.NCols));
    }

    public bool IsPivot(int row, int col, float tolerance)
    {
        for (int i = col - 1; i > 0; i--)
            if (Math.Abs(Item(row, i)) > tolerance)
                return false;

        return true;
    }

    /// <summary>
    /// Determines when doing row replacement whether the factor of the other row should negative or positive to get zero entry
    /// </summary>
    /// <param name="factor"></param>
    /// <param name="item"></param>
    /// <param name="pivot"></param>
    /// <returns></returns>
    private static float DetermineRowFactor(float factor, float item, float pivot)
    {
        return ((item > 0.0 && pivot > 0.0) || (item < 0.0 && pivot < 0.0))
            ? -factor
            : factor;
    }

    #endregion

    #region PROPERTIES

    public bool IsSymmetric()
    {
        return Transpose().Equals(this);
    }

    public bool IsSkewSymmetric()
    {
        return Transpose().Equals(-1f * this);
    }

    /// <summary>
    /// Transposes the matrix M
    /// </summary>
    /// <param name="M"></param>
    /// <returns></returns>
    public IMatrix Transpose()
    {
        Matrix A = new(NCols, MRows);

        Enumerable.Range(0, MRows)
            .ToList()
            .ForEach(
              i => Enumerable.Range(0, NCols)
                .ToList()
                .ForEach(j => A.SetItem0I(j, i, Item0I(i, j)))
        );

        return A;
    }

    public static Matrix SquareSubMatrix(Matrix A, int i, int j)
    {
        Matrix M = new(A);

        for (int row = 0; row < A.MRows; row++)
        {
            if (row != i)
            {
                for (int col = 0; col < A.NCols; col++)
                {
                    if (row > i && col > j)
                        M.SetItem0I(row - 1, col - 1, A.Item0I(row, col));
                    else if (row > i && col < j)
                        M.SetItem0I(row - 1, col, A.Item0I(row, col));
                    else if (row < i && col < j)
                        M.SetItem0I(row, col, A.Item0I(row, col));
                    else if (row < i && col > j)
                        M.SetItem0I(row, col - 1, A.Item0I(row, col));
                }
            }
        }
        return M;
    }
    
    public static float CalculateCoFactor(Matrix A, int i, int j)
    {
        return MathF.Pow(-1, i + j) * A.Determinant();
    }

    public float Determinant()
    {
        float res = 0.0f;

        if (MRows == 1 && NCols == 1)
            res = Item0I(0, 0);
        else
        {
            for (int i = 0; i < NCols; i++)
            {
                Matrix M = SquareSubMatrix(this, 0, i);

                float coFactor = CalculateCoFactor(M, 0, i);

                res += Item0I(0, i) * coFactor;
            }
        }

        return res;
    }

    public (Matrix, Matrix) GramSchmidt()
    {
        Matrix Q = new(MRows, NCols);
        Matrix R = new(MRows, NCols);

        for (int j = 0; j < NCols; j++)
        {
            IVector q_j = Column0I(j + 1);
            Q.SetColumn0I(q_j, j);

            for (int i = 0; i < j; i++)
            {
                R.SetItem0I(i, j, Q.Column0I(i) * Column0I(j));
                q_j -= R.Item0I(i, j) * Q.Column0I(i);
            }
            R.SetItem0I(j, j, q_j.Norm);
            if (!q_j.Equals(new Vector(q_j.Size))) {
                q_j *= 1.0f / R.Item0I(j, j);
                Q.SetColumn0I(q_j, j);
            }
        }

        return (Q, R);
    }
    #endregion

    #region GETTERS

    public float Item0I(int i, int j)
    {
        Contract.Requires(i < MRows && i >= 0);
        Contract.Requires(j < NCols && j >= 0);

        return xs[i][j];
    }
    
    public float Item(int i, int j)
    {
        Contract.Requires(i <= MRows && i > 0);
        Contract.Requires(j <= NCols && j > 0);

        return xs[i - 1][j - 1];
    }

    public IVector Row(int i)
    {
        Contract.Requires(i <= MRows && i > 0);

        return new Vector(xs[i - 1]);
    }

    public IVector Column(int j)
    {
        Contract.Requires(j <= NCols && j > 0);

        return new Vector(Enumerable.Range(0, MRows)
            .Select(e => xs[e][j - 1])
            .ToArray());
    }

    public IVector Column0I(int j)
    {
        Contract.Requires(j < NCols && j >= 0);

        return new Vector(Enumerable.Range(0, MRows)
            .Select(e => xs[e][j])
            .ToArray());
    }

    #endregion

    #region CONVERSION

    public float[][] ToArray()
    {
        return xs;
    }

    #endregion

    #region OBJECT_OVERRIDES

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

    #endregion

    #region MATRIX_OPERATORS

    /// <summary>
    /// Returns a new matrix that arguments v as a new rightmost column of matrix A.
    /// </summary>
    /// <param name="A"></param>
    /// <param name="v"></param>
    /// <returns></returns>
    public static IMatrix ArgumentRight(Matrix A, IVector v)
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
                    M.SetItem0I(i, j, A.Item0I(i, j));
                    M.SetItem0I(i, A.NCols, v.Item0I(i));
                }
              ));

        return M;
    }

    public static IMatrix operator +(Matrix A, Matrix B)
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

    public static IMatrix operator -(Matrix A, Matrix B)
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

    public static IMatrix operator *(float x, Matrix M)
    {
        float[][] floats = M.xs
            .Select(row => row.Select(p => p * x).ToArray()).ToArray();

        return new Matrix(floats);
    }

    public static IMatrix operator *(Matrix M, float x)
    {
        float[][] floats = M.xs
            .Select(row => row.Select(p => p * x).ToArray()).ToArray();

        return new Matrix(floats);
    }

    public static IMatrix operator *(Matrix A, Matrix B)
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

    #endregion

    #region MATRIX_CLEAN

    /// <summary>
    /// Cleans entry if it is approximately zero
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    /// <param name="tolerance"></param>
    private void CleanApproximateFloat(int i, int j, float tolerance)
    {
        if (Math.Abs(Item0I(i, j)) <= tolerance) SetItem0I(i, j, 0);
    }

    /// <summary>
    /// Cleans a row for approximate to zero values
    /// </summary>
    /// <param name="i"></param>
    /// <param name="tolerance"></param>
    private void CleanApproximateFloatsInRow(int i, float tolerance)
    {
        Enumerable.Range(0, NCols)
                .ToList()
                .ForEach(
                j => CleanApproximateFloat(i, j, tolerance)
        );
    }

    /// <summary>
    /// Cleans the instance of approximate to zero values
    /// </summary>
    private void CleanMatrix()
    {
        float tolerance = 1e-6f;

        Enumerable.Range(0, MRows)
            .ToList()
            .ForEach(i => CleanApproximateFloatsInRow(i, tolerance));
    }

    #endregion
}
