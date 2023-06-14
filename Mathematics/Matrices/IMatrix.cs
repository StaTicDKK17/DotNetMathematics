using Mathematics.Vectors;

namespace Mathematics.Matrices;

public interface IMatrix
{
    float[,] ToArray();
    float Item(int i, int j);
    void SetItem(int i, int j, float value);
    Vector Row(int i);
    Vector Column(int j);

    int M_Rows { get; }
    int N_Cols { get; }



    (int, int) Size { get; }
}
