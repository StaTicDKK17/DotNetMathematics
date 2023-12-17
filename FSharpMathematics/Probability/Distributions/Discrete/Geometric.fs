namespace DotnetMathematics.Probability.Distributions.Discrete

module Geometric =
    type GeometricDist = {p: float}

    let mutable saved_dist = {p = -1}

    let create_distribution(p: float) =
        { p = p }

    let evaluate_distribution(dist: GeometricDist) (k) =
        (float 1 - dist.p) ** float (k-1) * dist.p

    let evaluate(k) =
        evaluate_distribution saved_dist k

    let save_distribution(dist: GeometricDist) =
        saved_dist <- dist