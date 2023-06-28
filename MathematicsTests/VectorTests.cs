using Mathematics.Matrices;
using Mathematics.Vectors;
using System.Runtime.Intrinsics;

namespace MathematicsTests;

public class VectorTests
{
    [Fact]
    public void ElementaryVectorConstructorWorks()
    {
        IVector vec = new Vector(5);

        Assert.Equal(5, vec.Size);
    }

    [Fact]
    public void FloatArrayConstructorWorks()
    {
        float[] floats = { 3.0f, 5.0f, -2.0f };

        IVector vec = new Vector(floats);

        Assert.Equal(3, vec.Size);
    }

    [Fact]
    public void CopyConstructorBehavesWell()
    {
        float[] floats = { 1.0f, 3.0f, 5.0f, -4.0f };

        IVector vec1 = new Vector(floats);
        IVector vec2 = new Vector(vec1);

        Assert.True(vec1.Equals(vec2));
    }

    [Fact]
    public void OneIndexedItemBehavesWell()
    {
        float[] floats = { 1.0f, 2.0f, 3.0f, 4.0f };

        IVector vec1 = new Vector(floats);

        Assert.Equal(2.0f, vec1.Item(2));
    }

    [Fact]
    public void ZeroIndexedItemBehavesWell()
    {
        float[] floats = { 1.0f, 2.0f, 3.0f, 4.0f };

        IVector vec1 = new Vector(floats);

        Assert.Equal(1.0f, vec1.Item0I(0));
    }

    [Fact]
    public void OneIndexedSetItemBehavesWell()
    {
        float[] floats = { 1.0f, 2.0f, 3.0f, 4.0f };

        IVector vec1 = new Vector(floats);

        vec1.SetItem(1, 5.0f);

        Assert.Equal(5.0f, vec1.Item(1));
    }

    [Fact]
    public void ZeroIndexedSetItemBehavesWell()
    {
        float[] floats = { 1.0f, 2.0f, 3.0f, 4.0f };

        IVector vec1 = new Vector(floats);

        vec1.SetItem0I(2, 42.0f);

        Assert.Equal(42.0f, vec1.Item(3));
    }

    [Fact]
    public void ToArrayBehavesWell()
    {
        float[] floats = { 1.0f, 2.0f, 3.0f, 4.0f };

        IVector vec1 = new Vector(floats);

        float[] returnRes = vec1.ToArray();
        for(int i = 0; i < floats.Length; i++)
        {
            Assert.Equal(floats[i], returnRes[i]);
        }
    }

    [Fact]
    public void AdditionBehavesWell()
    {
        float[] floats = { 1.0f, 2.0f, 3.0f, 4.0f };

        IVector vec1 = new Vector(floats);

        IVector vec2 = new Vector(floats);

        IVector vec3 = vec1 + vec2;

        for (int i = 0; i < floats.Length; i++)
        {
            Assert.Equal(2 * floats[i], vec3.ToArray()[i]);
        }
    }

    [Fact]
    public void SubtractionBehavesWell()
    {
        float[] floats = { 1.0f, 2.0f, 3.0f, 4.0f };

        IVector vec1 = new Vector(floats);

        IVector vec2 = new Vector(floats);

        IVector vec3 = vec1 - vec2;

        for (int i = 0; i < floats.Length; i++)
        {
            Assert.Equal(0.0f, vec3.ToArray()[i]);
        }
    }

    [Fact]
    public void MultiplicationLeftVectorBehavesWell()
    {
        float[] floats = { 1.0f, 2.0f, 3.0f, 4.0f };

        IVector vec1 = new Vector(floats);

        IVector vec2 = vec1 * 3.0f;

        for(int i = 0; i < floats.Length; i++)
        {
            Assert.Equal(floats[i] * 3.0f, vec2.ToArray()[i]);
        }
    }

    [Fact]
    public void MultiplicationRightVectorBehavesWell()
    {
        float[] floats = { 1.0f, 2.0f, 3.0f, 4.0f };


        IVector vec1 = new Vector(floats);

        IVector vec2 = -1.0f * vec1;

        for(int i = 0; i < floats.Length; i++)
        {
            Assert.Equal(floats[i] * -1.0f, vec2.ToArray()[i]);
        }
    }

    [Fact]
    public void DotProductBehavesWell()
    {
        float[] floats = { 1.0f, 2.0f, 3.0f, 4.0f };
        float[] floats1 = { -3.0f, 2.0f, 1.0f, 0.0f };

        IVector vec1 = new Vector(floats);
        IVector vec2 = new Vector(floats1);

        Assert.Equal(4.0f, vec1 * vec2);
    }

    [Fact]
    public void EqualsCanCompareVectors()
    {
        float[] floats = { 1.0f, 2.0f, 3.0f, 4.0f };
        IVector vec1 = new Vector(floats);
        IVector vec2 = new Vector(vec1);

        Assert.True(vec1.Equals(vec2));
    }

    [Fact]
    public void NullIsNotVector()
    {
        float[] floats = { 1.0f, 2.0f, 3.0f, 4.0f };
        IVector vec1 = new Vector(floats);

        Assert.False(vec1.Equals(null));
    }

    [Fact]
    public void EqualsReturnsFalseWithOtherObjects()
    {
        float[] floats = { 1.0f };
        IVector vec1 = new Vector(floats);

        Assert.False(vec1.Equals(1.0f));
    }

    [Fact]
    public void VectorsOfDifferentSizeIsNotEqual()
    {
        IVector vec1 = new Vector(2);
        IVector vec2 = new Vector(3);

        Assert.False(vec1.Equals(vec2));
    }

    [Fact]
    public void VectorsWithDifferentComponentsAreNotEqual()
    {
        float[] f = { 1.0f, 2.0f };

        IVector vec1 = new Vector(2);
        IVector vec2 = new Vector(f);

        Assert.False(vec1.Equals(vec2));
    }

    [Fact]
    public void GetHashCodeWorks()
    {
        float[] f = { 1.0f, 2.0f };
        IVector vec1 = new Vector(f);
        IVector vec2 = new Vector(f);

        Assert.True(vec1.GetHashCode() == vec2.GetHashCode());
    }

    [Fact]
    public void MatrixVectorMultiplicationWorks()
    {
        float[,] floats = { { 4.0f, 5.0f, 6.0f },
                            { 7.0f, 8.0f, 9.0f }
        };

        float[] floats2 = { 1.2f, 2.3f, 3.4f };

        IMatrix M = new Matrix(floats);
        IVector v = new Vector(floats2);

        IVector res = M * v;
        IVector expected = new Vector(new float[] { 36.7f, 57.4f });

        Assert.True(expected.Equals(res));
    }

    [Fact]
    public void VectorMatrixMultiplicationWorks()
    {
        float[,] floats = { { 4.0f, 5.0f, 6.0f },
                            { 7.0f, 8.0f, 9.0f }
        };

        float[] floats2 = { 1.2f, 2.3f, 3.4f };

        IMatrix M = new Matrix(floats);
        IVector v = new Vector(floats2);

        IVector res = v * M;
        IVector expected = new Vector(new float[] { 36.7f, 57.4f });

        Assert.True(expected.Equals(res));
    }

    [Fact]
    public void VectorNormPropertyBehavesWell()
    {
        IVector v = new Vector(new float[] { 1, 2, 3, 4 });

        Assert.Equal(MathF.Sqrt(30.0f), v.Norm);
    }
}
