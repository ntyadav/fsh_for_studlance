open System


let a i = 
    match i with
     | 2. | 5. | 7. -> sqrt i + i ** (1. / 5.) + i ** (1. / 7.)
     | _ -> tanh i / sin i

let funcSum l r f =
    let rec funcSum' i acc= 
        if i > r then acc
        else funcSum' (i + 1.) (acc + f i)
    funcSum' l 0.

let aSum m = 
    let a i = 
        match i with
         | 2. | 5. | 7. -> sqrt i + i ** (1. / 5.) + i ** (1. / 7.)
         | _ -> tanh i / sin i
    funcSum 1. (float m) a

[<EntryPoint>]
let main argv =
    printfn "%.3f" (a 1.) // На экране 0.905 – правильно
    printfn "%.3f" (a 2.) // На экране 3.667 – правильно
    printfn "%.3f" (a 2.1) // На экране 1.124 – правильно
    printfn "%.3f" (a 3.) // На экране 7.051 – правильно
    printfn "%.3f" (aSum 3) // На экране 11.623 – правильно
    System.Console.ReadKey() |> ignore
    0 // return an integer exit code
