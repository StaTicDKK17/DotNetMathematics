module Geometric

open System.Collections.Generic

type GeometricDist = Dictionary<int, float>

let create_geometric(p: float, lim) =
    let dist = new GeometricDist()
    for i in 1..lim+1 do
        dist.Add(i, p * (float 1-p) ** (float i - float 1))
    dist

let evaluate_geomtric(dist: GeometricDist, k) =
    dist.Item k