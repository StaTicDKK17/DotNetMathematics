namespace DotnetMathematics.Probability.Distributions.Continuous

module Normal =
    open FSharp.Core

    type NormalDist = { mean: float; variance: float }

    let mutable saved_dist = { mean = 0; variance = 1 }

    let create_distribution (mean) (variance) =
        { mean = mean; variance = variance }

    let evaluate_distribution(dist: NormalDist) (z: float) =
        (1.0 / System.Math.Sqrt (2.0 * System.Math.PI)) * (System.Math.E ** ((z ** 2.0) / 2.0))

    let evaluate(k) =
        evaluate_distribution saved_dist k

    let save_distribution(dist: NormalDist) =
        saved_dist <- dist