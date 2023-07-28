namespace MathematicsTests;

using Mathematics;

public class MathFunctionsTests
{
    [Fact]
    public void TestFacSimple()
    {
        Assert.True(MathFunctions.Fac(1) == 1);
        Assert.True(MathFunctions.Fac(0) == 1);

        Assert.True(MathFunctions.Fac(3) == 6);
    }
}
