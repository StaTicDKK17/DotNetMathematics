namespace Mathematics.Matrices;

public class MatrixFactory
{
    public static Matrix Identity(int n)
    {
        Matrix M = new Matrix(n, n);

        for (int i = 0; i < n; i++)
            M.SetItem0I(i, i, 1);

        return M;
    }

    public static Matrix Hilbert(int n)
    {
        Matrix M = new Matrix(n, n);

        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                M.SetItem0I(i, j, 1.0f / (i + j + 1.0f));

        return M;
    }

    public static Matrix Exchange(int n)
    {
        Matrix M = new Matrix(n, n);

        for (int i = n - 1, j = 0; i >= 0; i--, j++)
            M.SetItem0I(i, j, 1);

        return M;
    }
    
    public static Matrix Lehmer(int n)
    {
        Matrix M = new Matrix(n, n);

        for (int i = 1; i <= n; i++)
            for (int j = 1; j <= n; j++)
                M.SetItem(i, j, MathF.Min(i, j) / MathF.Max(i, j));

        return M;
    }

    public static Matrix One(int n)
    {
        Matrix M = new Matrix(n, n);

        for (int i = 1; i <= n; i++)
            for (int j = 1; j <= n; j++)
                M.SetItem(i, j, 1);

        return M;
    }

    public static Matrix One(int n, int m)
    {
        Matrix M = new Matrix(n, m);

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                M.SetItem(i, j, 1);
            }
        }

        return M;
    }

    public static Matrix LowerPascal(int n)
    {
        Matrix M = new Matrix(n, n);

        for (int i = 0; i < n; i++)
            for (int j = 0; j <= i; j++)
            {
                long denominator = MathFunctions.Fac(j) * MathFunctions.Fac(i - j);
                long top = MathFunctions.Fac(i);

                M.SetItem(i+1, j+1, (float)top / (float)denominator);
            }
                

        return M;
    }

    public static Matrix UpperPascal(int n)
    {
        Matrix M = new Matrix(n, n);

        for (int i = 0; i < n; i++)
            for (int j = i; j < n; j++)
            {
                long denominator = MathFunctions.Fac(i) * MathFunctions.Fac(j - i);
                long top = MathFunctions.Fac(j);

                M.SetItem(i + 1, j + 1, (float)top / (float)denominator);
            }

        return M;
    }

    public static Matrix SymmetricPascal(int n)
    {
        Matrix M = new Matrix(n, n);

        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
            {
                long denominator = MathFunctions.Fac(i) * MathFunctions.Fac(j);
                long top = MathFunctions.Fac(i + j);

                M.SetItem(i + 1, j + 1, (float)top / (float)denominator);
            }

        return M;
    }

    public static Matrix Redheffer(int n)
    {
        Matrix M = new Matrix(n, n);

        for (int i = 1; i <= n; i++)
            for (int j = 1; j <= n; j++)
                if (i == 1 || j == 1)
                    M.SetItem(i, j, 1);
                else if (j % i == 0)
                    M.SetItem(i, j, 1);

        return M;
    }

    public static Matrix LowerShift(int n)
    {
        Matrix M = new Matrix(n, n);

        for (int i = 2; i <= n; i++)
                M.SetItem(i, i-1, 1);

        return M;
    }

    public static Matrix UpperShift(int n)
    {
        Matrix M = new Matrix(n, n);

        for (int i = 1; i < n; i++)
                M.SetItem(i, i+1, 1);

        return M;
    }

    public static Matrix Zero(int n)
    {
        Matrix M = new Matrix(n, n);

        return M;
    }

    public static Matrix Zero(int n, int m)
    {
        Matrix M = new Matrix(n, m);

        return M;
    }
}
