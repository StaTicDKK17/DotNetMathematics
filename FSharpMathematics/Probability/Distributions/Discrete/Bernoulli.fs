namespace DotnetMathematics.Probability.Distributions.Discrete

module Bernoulli =

    type BernoulliDist = {p: float}

    let mutable saved_dist = {p = -1}

    let create_distribution(p) : BernoulliDist =
        saved_dist <- { p = p }
        saved_dist

    let evaluate_distribution(dist: BernoulliDist) (v) =
        match v with
        | 0 -> float 1 - dist.p
        | 1 -> dist.p
        | _ -> -1

    let evaluate(v) =
        evaluate_distribution saved_dist v

    let save_distribution(dist: BernoulliDist) =
        saved_dist <- dist