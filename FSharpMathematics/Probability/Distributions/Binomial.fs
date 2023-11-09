module Binomial

open System.Collections.Generic
open CountingFunctions

type BinomialDist = Dictionary<int, float>

let mutable saved_dist = new BinomialDist()

let create_distribution(n, p: float) =
    let dist = new BinomialDist()
    for k in 0..n do
        dist.Add(k, (float 1 - p) ** float (n-k) * float (binomial_coefficient n k) * p ** k)
    dist

let evaluate(k) =
    saved_dist.Item k

let evaluate_distribution(dist: BinomialDist, k) =
    dist.Item k

let save_distribution(dist: BinomialDist) =
    saved_dist <- dist