module Geometric

open System.Collections.Generic

type GeometricDist = Dictionary<int, float>

let mutable saved_dist = new GeometricDist()

let create_distribution(p: float) (lim) =
    let dist = new GeometricDist()
    for i in 1..lim do
        dist.Add(i, p * (float 1-p) ** (float i - float 1))
    dist

let evaluate(k) =
    saved_dist.Item k

let evaluate_distribution(dist: GeometricDist) (k) =
    dist.Item k

let save_distribution(dist: GeometricDist) =
    saved_dist <- dist