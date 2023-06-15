namespace MathematicsTests;

using Mathematics;

public class SetTests
{
    [Fact]
    public void SetCreationWorks()
    {
        ISet<object> mySet = new Set<object>();

        Assert.Equal(0, mySet.Size);
    }

    [Fact]
    public void SetCreationWithCollectionWorks()
    {
        int[] ints = { 1, 2, 3 };
        ISet<int> mySet = new Set<int>(ints);

        Assert.Equal(ints.Length, mySet.Size);
    }

    [Fact]
    public void SetIntersectionWithNoCommonElementsHasSizeZero()
    {
        int[] ints1 = { 1, 2, 3 };
        int[] ints2 = { 4, 5, 6 };

        ISet<int> set2 = new Set<int>(ints2);
        ISet<int> set1 = new Set<int>(ints1);

        ISet<int> set3 = set1.Intersection(set2);
        Assert.Equal(0, set3.Size);
    }

    [Fact]
    public void SetIntersectionWithCommonElementsWorks()
    {
        int[] ints1 = { 1, 2, 3 };
        int[] ints2 = { 2, 3, 4 };

        ISet<int> set1 = new Set<int>(ints1);
        ISet<int> set2 = new Set<int>(ints2);

        ISet<int> set3 = set1.Intersection(set2);

        Assert.Equal(2, set3.Size);
    }

    [Fact]
    public void SetUnionWorks()
    {
        int[] ints1 = { 1, 2, 3 };
        ISet<int> set1 = new Set<int>(ints1);
        ISet<int> set2 = new Set<int>(ints1);

        ISet<int> set3 = set1.Union(set2);

        Assert.Equal(3, set3.Size);
    }

    [Fact]
    public void SetUnionWorksWithDifferentElements()
    {
        int[] ints1 = { 1, 2, 3 };
        int[] ints2 = { 2, 3, 4 };

        ISet<int> set1 = new Set<int>(ints1);
        ISet<int> set2 = new Set<int>(ints2);

        ISet<int> set3 = set1.Union(set2);

        Assert.Equal(4, set3.Size);
    }

    [Fact]
    public void SetCopyConstructorBehavesWell()
    {
        int[] ints = { 1, 2, 3, 4 };

        ISet<int> set1 = new Set<int>(ints);
        ISet<int> set2 = new Set<int>(set1);

        Assert.Equal(0, set1.Minus(set2).Size);
    }

    [Fact]
    public void SetContainsFindsContainedElement()
    {
        int[] ints = { 1, 2, 3, 4 };

        ISet<int> set1 = new Set<int>(ints);

        Assert.True(set1.Contains(3));
    }

    [Fact]
    public void SetContainsDoesNotFindNonContainedElement()
    {
        int[] ints = { 0, 1, 2 };

        ISet<int> set1 = new Set<int>(ints);

        Assert.False(set1.Contains(10));
    }

    [Fact]
    public void SetAddElementWorks()
    {
        int[] ints = { 0 };

        ISet<int> set1 = new Set<int>(ints);
        set1.AddElement(100);

        Assert.Equal(2, set1.Size);
    }

    [Fact]
    public void SetMinusWorksAsExpected()
    {
        int[] ints1 = { 1, 2, 3, 4, 5 };
        int[] ints2 = { 3, 4, 5, 6, 7 };

        ISet<int> set1 = new Set<int>(ints1);
        ISet<int> set2 = new Set<int>(ints2);

        Assert.Equal(2, set1.Minus(set2).Size);
    }

    [Fact]
    public void SetSymmetricDifferenceWorks()
    {
        int[] ints1 = { 1, 2, 3, 4, 5 };
        int[] ints2 = { 3, 4, 5, 6, 7 };

        ISet<int> set1 = new Set<int>(ints1);
        ISet<int> set2 = new Set<int>(ints2);

        Assert.Equal(4, set1.SymmetricDifference(set2).Size);
    }
}