namespace DotnetMathematics.Set.BinaryOperations

module SetOperations =

    type Set = array<obj>

    val set_union : Set -> Set -> Set

    val set_intersection : Set -> Set -> Set

    val set_complement : Set -> Set -> Set