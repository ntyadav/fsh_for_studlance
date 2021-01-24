open System

[<EntryPoint>]
let main argv =
    let l = [for x in 1..20 -> Random().Next() % 15]
    printf "Список:\n%A\n" l
    let x = 0
    let y = 15
    let maxEl = List.fold (fun x y -> if x > y then x else y) Int32.MinValue l
    printf "Максимальный элемент: %d\n\n" maxEl
    let l1 = List.map (fun elem -> if elem = x then y else elem) l
    printf "Замена всех %d на %d:\n%A\n" x y l1
    System.Console.ReadKey() |> ignore
    0 // return an integer exit code
