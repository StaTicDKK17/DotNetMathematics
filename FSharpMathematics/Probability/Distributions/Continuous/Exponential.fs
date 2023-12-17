namespace DotnetMathematics.Probability.Distributions.Continuous

module Exponential =

    open FSharp.Core

    type ExponentialDist = { lamb: float }

    let mutable saved_dist = { lamb = 0 }

    let create_distribution (lamb) =
        { lamb = lamb }

    let evaluate_distribution(dist: ExponentialDist) (x: float) =
        if x > 0 then
            dist.lamb * System.Math.E ** (-dist.lamb * x)
        else
            0

    let evaluate(k) =
        evaluate_distribution saved_dist k

    let save_distribution(dist: ExponentialDist) =
        saved_dist <- dist