namespace DotnetMathematics.Set.BinaryOperations


module SetOperations =

    type Set = array<obj>

    let set_union (set1: Set) (set2: Set) =
        Array.append set1 set2 |> Array.distinct

    let set_intersection (set1: Set) (set2: Set) =
        ([], set1, set2) |||> Array.fold2 (fun acc a b -> if a.Equals b then acc @ [a] else acc)

    let set_complement (set1: Set) (set2: Set) =
        let mutable set = []
        let list2 = Array.toList set2
        for elem in set1 do
            if not (List.contains elem list2) then
                set <- set @ [elem]
    
        set
