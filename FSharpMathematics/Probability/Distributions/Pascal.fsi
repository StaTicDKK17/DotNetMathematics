namespace Probability.Distributions

module Pascal =
    type PascalDist = { m: int; p: float }

    val create_distribution : int -> float -> PascalDist

    val evaluate_distribution : PascalDist -> int -> float

    val evaluate : int -> float

    val save_distribution : PascalDist -> unit