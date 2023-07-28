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
                M.SetItem0I(i, j, 1.0f / ((float)i + (float)j + 1.0f));

        return M;
    }

    public static Matrix Exchange(int n)
    {
        Matrix M = new Matrix(n, n);

        for (int i = n - 1; i >= 0; i--)
            for (int j = 0; j < n; j++)
                M.SetItem0I(i, j, 1);

        return M;
    }
    
    public static Matrix Lehmer(int n)
    {
        Matrix M = new Matrix(n, n);

        for (int i = 1; i <= n; i++)
            for (int j = 1; j <= n; j++)
                M.SetItem(i, j, Math.Min(i, j) / Math.Max(i, j));

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

    public static Matrix LowerPascal(int n)
    {
        Matrix M = new Matrix(n, n);

        for (int i = 1; i <= n; i++)
            for (int j = 1; j <= i; j++)
                M.SetItem(i, j, MathFunctions.Fac(i) / (MathFunctions.Fac(j) * MathFunctions.Fac(i - j)));

        return M;
    }

    public static Matrix UpperPascal(int n)
    {
        Matrix M = new Matrix(n, n);

        for (int i = 1; i <= n; i++)
            for (int j = i; j <= n; j++)
                M.SetItem(i, j, MathFunctions.Fac(j) / (MathFunctions.Fac(i) * MathFunctions.Fac(j - i)));

        return M;
    }

    public static Matrix SymmetricPascal(int n)
    {
        Matrix M = new Matrix(n, n);

        for (int i = 1; i <= n; i++)
            for (int j = 1; j <= n; j++)
                M.SetItem(i, j, MathFunctions.Fac(i + j) / (MathFunctions.Fac(i) * MathFunctions.Fac(j)));

        return M;
    }

    public static Matrix Redheffer(int n)
    {
        Matrix M = new Matrix(n, n);

        for (int i = 1; i <= n; i++)
            for (int j = 1; j <= n; j++)
                if (i % j == 0)
                    M.SetItem(i, j, 1);

        return M;
    }

    public static Matrix LowerShift(int n)
    {
        Matrix M = new Matrix(n, n);

        for (int i = 2; i < n; i++)
            for (int j = i - 1; j == i - 1; j++)
                M.SetItem(i, j, 1);

        return M;
    }

    public static Matrix UpperShift(int n)
    {
        Matrix M = new Matrix(n, n);

        for (int i = 1; i <= n; i++)
            for (int j = i + 1; j == i + 1; j++)
                M.SetItem(i, j, 1);

        return M;
    }

    public static Matrix Zero(int n)
    {
        Matrix M = new Matrix(n, n);

        return M;
    }
}
