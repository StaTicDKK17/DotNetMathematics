namespace FSharpMathematics.Core

type Vector = class
  val private _xs : float[]

  /// <summary>
  /// Initializes an n-Vector with all 0's.
  /// </summary>
  new (n : int) = 
    { _xs = Array.zeroCreate n }
  /// <summary>
  /// Initializes an Vector from a float[]
  /// </summary>
  /// <remarks>
  /// Perform a copy of the array, not
  /// a shared reference.
  /// </remarks>
  new (xs : float[]) = 
    { _xs = xs }
  /// <summary>
  /// Copy constructor
  /// </summary>
  /// <remarks>
  /// Perform a copy of the array, not
  /// a shared reference.
  new (v : Vector) = 
    {_xs = Array.copy v._xs}

  /// <summary>
  /// Get the vector as an array.
  /// </summary>
  /// 
  /// <returns>
  /// An array representation of the Matrix.
  /// </returns>
  member this.ToArray() =
    this._xs
    
  member this.Size =
    this._xs.Length

  member this.Item
    with get (i : int) = this._xs.[i]
    and set (i : int) (value : float) = this._xs.[i] <- value 

  static member ( * ) (v : Vector, y : float) : Vector =
    Vector(Array.map (fun x -> x * y) (v.ToArray()))

  static member ( * ) (x : float, v : Vector) : Vector =
    Vector(v.ToArray() |> Array.map (fun v -> v * x))

  static member (+) (xs : Vector, ys : Vector) : Vector =
    Vector ((xs.ToArray(), ys.ToArray()) ||> Array.map2 (fun x y -> x + y))

  static member (-) (xs : Vector, ys : Vector) : Vector =
    Vector((xs.ToArray(), ys.ToArray()) ||> Array.map2 (fun x y -> x - y))

  static member ( * ) (xs : Vector, ys : Vector) =
    (xs.ToArray(), ys.ToArray()) ||> Array.map2 (fun x y -> x * y) |> Array.sum
    
end