namespace DotnetMathematics.Probability.Distributions.Continuous

module Uniform =

    type UniformDist = { a: float; b: float }

    let mutable saved_dist = { a = 0; b = 0 }

    let create_distribution (a) (b) =
        { a = a; b = b }

    let evaluate_distribution(dist: UniformDist) (x) =
        if x > dist.a && x < dist.b then
            1.0 / (dist.b - dist.a)
        else
            0

    let evaluate(k) =
        evaluate_distribution saved_dist k

    let save_distribution(dist: UniformDist) =
        saved_dist <- dist