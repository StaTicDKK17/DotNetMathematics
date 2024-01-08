namespace DotnetMathematics.LinAlg

module Vectors =
    type vector  = float[]

    let create_zero_vector(n: int) : vector =
        Array.zeroCreate n

    let create_vector(numbers: float[]) : vector =
        numbers

    let create_copy_vector(v: vector) : vector =
        Array.copy v

    let get_index(v: vector, idx: int) : float =
        Array.get v idx

    let set_index(v: vector, idx: int, value: float) : unit =
        let new_v = create_copy_vector v
        Array.set new_v idx value

    let to_array (v: vector) : float[] =
        v

    let num_elems (v: vector) : int =
        v.Length

module VectorVectorOperations =
    open Vectors
    
    let vector_add (v1: vector) (v2: vector) : vector =
        (to_array v1, to_array v2) ||> Array.map2 (fun x y -> x + y)

    let vector_sub (v1: vector) (v2: vector) : vector =
        (to_array v1, to_array v2) ||> Array.map2 (fun x y -> x - y)

    let vector_dot (v1: vector) (v2: vector) : float =
        (to_array v1, to_array v2) ||> Array.map2 (fun x y -> x * y) |> Array.sum

module VectorFloatOperations =
    open Vectors

    let vector_mul (v : vector) (y : float) : vector =
        (to_array v) |> Array.map (fun x -> x * y)

module UnaryVectorOperations = 
    open Vectors

    let vector_norm (v : vector) : float =
        (to_array v) |> Array.map (fun a -> a ** 2.0) |> Array.sum |> sqrt

module ExportedOperations = 
    open Vectors
    open VectorVectorOperations
    open VectorFloatOperations

    let inline (+) (v1: vector) (v2: vector): vector = vector_add v1 v2

    let inline (-) (v1: vector) (v2: vector): vector = vector_sub v1 v2

    let inline (*) (v1: vector) (v2: vector): float = vector_dot v1 v2

    let inline (*) (lamb: float) (v: vector): vector = vector_mul v lamb

    let inline (*) (v: vector) (lamb: float): vector = vector_mul v lamb