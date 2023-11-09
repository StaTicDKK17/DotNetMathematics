module Geometric

open System.Collections.Generic

type GeometricDist = Dictionary<int, float>

let create_distribution(p: float, lim) =
    let dist = new GeometricDist()
    for i in 1..lim do
        dist.Add(i, p * (float 1-p) ** (float i - float 1))
    dist

let evaluate(dist: GeometricDist, k) =
    dist.Item k