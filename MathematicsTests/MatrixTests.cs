namespace MathematicsTests;

using Mathematics.Matrices;
using Mathematics.Vectors;
using Newtonsoft.Json;

public class MatrixTests
{
    [Fact]
    public void EmptyMatrixCreationWorks()
    {
        IMatrix M = new Matrix(3, 2);

        Assert.True(M.MRows == 3 && M.N_Cols == 2);
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

    [Fact]
    public void MatrixAdditionBehavesWell()
    {
        float[,] floats = { { 2, 1 },
                            { 0, 1 } 
        };
        float[,] floats1 = { { 1, -1},
                             { 2, 0 }
        };

        IMatrix M1 = new Matrix(floats);
        IMatrix M2 = new Matrix(floats1);

        IMatrix M3 = M1 + M2;

        float[,] expected = { { 3, 0 },
                              { 2, 1 }
        };

        IMatrix expectedM = new Matrix(expected);

        Assert.True(expectedM.Equals(M3));
    }

    [Fact]
    public void MatrixSubtractionBehavesWell()
    {
        float[,] floats = { { 2, 1 },
                            { 0, 1 }
        };
        float[,] floats1 = { { 1, -1},
                             { 2, 0 }
        };

        IMatrix M1 = new Matrix(floats);
        IMatrix M2 = new Matrix(floats1);

        IMatrix M3 = M1 - M2;

        float[,] expected = { { 1, 2 },
                              { -2, 1 }
        };

        IMatrix expectedM = new Matrix(expected);

        Assert.True(expectedM.Equals(M3));
    }

    [Fact]
    public void MatrixScalarMultiplicationBehavesWell()
    {
        float[,] floats = { { -2, 3 },
                            {  0, 1 }
        };

        IMatrix M = new Matrix(floats);

        IMatrix actual = -2 * M;

        float[,] expectedFloats = { { 4, -6 },
                                    { 0, -2 }
        };

        IMatrix expected = new Matrix(expectedFloats);

        Assert.True(expected.Equals(actual));
    }

    [Fact]
    public void MatrixFloatMultiplicationWorks()
    {
        float[,] floats = { { -2, 3 },
                            {  0, 1 }
        };

        IMatrix M = new Matrix(floats);

        IMatrix actual = M * -2;

        float[,] expectedFloats = { { 4, -6 },
                                    { 0, -2 }
        };

        IMatrix expected = new Matrix(expectedFloats);

        Assert.True(expected.Equals(actual));
    }

    [Fact]
    public void MatrixMultiplicationBehavesWell()
    {
        float[,] floats1 = { { 1, 2, 5 },
                             { 3, 0, 4 }
        };

        float[,] floats2 = { { 2, 1 },
                             { 3, 6 },
                             { 1, 7 }
        };

        float[,] expectedFloats = { { 13, 48 },
                                    { 10, 31 }
        };

        IMatrix left = new Matrix(floats1);
        IMatrix right = new Matrix(floats2);
        IMatrix expected = new Matrix(expectedFloats);
        IMatrix actual = left * right;

        Assert.True(actual.Equals(expected));
    }

    [Fact]
    public void GetHashCodeWorks()
    {
        float[,] floats = { { 1, 2, 3 },
                            { 4, 5, 6 }
        };

        IMatrix M = new Matrix(floats);
        IMatrix A = new Matrix(floats);

        Assert.True(M.GetHashCode() == A.GetHashCode());
    }
}

