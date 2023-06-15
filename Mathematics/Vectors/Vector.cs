namespace Mathematics.Vectors;

public class Vector : IVector
{
    private float[] xs;

    public int Size => xs.Length;

    public Vector(int n)
    {
        xs = new float[n];
    }

    public Vector(float[] xs)
    {
        this.xs = xs;
    }

    public Vector(IVector v)
    {
        xs = new float[v.Size];

        for (int i = 0; i < v.Size; i++)
            xs[i] = v.ToArray()[i];

    }

    public float Item(int i) => xs[i - 1];
    public float Item0I(int i) => xs[i];

    public void SetItem0I(int i, float value)
    {
        xs[i] = value;
    }

    public void SetItem(int i, float value)
    {
        xs[i - 1] = value;
    }

    public float[] ToArray()
    {
        return xs;
    }

    public static IVector operator *(Vector v, float y)
    {
        IVector retval = new Vector(v.Size);

        for (int i = 0; i < v.Size; i++)
            retval.SetItem0I(i, v.Item0I(i) * y);

        return retval;
    }

    public static IVector operator *(float x, Vector v)
    {
        IVector retval = new Vector(v.Size);

        for (int i = 0; i < v.Size; i++)
            retval.SetItem0I(i, v.Item0I(i) * x);

        return retval;
    }

    public static IVector operator +(Vector xs, Vector ys)
    {
        IVector retval = new Vector(Math.Min(xs.Size, ys.Size));

        for (int i = 0; i < Math.Min(xs.Size, ys.Size); i++)
            retval.SetItem0I(i, xs.Item0I(i) + ys.Item0I(i));

        return retval;
    }

    public static IVector operator -(Vector xs, Vector ys)
    {
        IVector retval = new Vector(Math.Min(xs.Size, ys.Size));

        for (int i = 0; i < Math.Min(xs.Size, ys.Size); i++)
            retval.SetItem0I(i, xs.Item0I(i) - ys.Item0I(i));

        return retval;
    }

    public static float operator *(Vector xs, Vector ys)
    {
        float retval = 0.0f;

        for (int i = 0; i < Math.Min(xs.Size, ys.Size); i++)
            retval += xs.Item0I(i) * ys.Item0I(i);

        return retval;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Vector)
        {
            Vector retval = (Vector)obj;

            if (retval.Size != Size) return false;

            for(int i = 0; i < retval.Size; i++)
            {
                if (retval.Item0I(i) != Item0I(i))
                    return false;
            }
            return true;
        }
        return false;
    }
}
