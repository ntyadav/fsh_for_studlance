open System

let cartesian s1 s2 =
    let mutable c = Set.empty
    for a in s1 do
        for b in s2 do
          c <- Set.add (a, b) c
    c

let rec genBinRelation (s1 : 't Set) (s2 : 't Set) =
    if s1.IsEmpty || s2.IsEmpty then Set.empty
    else
        let r = Seq.item (System.Random().Next() % s2.Count) s2
        let min = s1.MinimumElement
        Set.union (Set.singleton (min, r)) (genBinRelation (Set.remove min s1) (Set.remove r s2))
    

[<EntryPoint>]
let main argv =
    let a = set[1..1..15]
    let b = set[2..2..30]
    printf "A = %A\n" (List.ofSeq a) // Приводим к list, чтобы выводилось полностью
    printf "B = %A\n" (List.ofSeq b)
    printf "%A\n" (Set.union a (Set.intersect a b) = a)
    let c = cartesian a b
    printf "с = %A\n" c

    let rel = genBinRelation a b
    printf "Случайное бин. отношение между A и B: %A" (List.ofSeq rel)
    System.Console.ReadKey() |> ignore
    0 // return an integer exit code
