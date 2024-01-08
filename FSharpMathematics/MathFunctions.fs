module MathFunctions

let rec factorial (k: int) : uint64 =
    match k with
    | 0 -> 1UL
    | _ -> uint64 (k) * factorial (k-1)

let gamma (alpha: int) = 
    factorial (alpha - 1)