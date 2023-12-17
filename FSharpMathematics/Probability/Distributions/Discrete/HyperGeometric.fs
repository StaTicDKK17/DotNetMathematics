namespace DotnetMathematics.Probability.Distributions.Discrete

module HyperGeometric =

    open FSharpMathematics.Combinatorics.CountingFunctions

    type HyperGeometricDist = { b: int; r: int; k: int }

    let mutable saved_dist = { b = 0; r = 0; k = 0 }

    let create_distribution (b) (r) (k) =
        { b = b; r = r; k = k }

    let evaluate_distribution(dist: HyperGeometricDist) (x) = // (evaluate_distribution dist k) evaluate_distribution(dist, k)
        let numerator = (binomial_coefficient dist.b x) * (binomial_coefficient dist.r (dist.k - x))
        numerator / binomial_coefficient (dist.b + dist.r) (dist.k)

    let evaluate(x) =
        evaluate_distribution saved_dist x

    let save_distribution(dist: HyperGeometricDist) =
        saved_dist <- dist