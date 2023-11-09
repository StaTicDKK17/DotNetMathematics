module Bernoulli

open System.Collections.Generic

type BernoulliDist = Dictionary<int, float>

let create_distribution(p) : BernoulliDist =
    let dist = new Dictionary<int, float>()
    dist.Add(1, p)
    dist.Add(0, float 1 - p)
    dist

let bernoulli(dist: BernoulliDist, v) =
    dist.Item v