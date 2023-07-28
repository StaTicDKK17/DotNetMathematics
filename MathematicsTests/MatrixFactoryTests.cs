using Mathematics.Matrices;

namespace MathematicsTests;

public class MatrixFactoryTests
{
    [Fact]
    public void IdentityOfSize2_IsWellBehaved()
    {
        float[][] expected = { new float[] {1, 0},
                               new float[] {0, 1}
        };

        Matrix A = new Matrix(expected);
        Matrix B = MatrixFactory.Identity(2);

        Assert.True(A.Equals(B));
    }

    [Fact]
    public void IdentityOfSize3_IsWellBehaved()
    {
        float[][] expected = { new float[] {1, 0, 0},
                               new float[] {0, 1, 0},
                               new float[] {0, 0, 1}
        };

        Matrix A = new Matrix(expected);
        Matrix B = MatrixFactory.Identity(3);

        Assert.True(A.Equals(B));
    }

    [Fact]
    public void HilbertOfSize5_IsWellBehaved()
    {
        float[][] expected = { new float[] {1.0f, 1.0f/2.0f, 1f/3f, 1f/4f, 1f/5f},
                               new float[] {1f/2f, 1f/3f, 1f/4f, 1f/5f, 1f/6f},
                               new float[] {1f/3f, 1f/4f, 1f/5f, 1f/6f, 1f/7f},
                               new float[] {1f/4f, 1f/5f, 1f/6f, 1f/7f, 1f/8f},
                               new float[] {1f/5f, 1f/6f, 1f/7f, 1f/8f, 1f/9f}
        };

        Matrix A = new Matrix(expected);
        Matrix B = MatrixFactory.Hilbert(5);

        Assert.True(A.Equals(B));
    }

    [Fact]
    public void ExchangeOfSize2_IsWellBehaved()
    {
        float[][] expected = { new float[] {0, 1},
                               new float[] {1, 0}
        };

        Matrix A = new Matrix(expected);
        Matrix B = MatrixFactory.Exchange(2);

        Assert.True(A.Equals(B));
    }

    [Fact]
    public void ExchangeOfSize3_IsWellBehaved()
    {
        float[][] expected = { new float[] {0, 0, 1},
                               new float[] {0, 1, 0},
                               new float[] {1, 0, 0}
        };

        Matrix A = new Matrix(expected);
        Matrix B = MatrixFactory.Exchange(3);

        Assert.True(A.Equals(B));
    }

    [Fact]
    public void LehmerOfSize2_IsWellBehaved()
    {
        float[][] expected = { new float[] {1f, 1f/2f},
                               new float[] {1f/2f, 1f}
        };

        Matrix A = new Matrix(expected);
        Matrix B = MatrixFactory.Lehmer(2);

        Assert.True(A.Equals(B));
    }

    [Fact]
    public void LehmerOfSize3_IsWellBehaved()
    {
        float[][] expected = {new float[] {1f, 1f/2f, 1f/3f},
                              new float[] {1f/2f, 1f, 2f/3f},
                              new float[] {1f/3f, 2f/3f, 1f}
        };

        Matrix A = new Matrix(expected);
        Matrix B = MatrixFactory.Lehmer(3);

        Assert.True(A.Equals(B));
    }

    [Fact]
    public void LehmerOfSize4_IsWellBehaved()
    {
        float[][] expected = {new float[] {1f, 1f/2f, 1f/3f, 1f/4f},
                              new float[] {1f/2f, 1f, 2f/3f, 1f/2f},
                              new float[] {1f/3f, 2f/3f, 1f, 3f/4f},
                              new float[] {1f/4f, 1f/2f, 3f/4f, 1f}
        };

        Matrix A = new Matrix(expected);
        Matrix B = MatrixFactory.Lehmer(4);

        Assert.True(A.Equals(B));
    }

    [Fact]
    public void OneSquareOfSize2_IsWellBehaved()
    {
        float[][] expected = {new float[] {1, 1},
                              new float[] {1, 1,}
        };

        Matrix A = new Matrix(expected);
        Matrix B = MatrixFactory.One(2);

        Assert.True(A.Equals(B));
    }

