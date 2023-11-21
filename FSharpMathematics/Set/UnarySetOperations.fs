namespace DotnetMathematics.Set.UnarySetOperations

module UnarySetOperations =

    type Set = array<obj>

    let set_cardinality (set: Set) =
        set.Length

    let power_set (set: Set) =
        let mutable power_set = create_set (set_cardinality set)
        // TODO: implement power set operation
        power_set

