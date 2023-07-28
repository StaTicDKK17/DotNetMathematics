namespace Mathematics;

public class MathFunctions
{
    public static long Fac(long x)
    {
        int res = 1;

        for (int i = 2; i <= x; i++)
        {
            res *= i;
        }

        return res;
    }
}
