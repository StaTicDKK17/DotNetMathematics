namespace Mathematics.Vectors;

public interface IVector
{
    float[] ToArray();
    float Item(int i);
    public float Item0I(int i);
    void SetItem(int i, float value);
    void SetItem0I(int i, float value);

    public static IVector operator *(IVector v, float y)
    {
        return (IVector)((Vector)v * y);
    }

    public static IVector operator *(float x, IVector v)
    {
        return (IVector)(x * (Vector)v);
    }

    public static IVector operator +(IVector xs, IVector ys)
    {
        return (IVector)((Vector)xs + (Vector)ys);
    }

    public static IVector operator -(IVector xs, IVector ys)
    {
        return (IVector)((Vector)xs - (Vector)ys);
    }

    public static float operator *(IVector xs, IVector ys)
    {
        return (Vector)xs * (Vector)ys;
    }

    int Size { get; }
}
