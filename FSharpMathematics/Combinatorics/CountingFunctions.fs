namespace FSharpMathematics.Combinatorics

module CountingFunctions =

    open MathFunctions

    let k_permutations (n: int) (k: int) : uint64 = 
        factorial n / (factorial (n-k))

    let binomial_coefficient (n: int) (k: int) : uint64 =
        factorial n / (factorial k * (factorial (n - k)))