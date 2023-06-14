namespace Mathematics.Vectors;

public interface IVector
{
    float[] ToArray();
    float Item(int i);
    void SetItem(int i, float value);

    int Size { get; }
}
