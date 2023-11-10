module Poisson

open System.Collections.Generic
open MathFunctions

type PoissonDist = Dictionary<int, float>

let mutable saved_dist = new PoissonDist()

let create_distribution(lambda: float) (lim) =
    let dist = new PoissonDist()
    for i in 0..lim do
        dist.Add(i, (exp (-lambda) * (lambda ** i))/ float (factorial i))
    dist

let evaluate(k) =
    saved_dist.Item k

let evaluate_distribution(dist: PoissonDist) (k) =
    dist.Item k

let save_distribution(dist: PoissonDist) =
    saved_dist <- dist