    [Fact]
    public void OneSquareOfSize3_IsWellBehaved()
    {
        float[][] expected = {new float[] {1, 1, 1},
                              new float[] {1, 1, 1},
                              new float[] {1, 1, 1}
        };

        Matrix A = new Matrix(expected);
        Matrix B = MatrixFactory.One(3);

        Assert.True(A.Equals(B));
    }

    [Fact]
    public void One2By5_IsWellBehaved()
    {
        float[][] expected = {new float[] {1, 1, 1, 1, 1},
                              new float[] {1, 1, 1, 1, 1}
        };

        Matrix A = new Matrix(expected);
        Matrix B = MatrixFactory.One(2, 5);

        Assert.True(A.Equals(B));
    }

    [Fact]
    public void LowerPascalOfSize5_IsWellBehaved()
    {
        float[][] expected = {new float[] {1, 0, 0, 0, 0},
                              new float[] {1, 1, 0, 0, 0},
                              new float[] {1, 2, 1, 0, 0},
                              new float[] {1, 3, 3, 1, 0},
                              new float[] {1, 4, 6, 4, 1}
        };

        Matrix A = new Matrix(expected);
        Matrix B = MatrixFactory.LowerPascal(5);

        Assert.True(A.Equals(B));
    }

    [Fact]
    public void UpperPascalOfSize5_IsWellBehaved()
    {
        float[][] expected = {new float[] {1, 1, 1, 1, 1},
                              new float[] {0, 1, 2, 3, 4},
                              new float[] {0, 0, 1, 3, 6},
                              new float[] {0, 0, 0, 1, 4},
                              new float[] {0, 0, 0, 0, 1}
        };

        Matrix A = new Matrix(expected);
        Matrix B = MatrixFactory.UpperPascal(5);

        Assert.True(A.Equals(B));
    }

    [Fact]
    public void SymmetricPascalOfSize5_IsWellBehaved()
    {
        float[][] expected = {new float[] {1, 1, 1, 1, 1},
                              new float[] {1, 2, 3, 4, 5},
                              new float[] {1, 3, 6, 10, 15},
                              new float[] {1, 4, 10, 20, 35},
                              new float[] {1, 5, 15, 35, 70}
        };

        Matrix A = new Matrix(expected);
        Matrix B = MatrixFactory.SymmetricPascal(5);

        Assert.True(A.Equals(B));
    }

    [Fact]
    public void RedhefferOfSize12_IsWellBehaved()
    {
        float[][] expected = {
            new float[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            new float[] { 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 },
            new float[] { 1, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1 },
            new float[] { 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1 },
            new float[] { 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
            new float[] { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
            new float[] { 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
            new float[] { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
            new float[] { 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
            new float[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
            new float[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
            new float[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 }
        };

        Matrix A = new Matrix(expected);
        Matrix B = MatrixFactory.Redheffer(12);

        Assert.True(A.Equals(B));
    }

    [Fact]
    public void UpperShiftOfSize5_IsWellBehaved()
    {
        float[][] expected = {new float[] {0, 1, 0, 0, 0},
                              new float[] {0, 0, 1, 0, 0},
                              new float[] {0, 0, 0, 1, 0},
                              new float[] {0, 0, 0, 0, 1},
                              new float[] {0, 0, 0, 0, 0}
        };

        Matrix A = new Matrix(expected);
        Matrix B = MatrixFactory.UpperShift(5);

        Assert.True(A.Equals(B));
    }

    [Fact]
    public void LowerShiftOfSize5_IsWellBehaved()
    {
        float[][] expected = {new float[] {0, 0, 0, 0, 0},
                              new float[] {1, 0, 0, 0, 0},
                              new float[] {0, 1, 0, 0, 0},
                              new float[] {0, 0, 1, 0, 0},
                              new float[] {0, 0, 0, 1, 0}
        };

        Matrix A = new Matrix(expected);
        Matrix B = MatrixFactory.LowerShift(5);

        Assert.True(A.Equals(B));
    }

    [Fact]
    public void ZeroOfSize100_IsWellBehaved()
    {
        Matrix A = new Matrix(100, 100);
        Matrix B = MatrixFactory.Zero(100);

        Assert.True(A.Equals(B));
    }
}
