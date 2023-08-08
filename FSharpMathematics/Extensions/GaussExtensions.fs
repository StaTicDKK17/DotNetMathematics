module GaussExtensions

// LinalgDat23
// Authors: Francois Lauze

open System
open FSharpMathematics.Core
open System.Diagnostics.Contracts

type GaussOps = class
    /// <summary>
    /// This function computes the elementary row replacement operation on
    /// the given matrix.
    /// </summary>
    ///
    /// <remarks>
    /// Note that we add the row (as in the lectures) instead of subtracting
    /// the row (as in the textbook).
    /// </remarks>
    ///
    /// <param name="A">
    /// An M-by-N matrix to perform the elementary row operation on.
    /// </param>
    /// <param name="i">
    /// The index of the row to replace.
    /// </param>
    /// <param name="m">
    /// The multiple of row j to add to row i.
    /// </param>
    /// <param name="j">
    /// The index of the row whose mutiple is added to row i.
    /// </param>
    ///
    /// <returns>
    /// The resulting M-by-N matrix after having performed the elementary
    /// row operation.
    /// </returns>
    static member ElementaryRowReplacement (A : Matrix) (i : int) (m : float) (j : int) : Matrix =
        Contract.Requires(i >= 0 && i < A.M_Rows)
        Contract.Requires(j >= 0 && j < A.N_Cols)
        let new_matrix = Matrix(A.M_Rows, A.N_Cols)

        for row in 0..A.M_Rows-1 do
            if row = i then
                let row_vec = Array.map2 (fun x y -> x + m * y) (A.Row(i).ToArray()) (A.Row(j).ToArray())

                for col in 0..A.N_Cols-1 do
                    new_matrix.Item(row, col) <- row_vec[col]
            else
                for col in 0..A.N_Cols-1 do
                    new_matrix.Item(row, col) <- A.Item(row, col)
        new_matrix
    /// <summary>
    /// This function computes the elementary row interchange operation on
    /// the given matrix.
    /// </summary>
    ///
    /// <param name="A">
    /// An M-by-N matrix to perform the elementary row operation on.
    /// </param>
    /// <param name="i">
    /// The index of the first row of the rows to interchange.
    /// </param>
    /// <param name="j">
    /// The index of the second row of the rows to interchange.
    /// </param>
    ///
    /// <returns>
    /// The resulting M-by-N matrix after having performed the elementary
    /// row operation.
    /// </returns>
    static member ElementaryRowInterchange (A : Matrix) (i : int) (j : int) : Matrix =
        Contract.Requires(i >= 0 && i < A.M_Rows)
        Contract.Requires(j >= 0 && j < A.N_Cols)

        let mutable new_matrix = Matrix(A.M_Rows, A.N_Cols)

        let temp_col = new_matrix.Column(i)

        for k in 0..A.M_Rows-1 do
            for l in 0..A.N_Cols-1 do
                if k = i then
                    new_matrix.Item(k, l) <- A.Item(j, l)
                else if k = j then
                    new_matrix.Item(k, l) <- A.Item(i, l)
                else
                    new_matrix.Item(k, l) <- A.Item(k, l)

        new_matrix

    /// <summary>
    /// This function computes the elementary row scaling operation on the
    /// given matrix.
    /// </summary>
    ///
    /// <param name="A">
    /// An M-by-N matrix to perform the elementary row operation on.
    /// </param>
    /// <param name="i">The index of the row to scale.</param>
    /// <param name="c">The value to scale the row by.</param>
    ///
    /// <returns>
    /// The resulting M-by-N matrix after having performed the elementary
    /// row operation.
    /// </returns>
    static member ElementaryRowScaling (A : Matrix) (i : int) (c : float) : Matrix =
        Contract.Requires(i >= 0 && i < A.M_Rows)
        Contract.Requires(c <> 0)
        let new_matrix = Matrix(A.M_Rows, A.N_Cols)

        for k in 0..A.M_Rows-1 do
            if k = i then
                for l in 0..A.N_Cols-1 do
                    new_matrix.Item(k, l) <- A.Item(k, l) * c
            else
                for l in 0..A.N_Cols-1 do
                    new_matrix.Item(k, l) <- A.Item(k, l)

        new_matrix
    
    static member CleanMatrix (M : Matrix) : Matrix =
        let tolerance = 0.0000000000001
        let mutable new_matrix = Matrix(M)

        for i in 0..M.M_Rows-1 do
            for j in 0..M.N_Cols-1 do
                if (Math.Abs(new_matrix.Item(i, j)) < tolerance) then
                    new_matrix.Item(i, j) <- 0.0

        new_matrix

    static member DetermineRowFactor (factor: float) (item: float) (pivot: float) : float =
        if (item > 0.0 && pivot > 0.0) || (item < 0.0 && pivot < 0.0) then
            -factor
        else 
            factor

    static member EliminateBelowPivot (M : Matrix) (tolerance: float) (top_row: int) (col: int) : Matrix =
        Contract.Requires(top_row >= 0 && top_row < M.M_Rows)
        Contract.Requires(col >= 0 && col < M.N_Cols)
        let mutable new_matrix = Matrix(M)

        for k in top_row+1..new_matrix.M_Rows-1 do
            let item = new_matrix.Item(k, col)
            if Math.Abs(item) > tolerance then
                // find row factor
                let mutable value = Math.Abs(item / new_matrix.Item(top_row, col))
                value <- GaussOps.DetermineRowFactor value item (new_matrix.Item(top_row, col))
   
                new_matrix <- GaussOps.ElementaryRowReplacement new_matrix k value top_row
        new_matrix

    static member EliminateAbovePivot(M : Matrix) (tolerance: float) (top_col: int) (row: int) : Matrix =
        Contract.Requires(row >= 0 && row < M.M_Rows)
        Contract.Requires(top_col >= 0 && top_col < M.N_Cols)

        let mutable new_matrix = Matrix(M)

        for other_row in 0..row-1 do
            let other_row = row-1 - other_row
            let item = new_matrix.Item(other_row, top_col)
            if Math.Abs(item) > tolerance then
                // find row factor
                let mutable value = Math.Abs(item / new_matrix.Item(row, top_col))
                value <- GaussOps.DetermineRowFactor value item (new_matrix.Item(row, top_col))
                   
                // call rowReplacement
                new_matrix <- GaussOps.ElementaryRowReplacement new_matrix other_row value row

        new_matrix

    /// <summary>
    /// This function executes the forward reduction algorithm provided in
    /// the assignment text to achieve row Echelon form of a given
    /// augmented matrix.
    /// </summary>
    ///
    /// <param name="A">
    /// An M-by-N matrix, augmented (or not).
    /// </param>
    ///
    /// <returns>
    /// An M-by-N matrix that is the row Echelon form.
    /// </returns>
    static member ForwardReduction (M : Matrix) : Matrix =

        // One does simply not compare a float number with 0.0
        // A not-so-scientific way, but quite sufficient to this course,
        // is to have a threshold value, which is defined as below.

        let tolerance = 0.000000001
        
        let mutable new_matrix = Matrix(M)

        let mutable top_row = 0

        for i in 0..new_matrix.N_Cols-1 do
            let column = new_matrix.Column(i)
            let mutable Break = false
            for j in top_row..column.Size-1 do
                // Pivot point found!
                if Math.Abs(column.Item(j)) > tolerance && Break <> true then
                    new_matrix <- GaussOps.ElementaryRowInterchange new_matrix j top_row

                    // eliminate all non zero values below pivot point
                    new_matrix <- GaussOps.EliminateBelowPivot new_matrix tolerance top_row i
                    
                    top_row <- top_row + 1
                    Break <- true
                    new_matrix <- GaussOps.CleanMatrix new_matrix               

        new_matrix

    /// <summary>
    /// This function executes the backward reduction algorithm provided in
    /// the assignment text given an augmented matrix in row Echelon form.
    /// </summary>
    ///
    /// <param name="A">
    /// An M-by-N augmented matrix in row Echelon form.
    /// </param>
    ///
    /// <returns>
    /// The resulting M-by-N matrix after executing the algorithm.
    /// </returns>
    static member BackwardReduction (A : Matrix) : Matrix =
        let tolerance = 0.00000001
        let mutable new_matrix = Matrix(A)

        let mutable top_col = new_matrix.N_Cols-1;

        for row in 0..new_matrix.M_Rows-1 do
            let row = new_matrix.M_Rows-1 - row
            let mutable Break = false
            for col in 0..top_col do
                if Math.Abs(new_matrix.Item(row, col)) > tolerance && Break <> true then
                    new_matrix <- GaussOps.ElementaryRowScaling new_matrix row (1.0 / new_matrix.Item(row, col))

                    new_matrix <- GaussOps.EliminateAbovePivot new_matrix tolerance col row
                    
                    Break <- true
                    top_col <- top_col - 1
                    new_matrix <- GaussOps.CleanMatrix new_matrix     

        new_matrix

    static member ArgumentMatrix (A: Matrix) (b: Vector) : Matrix = 
        let mutable new_matrix = Matrix(A.M_Rows, A.N_Cols + 1)
        
        for i in 0..A.M_Rows-1 do
            for j in 0..A.N_Cols-1 do
                new_matrix.Item(i, j) <- A.Item(i, j)
            new_matrix.Item(i, A.N_Cols) <- b.Item(i)
        new_matrix

    /// <summary>
    /// This function performs Gauss elimination of a linear system
    /// given in matrix form by a coefficient matrix and a right hand side
    /// vector. It is assumed that the corresponding linear system is
    /// consistent and has exactly one solution.
    /// </summary>
    ///
    /// <remarks>
    /// Hint: Combine ForwardReduction and BackwardReduction.
    /// </remarks>
    ///
    /// <param name="A">An M-by-N Matrix.</param>
    /// <param name="b">An M-size Vector.</param>
    ///
    /// <returns>The N-sized vector x such that A * x = b.</returns>
    static member GaussElimination (A : Matrix) (b : Vector) : Vector =
        Contract.Requires(A.M_Rows = b.Size)
        let mutable new_matrix = GaussOps.ArgumentMatrix A b

        new_matrix <- GaussOps.ForwardReduction new_matrix
        new_matrix <- GaussOps.BackwardReduction new_matrix

        Vector(new_matrix.Column(A.N_Cols))
end