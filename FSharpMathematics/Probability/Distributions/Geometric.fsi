module Geometric

type GeometricDist = {p: float}

val create_distribution : float -> GeometricDist

val evaluate_distribution : GeometricDist -> int -> float

val evaluate : int -> float

val save_distribution : GeometricDist -> unit