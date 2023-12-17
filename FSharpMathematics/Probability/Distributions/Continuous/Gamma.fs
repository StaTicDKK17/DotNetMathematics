namespace DotnetMathematics.Probability.Distributions.Continuous

module Gamma = 
    open MathFunctions

    type GammaDist = { alpha: float; lamb: float }

    let mutable saved_dist = { alpha = 0; lamb = 1 }

    let create_distribution (alpha) (lamb) =
        { alpha = alpha; lamb = lamb; }

    let evaluate_distribution(dist: GammaDist) (x: float) =
        if x > 0 then
            let numerator = (dist.lamb ** dist.alpha) * (x ** (dist.alpha - 1.0)) * (System.Math.E ** (-1.0 * dist.lamb * x))
            numerator / float (gamma (int dist.alpha))
        else
            0
    let evaluate(k) =
        evaluate_distribution saved_dist k

    let save_distribution(dist: GammaDist) =
        saved_dist <- dist