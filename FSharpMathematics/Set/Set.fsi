namespace DotnetMathematics.Set.Creation

module Set =

    type Set = array<obj>

    val create_set : int -> Set

    val copy_set : Set -> Set