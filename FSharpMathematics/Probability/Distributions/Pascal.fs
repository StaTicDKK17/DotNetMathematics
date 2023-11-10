module Pascal

open System.Collections.Generic
open CountingFunctions

type PascalDist = Dictionary<int, float>

let mutable saved_dist = new PascalDist()

let create_distribution(m) (p: float) (lim) =
    let dist = new PascalDist()
    for k in m..lim do
        dist.Add(k, p ** m * float (binomial_coefficient (k-1) (m-1)) * (float 1 - p) ** float (k-m))
    dist

let evaluate(k) =
    saved_dist.Item k

let evaluate_distribution(dist: PascalDist, k) =
    dist.Item k

let save_distribution(dist: PascalDist) =
    saved_dist <- dist