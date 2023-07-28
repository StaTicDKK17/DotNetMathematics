namespace Mathematics;

public class MathFunctions
{
    public static long Fac(int x)
    {
        long res = 1;

        for (int i = 2; i <= x; i++)
        {
            res *= i;
        }

        return res;
    }
}
