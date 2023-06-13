namespace MathematicsTests;

using Mathematics;
using NuGet.Frameworks;

public class SetTests
{
    [Fact]
    public void SetCreationWorks()
    {
        Set<object> mySet = new();

        Assert.Equal(0, mySet.Size);
    }

    [Fact]
    public void SetCreationWithCollectionWorks()
    {
        int[] ints = { 1, 2, 3 };
        Set<int> mySet = new(ints);

        Assert.Equal(ints.Length, mySet.Size);
    }

    [Fact]
    public void SetIntersectionWithNoCommonElementsHasSizeZero()
    {
        int[] ints1 = { 1, 2, 3 };
        int[] ints2 = { 4, 5, 6 };

        Set<int> set2 = new(ints2);
        Set<int> set1 = new(ints1);

        Set<int> set3 = set1.Intersection(set2);
        Assert.Equal(0, set3.Size);
    }

    [Fact]
    public void SetIntersectionWithCommonElementsWorks()
    {
        int[] ints1 = { 1, 2, 3 };
        int[] ints2 = { 2, 3, 4 };

        Set<int> set1 = new (ints1);
        Set<int> set2 = new (ints2);

        Set<int> set3 = set1.Intersection(set2);

        Assert.Equal(2, set3.Size);
    }

    [Fact]
    public void SetUnionWorks()
    {
        int[] ints1 = { 1, 2, 3 };
        Set<int> set1 = new (ints1);
        Set<int> set2 = new (ints1);

        Set<int> set3 = set1.Union(set2);

        Assert.Equal(3, set3.Size);
    }

    [Fact]
    public void SetUnionWorksWithDifferentElements()
    {
        int[] ints1 = { 1, 2, 3 };
        int[] ints2 = { 2, 3, 4 };

        Set<int> set1 = new (ints1);
        Set<int> set2 = new (ints2);

        Set<int> set3 = set1.Union(set2);

        Assert.Equal(4, set3.Size);
    }

    [Fact]
    public void SetCopyConstructorBehavesWell()
    {
        int[] ints = { 1, 2, 3, 4 };

        Set<int> set1 = new(ints);
        Set<int> set2 = new(set1);

        Assert.Equal(0, set1.Minus(set2).Size);
    }

    [Fact]
    public void SetContainsFindsContainedElement()
    {
        int[] ints = { 1, 2, 3, 4 };

        Set<int> set1 = new(ints);

        Assert.True(set1.Contains(3));
    }

    [Fact]
    public void SetContainsDoesNotFindNonContainedElement()
    {
        int[] ints = { 0, 1, 2 };

        Set<int> set1 = new(ints);

        Assert.False(set1.Contains(10));
    }

    [Fact]
    public void SetAddElementWorks()
    {
        int[] ints = { 0 };

        Set<int> set1 = new(ints);
        set1.AddElement(100);

        Assert.Equal(2, set1.Size);
    }

    [Fact]
    public void SetMinusWorksAsExpected()
    {
        int[] ints1 = { 1, 2, 3, 4, 5 };
        int[] ints2 = { 3, 4, 5, 6, 7 };

        Set<int> set1 = new(ints1);
        Set<int> set2 = new(ints2);

        Assert.Equal(2, set1.Minus(set2).Size);
    }

    [Fact]
    public void SetSymmetricDifferenceWorks()
    {
        int[] ints1 = { 1, 2, 3, 4, 5 };
        int[] ints2 = { 3, 4, 5, 6, 7 };

        Set<int> set1 = new(ints1);
        Set<int> set2 = new(ints2);

        Assert.Equal(4, set1.SymmetricDifference(set2).Size);
    }
}