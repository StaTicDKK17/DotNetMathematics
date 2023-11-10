module Bernoulli

open System.Collections.Generic

type BernoulliDist = {p: float}

val create_distribution : float -> BernoulliDist

val evaluate : int -> float

val evaluate_distribution : BernoulliDist -> int -> float

val save_distribution : BernoulliDist -> unit