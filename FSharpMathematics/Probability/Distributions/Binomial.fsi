module Binomial

type BinomialDist = { n: int; p: float }

val create_distribution : int -> float -> BinomialDist

val evaluate_distribution : BinomialDist -> int -> float

val evaluate : int -> float

val save_distribution : BinomialDist -> unit