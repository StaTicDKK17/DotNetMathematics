namespace Probability.Distributions

module Pascal =

    open CountingFunctions

    type PascalDist = { m: int; p: float }

    let mutable saved_dist = { m = 0; p = -1 }

    let create_distribution(m) (p: float) =
        { m = m; p = p }

    let evaluate_distribution(dist: PascalDist) (k) =
        float (binomial_coefficient (k-1) (dist.m - 1)) * (dist.p ** float dist.m) * ((float 1 - dist.p) ** float (k-dist.m))

    let evaluate(k) =
        evaluate_distribution saved_dist k

    let save_distribution(dist: PascalDist) =
        saved_dist <- dist