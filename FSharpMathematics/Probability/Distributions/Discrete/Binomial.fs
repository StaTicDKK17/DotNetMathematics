namespace DotnetMathematics.Probability.Distributions.Discrete

module Binomial =

    open FSharpMathematics.Combinatorics.CountingFunctions

    type BinomialDist = { n: int; p: float }

    let mutable saved_dist = { n = 0; p = -1 }

    let create_distribution(n) (p: float) =
        { n = n; p = p; }

    let evaluate_distribution(dist: BinomialDist) (k) =
        float (binomial_coefficient dist.n k) * (dist.p ** k) * ((float 1-dist.p) ** float (dist.n - k))

    let evaluate(k) =
        evaluate_distribution saved_dist k

    let save_distribution(dist: BinomialDist) =
        saved_dist <- dist

    let expected_value (dist: BinomialDist) : float =
        float dist.n * dist.p

    let expected_value_saved () : float =
        expected_value saved_dist

    let variance (dist: BinomialDist): float =
        float dist.n * dist.p * (1.0 - dist.p)

    let variance_saved () : float =
        variance saved_dist