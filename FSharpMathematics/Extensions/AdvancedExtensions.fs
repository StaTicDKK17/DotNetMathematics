module AdvancedExtensions

open FSharpMathematics.Core
open System.Diagnostics.Contracts
open BasicExtensions

type AdvancedOps = class

    /// <summary>
    ///     This function creates the square submatrix given a square matrix as
    ///     well as row and column indices to remove from it.
    /// </summary>
    /// <remarks>
    ///     See page 246-247 in "Linear Algebra for Engineers and Scientists"
    ///     by K. Hardy.
    /// </remarks>
    /// <param name="A">An N-by-N matrix.</param>
    /// <param name="i">The index of the row to remove.</param>
    /// <param name="j">The index of the column to remove.</param>
    /// <returns>The resulting (N - 1)-by-(N - 1) submatrix.</returns>
    static member SquareSubMatrix (A : Matrix) (i : int) (j : int) : Matrix =
       Contract.Requires(i >= 0 && i < A.M_Rows)
       Contract.Requires(j >= 0 && j < A.N_Cols)

       let mutable m = Matrix(A.M_Rows-1, A.N_Cols-1)

       for row in 0..A.M_Rows-1 do
           if row <> i then
               for col in 0..A.N_Cols-1 do
                   if col <> j then
                       if row > i && col > j then
                           m.Item(row-1, col-1) <- A.Item(row, col)
                       else if row > i && col < j then
                           m.Item(row-1, col) <- A.Item(row, col)
                       else if row < i && col < j then
                           m.Item(row, col) <- A.Item(row, col)
                       else if row < i && col > j then
                           m.Item(row, col-1) <- A.Item(row, col)
       m

    static member CalcualteCoFactor (A : Matrix) (i : int) (j : int) : float = 
        Contract.Requires(i >= 0 && i < A.M_Rows)
        Contract.Requires(j >= 0 && j < A.N_Cols)

        float (pown -1 (i+j)) * AdvancedOps.Determinant A
        
    /// <summary>
    ///     This function computes the determinant of a given square matrix.
    /// </summary>
    /// <remarks>
    ///     See page 247 in "Linear Algebra for Engineers and Scientists"
    ///     by K. Hardy.
    /// </remarks>
    /// <remarks>
    ///     Hint: Use SquareSubMatrix.
    /// </remarks>
    /// <param name="A">An N-by-N matrix.</param>
    /// <returns>The determinant of the matrix</returns>
    static member Determinant (A : Matrix) : float =
        let mutable res = 0.0

        if A.M_Rows = 1 && A.N_Cols = 1 then
            res <- A.Item(0, 0)
        else
            for i in 0..A.N_Cols-1 do
                let M = AdvancedOps.SquareSubMatrix A 0 i
                let coFactor = AdvancedOps.CalcualteCoFactor M 0 i

                res <- res + A.Item(0, i) * coFactor

        res

    /// <summary>
    ///     This function copies Vector 'v' as a column of matrix 'A'
    ///     at column position j.
    /// </summary>
    /// <param name="A">
    ///     An M-by-N matrix.
    /// </param>
    /// <param name="v">
    ///     Vector objects that must be copied in A.
    /// </param>
    /// <param name="j">
    ///     column number.
    /// </param>
    /// <returns>
    ///     An M-by-N matrix after modification.
    /// </returns>
    /// <exception cref="ArgumentException"></exception>
    static member SetColumn (A : Matrix) (v : Vector) (j : int) =
        Contract.Requires(j >= 0 && j < A.N_Cols)
        Contract.Requires(A.M_Rows = v.Size)
        let mutable M = Matrix(A)

        for i in 0..M.M_Rows-1 do
            M.Item(i, j) <- v.Item(i)

        M
    
    /// <summary>
    ///     This function computes the Gram-Schmidt process on a given matrix.
    /// </summary>
    /// <remarks>
    ///     See page 229 in "Linear Algebra for Engineers and Scientists"
    ///     by K. Hardy.
    /// </remarks>
    /// <param name="A">
    ///     An M-by-N matrix. All columns are implicitly assumed linear
    ///     independent.
    /// </param>
    /// <returns>
    ///     A tuple (Q,R) where Q is a M-by-N orthonormal matrix and R is an
    ///     N-by-N upper triangular matrix.
    /// </returns>
    static member GramSchmidt (A : Matrix) : Matrix * Matrix =
        let mutable Q = Matrix(A.M_Rows, A.N_Cols)
        let mutable R = Matrix(A.N_Cols, A.N_Cols)

        for j in 0..A.N_Cols-1 do
            let mutable q_j = A.Column(j)
            Q <- AdvancedOps.SetColumn Q q_j (j)
            for i in 0..j-1 do
                R.Item(i, j) <- Q.Column(i) * A.Column(j)
                q_j <- q_j - R.Item(i, j) * Q.Column(i)
            R.Item(j, j) <- BasicOps.VectorNorm q_j
            if q_j <> Vector(q_j.Size) then
                q_j <- q_j * (1.0/R.Item(j, j))
                Q <- AdvancedOps.SetColumn Q q_j (j)
        (Q, R)

    
end