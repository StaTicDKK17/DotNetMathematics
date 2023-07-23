using Mathematics.Vectors;

namespace Mathematics.Matrices;

public interface IMatrix
{
    int MRows { get; }
    int NCols { get; }

    (int, int) Size { get; }

    /// <summary>
    /// 0-Indexed - Sets the entry at (i, j) to value
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    /// <param name="value"></param>
    void SetItem0I(int i, int j, float value);

    /// <summary>
    /// 1-Indexed - Sets the entry at (i, j) to value
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    /// <param name="value"></param>
    void SetItem(int i, int j, float value);

    /// <summary>
    /// 1-Indexed - Sets the ith row to v in the matrix
    /// </summary>
    /// <param name="i"></param>
    /// <param name="v"></param>
    void SetRow(int i, IVector v);

    /// <summary>
    /// 1-Indexed - transforms the instance multiplying each entry in the ith row by the multiplier
    /// </summary>
    /// <param name="row"></param>
    /// <param name="multiplier"></param>
    void ElemetaryRowScaling(int row, float multiplier);

    /// <summary>
    /// 1-Indexed - Transforms the instance, doing a row replacement where the form is
    /// row = row + multiplier * row2
    /// </summary>
    /// <param name="row"></param>
    /// <param name="multiplier"></param>
    /// <param name="row2"></param>
    void ElementaryRowReplacement(int row, float multiplier, int row2);

    /// <summary>
    /// 1-Indexed - Interchanges the ith and jth row
    /// </summary>
    /// <param name="row1"></param>
    /// <param name="row2"></param>
    void ElementaryRowInterchange(int row1, int row2);

    /// <returns>true if matrix is symmetrix, false otherwise</returns>
    bool IsSymmetric();

    /// <returns>true if the matrix is skew-symmetric, false otherwise</returns>
    bool IsSkewSymmetric();

    /// <summary>
    /// Returns the array in a 2-dimensional array representation
    /// </summary>
    float[][] ToArray();

    /// <summary>
    /// 1-Indexed - returns the ith, jth item in a matrix 
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    float Item(int i, int j);

    /// <summary>
    /// 0-Indexed - Returns the ith, jth item in a matrix
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    float Item0I(int i, int j);

    /// <summary>
    /// 1-Indexed - Gets the ith row in the matrix
    /// </summary>
    /// <param name="i"></param>
    /// <returns>A vector containing the entries in the ith row</returns>
    IVector Row(int i);

    /// <summary>
    /// 1-Indexed - returns the jth column of the matrix
    /// </summary>
    /// <param name="j"></param>
    IVector Column(int j);

    /// <param name="M"></param>
    /// <returns>The transpose matrix of M</returns>
    static IMatrix Transpose(IMatrix M)
    {
        return Matrix.Transpose((Matrix)M);
    }

    /// <summary>
    /// Creates an argumented matrix with the last column being v
    /// </summary>
    /// <param name="A"></param>
    /// <param name="v"></param>
    /// <returns></returns>
    static IMatrix ArgumentRight(IMatrix A, IVector v)
    {
        return Matrix.ArgumentRight((Matrix)A, v);
    }
    
    static IMatrix operator +(IMatrix xs, IMatrix ys)
    {
        return (Matrix)xs + (Matrix)ys;
    }

    static IMatrix operator -(IMatrix xs, IMatrix ys)
    {
        return (Matrix)xs - (Matrix)ys;
    }

    static IMatrix operator *(IMatrix v, float y)
    {
        return (Matrix)v * y;
    }

    static IMatrix operator *(float x, IMatrix v)
    {
        return x * (Matrix)v;
    }

    static IMatrix operator *(IMatrix a, IMatrix v)
    {
        return (Matrix)a * (Matrix)v;
    }
}
