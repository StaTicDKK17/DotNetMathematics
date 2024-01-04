namespace DotnetMathematics.Probability.Distributions.Discrete

module Bernoulli =

    type BernoulliDist = {p: float}

    let mutable saved_dist = {p = -1}

    let create_distribution(p) : BernoulliDist =
        { p = p }

    let evaluate_distribution(dist: BernoulliDist) (v) =
        match v with
        | 0 -> float 1 - dist.p
        | 1 -> dist.p
        | _ -> -1

    let evaluate(v) =
        evaluate_distribution saved_dist v

    let save_distribution(dist: BernoulliDist) =
        saved_dist <- dist

    let expected_value (dist: BernoulliDist) : float =
        dist.p

    let expected_value_saved () : float =
        expected_value saved_dist

    let variance (dist: BernoulliDist) : float =
        dist.p * (1.0 - dist.p)

    let variance_saved () : float =
        variance saved_dist