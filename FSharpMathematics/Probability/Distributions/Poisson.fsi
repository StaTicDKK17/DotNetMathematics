namespace Probability.Distributions

module Poisson =
    type PoissonDist = { lambda: int }

    val create_distribution : int -> PoissonDist

    val evaluate_distribution : PoissonDist -> int -> float

    val evaluate : int -> float

    val save_distribution : PoissonDist -> unit