namespace Probability.Distributions

module Poisson =

    open MathFunctions

    type PoissonDist = { lambda: int }

    let mutable saved_dist = { lambda = -1 }

    let create_distribution(lambda: int) =
        { lambda = lambda }

    // f1 ** f2
    // pown i1 i2
    let evaluate_distribution(dist: PoissonDist) (k) = // (evaluate_distribution dist k) evaluate_distribution(dist, k)
        ((exp (-float dist.lambda)) * float (pown dist.lambda k)) / float (factorial k)

    let evaluate(k) =
        evaluate_distribution saved_dist k

    let save_distribution(dist: PoissonDist) =
        saved_dist <- dist