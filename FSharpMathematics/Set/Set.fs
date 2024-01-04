namespace DotnetMathematics.Set

module SetCreation =

    type Set = array<obj>

    let create_set(size: int) : Set =
        Array.zeroCreate size

    let copy_set(set: Set) : Set =
        Array.copy set