namespace FSharpMathematics

open Mathematics.Matrices

module Say =
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
    let MatrixProduct (A : Matrix) (B : Matrix) : Matrix =
      let mutable C = Matrix(A.M_Rows, B.N_Cols)

      for i in 0..A.M_Rows-1 do
          for j in 0..B.N_Cols-1 do
              C.SetItem(i+1, j+1, (0.0f, A.Row(i).ToArray(), B.Column(j).ToArray()) |||> 
                  Array.fold2 (fun acc a b -> acc + a * b))
              
      C