module Binomial

open System.Collections.Generic
open CountingFunctions

type BinomialDist = Dictionary<int, float>

let create_distribution(n, p: float) =
    let dist = new BinomialDist()
    for k in 0..n do
        dist.Add(k, (float 1 - p) ** float (n-k) * float (binomial_coefficient n k) * p ** k)
    dist

let evaluate(dist: BinomialDist, k) =
    dist.Item k