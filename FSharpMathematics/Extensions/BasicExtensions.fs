module BasicExtensions

open FSharpMathematics.Core
open System.Diagnostics.Contracts

type BasicOps = class
  /// <summary>
  /// This function creates an augmented Matrix given a Matrix A, and a
  /// right-hand side Vector v.
  /// </summary>
  ///
  /// <remarks>
  /// See page 12 in "Linear Algebra for Engineers and Scientists"
  /// by K. Hardy.
  /// This implementation is provided for you.
  /// </remarks>
  ///
  /// <param name="A">An M-by-N Matrix.</param>
  /// <param name="v">An M-size Vector.</param>
  ///
  /// <returns>An M-by-(N+1) augmented Matrix [A | v].</returns>
  static member AugmentRight (A : Matrix) (v : Vector) : Matrix =
    Contract.Requires(A.M_Rows = v.Size)
    let m_rows = A.M_Rows
    let n_cols = A.N_Cols

    let retval = Array2D.zeroCreate m_rows (n_cols + 1)

    for i in 0..m_rows-1 do
        for j in 0..n_cols-1 do
            retval.[i, j] <- A.[i, j]
        retval.[i, n_cols] <- v.[i]
    Matrix retval

  /// <summary>
  /// This function computes the Matrix-Vector product of a Matrix A,
  /// and a column Vector v.
  /// </summary>
  ///
  /// <remarks>
  /// See page 68 in "Linear Algebra for Engineers and Scientists"
  /// by K. Hardy.
  /// </remarks>
  ///
  /// <param name="A">An M-by-N Matrix.</param>
  /// <param name="v">An N-size Vector.</param>
  ///
  /// <returns>An M-size Vector b such that b = A * v.</returns>
  static member MatVecProduct (A : Matrix) (v : Vector) : Vector =
    Contract.Requires(A.N_Cols = v.Size)
    let mutable b =  Vector(A.M_Rows)

    for i in 0.. A.M_Rows-1 do
      b.Item(i) <- (0.0, A.Row(i).ToArray(), v.ToArray()) |||> 
                    Array.fold2 (fun acc a b -> acc + a * b)
    b

  /// <summary>
  /// This function computes the Matrix product of two given matrices
  /// A and B.
  /// </summary>
  ///
  /// <remarks>
  /// See page 58 in "Linear Algebra for Engineers and Scientists"
  /// by K. Hardy.
  /// </remarls>
  ///
  /// <param name="A">An M-by-N Matrix.</param>
  /// <param name="B">An N-by-P Matrix.</param>
  ///
  /// <returns>The M-by-P Matrix A * B.</returns>
  static member MatrixProduct (A : Matrix) (B : Matrix) : Matrix =
    Contract.Requires(A.N_Cols = B.M_Rows)
    let mutable C = Matrix(A.M_Rows, B.N_Cols)

    for i in 0..A.M_Rows-1 do
        for j in 0..B.N_Cols-1 do
            C.Item (i, j) <- (0.0, A.Row(i).ToArray(), B.Column(j).ToArray()) |||> 
                Array.fold2 (fun acc a b -> acc + a * b)
    C

  /// <summary>
  /// This function computes the transpose of a given Matrix.
  /// </summary>
  ///
  /// <remarks>
  /// See page 69 in "Linear Algebra for Engineers and Scientists"
  /// by K. Hardy.
  /// </remarks>
  ///
  /// <param name="A">An M-by-N Matrix.</param>
  ///
  /// <returns>The N-by-M Matrix B such that B = A^T.</returns>
  static member Transpose (A : Matrix) : Matrix =
    let mutable B =  Matrix(A.N_Cols, A.M_Rows)

    for i in 0..A.M_Rows-1 do
        for j in 0..A.N_Cols-1 do
            B.Item (j, i) <- A.Item (i, j)
    B

  /// <summary>
  /// This function computes the Euclidean Vector norm of a given
  /// Vector.
  /// </summary>
  ///
  /// <remarks>
  /// See page 197 in "Linear Algebra for Engineers and Scientists"
  /// by K. Hardy.
  ///
  /// Impossible to achieve full branch coverage. It is practically fully covered
  /// </remarks>
  ///
  /// <param name="v">An N-dimensional Vector.</param>
  ///
  /// <returns>The Euclidean norm of the Vector.</returns>
  static member VectorNorm (v : Vector) : float =
    (v.ToArray()) |> Array.map (fun a -> a ** 2.0) |> Array.sum |> sqrt

end