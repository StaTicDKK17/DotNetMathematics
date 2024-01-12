namespace DotnetMathematics.Set

module Set =
    type set =
        {
            elements: array<obj>
        }

    let create_set(size: int) : set =
        {
            elements = Array.zeroCreate size
        }
        
    let copy_set(set: set) : set =
        {
            elements = Array.copy set.elements
        }

module SetOperations =

    let set_union (set1: Set.set) (set2: Set.set): Set.set =
        {
            elements = Array.append set1.elements set2.elements |> Array.distinct
        }
        
    let set_intersection (set1: Set.set) (set2: Set.set): Set.set =
        {
            elements = ([], set1.elements, set2.elements) |||> Array.fold2 (fun acc a b -> if a.Equals b then  acc @ [a] else acc) |> Array.ofList
        }
        

    let set_complement (set1: Set.set) (set2: Set.set): Set.set =
        let mutable set = []
        let list2 = Array.toList set2.elements
        for elem in set1.elements do
            if not (List.contains elem list2) then
                set <- set @ [elem]
        
        {
            elements = set |> Array.ofList
        }