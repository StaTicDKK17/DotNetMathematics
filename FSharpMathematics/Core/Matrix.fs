namespace FSharpMathematics.Core

open FSharp.Collections

type Matrix = class
  val private _xs : float[,]

  /// <summary>
  /// Initializes an m-by-n Matrix with all 0's.
  /// </summary>
  new (mRows : int, nCols : int) =
    { _xs = Array2D.zeroCreate mRows nCols }

  /// <summary>
  /// Initialises a Matrix from a Array2D
  /// </summary>
  /// <remarks>
  /// the new object has its own instance of _xs
  /// </remarks> 
  new (xs : float[,]) =
    { _xs = Array2D.copy xs }
  

  ///<summary>
  /// A copy constructor
  ///</summary 
  /// <remarks>
  /// Deep copy, no instances shared.
  /// </remarks>
  new (A : Matrix) = 
    {_xs = Array2D.copy A._xs}


  /// <summary>
  /// Get the matrix as a 2D array.
  /// </summary>
  /// 
  /// <returns>
  /// A 2D array representation of the Matrix.
  /// </returns>
  member this.ToArray() =
    this._xs

  member this.M_Rows =
    this._xs.GetLength(0)

  member this.N_Cols =
    this._xs.GetLength(1)

  member this.Size =
    (this.M_Rows, this.N_Cols)

  member this.Item
    with get (i : int, j : int) = this._xs.[i, j]
    and set (i : int, j : int) (value : float) = this._xs.[i, j] <- value

  /// <summary>
  /// Get a particular row vector.
  /// </summary>
  ///
  /// <param name="i">
  /// The index of the row to get.
  /// </param>
  ///
  /// <returns>
  /// A vector containing the data of the given row
  /// </returns>
  member this.Row (i : int) : Vector =
    Vector(seq { for i in 0..this.N_Cols-1 -> i } |> Seq.map (fun x -> this._xs[i, x]) |> Seq.toArray)

  /// <summary>
  /// Get a particular column vector.
  /// </summary>
  ///
  /// <param name="j">
  /// The index of the column to get.
  /// </param>
  ///
  /// <returns>
  /// A vector containing the data of the given column
  /// </returns>
  ///
  /// <remarks>
  /// The implementation is row-major, so this is expected to be a slow
  /// endeavour.
  /// </remarks>
  member this.Column (j : int) =
    Vector (seq {for i in 0..this.M_Rows-1 -> i } |> Seq.map (fun x -> this._xs[x, j]) |> Seq.toArray)

end