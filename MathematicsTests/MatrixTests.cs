namespace MathematicsTests;

using Mathematics.Matrices;
using Mathematics.Vectors;

public class MatrixTests
{
    [Fact]
    public void EmptyMatrixCreationWorks()
    {
        IMatrix M = new Matrix(3, 2);

        Assert.True(M.M_Rows == 3 && M.N_Cols == 2);
    }

    [Fact]
    public void SizePropertyBehavesWell()
    {
        IMatrix M = new Matrix(7, 32);

        var dims = M.Size;

        Assert.True(dims.Item1 == 7 && dims.Item2 == 32);
    }

    [Fact]
    public void MatrixCreationWithElementsWorks()
    {
        float[,] floats = { { 3.0f, 4.0f, 5.0f},
                            { 1.0f, 2.0f, 3.0f }
        };

        IMatrix M = new Matrix(floats);

        var dimensions = M.Size;

        Assert.True(dimensions.Item1 == 2 && dimensions.Item2 == 3);
    }

    [Fact]
    public void CopyConstructorWorks()
    {
        float[,] floats = { { 1.0f, 2.0f, 3.0f, 4.0f},
                            { 5.0f, 6.0f, 7.0f, 8.0f }
        };

        IMatrix M = new Matrix(floats);
        IMatrix M1 = new Matrix(M);

        Assert.True(M.Equals(M1));
    }

    [Fact]
    public void ItemMethodBehavesWell()
    {
        float[,] floats = { { 1.0f, 2.0f, 3.0f, 4.0f},
                            { 5.0f, 6.0f, 7.0f, 8.0f }
        };

        IMatrix M = new Matrix(floats);

        Assert.Equal(5.0f, M.Item(2, 1));
    }

    [Fact]
    public void SetItemMethodBehavesWell()
    {
        float[,] floats = { { 1.0f, 2.0f, 3.0f, 4.0f},
                            { 5.0f, 6.0f, 7.0f, 8.0f }
        };

        IMatrix M = new Matrix(floats);

        M.SetItem(2, 1, 42.0f);

        Assert.Equal(42.0f, M.Item(2, 1));
    }

    [Fact]
    public void RowMethodBehavesWell()
    {
        float[,] floats = { { 3.0f, 2.0f },
                            { 4.0f, 3.0f }
        };

        IMatrix M = new Matrix(floats);

        IVector vec = M.Row(1);

        Assert.True(new Vector(new float[] { 3.0f, 4.0f }).Equals(vec));
    }

    [Fact]
    public void ColumnMethodBehavesWell()
    {
        float[,] floats = { { 3.0f, 2.0f },
                            { 4.0f, 3.0f }
        };

        IMatrix M = new Matrix(floats);

        IVector vec = M.Column(1);

        Assert.True(new Vector(new float[] {3.0f, 2.0f }).Equals(vec));
    }

    [Fact]
    public void ToArrayBehavesWell()
    {
        float[,] floats = { { 3.0f, 2.0f },
                            { 4.0f, 3.0f }
        };

        IMatrix M = new Matrix(floats);

        float[,] res = M.ToArray();

        for (int i = 0; i < 2; i++)
            for(int j = 0; j < 2; j++) {
                Assert.Equal(floats[i, j], res[i, j]);
        }
    }

    [Fact]
    public void EqualsReturnsFalseForOtherObjects()
    {
        float[,] floats = { { 3.0f, 2.0f },
                            { 4.0f, 3.0f }
        };

        IMatrix M = new Matrix(floats);

        IVector v = new Vector(30);

        Assert.False(M.Equals(v));
    }

    [Fact]
    public void EqualsReturnsFalseOnDifferentMatrices()
    {
        float[,] floats = { { 3.0f, 2.0f },
                            { 4.0f, 3.0f }
        };
        float[,] float2 = { { 3.0f, 42.0f },
                            { 4.0f, 3.0f }
        };

        IMatrix M = new Matrix(floats);
        IMatrix M1 = new Matrix(float2);

        Assert.False(M.Equals(M1));
    }

    [Fact]
    public void NullIsNotMatrix()
    {
        float[,] floats = { { 3.0f, 2.0f },
        };
        IMatrix M = new Matrix(floats);

        Assert.False(M.Equals(null));
    }

    [Fact]
    public void MatrixIsNotEqualVector()
    {
        float[] floats1 = { 3.0f, 2.0f };
        float[,] floats2 = { { 3.0f, 2.0f },
        };

        IMatrix M = new Matrix(floats2);
        IVector v = new Vector(floats1);

        Assert.False(M.Equals(v));
    }
}

