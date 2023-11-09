module Bernoulli

open System.Collections.Generic

type BernoulliDist = Dictionary<int, float>

let mutable saved_dist = new BernoulliDist()

let create_distribution(p) : BernoulliDist =
    let dist = BernoulliDist()
    dist.Add(1, p)
    dist.Add(0, float 1 - p)
    dist

let evaluate(v) =
    saved_dist.Item v

let evaluate_distribution(dist: BernoulliDist, v) =
    dist.Item v

let save_distribution(dist: BernoulliDist) =
    saved_dist <- dist