open System

let enterInt name =
    printf "Введите %s:\n" name
    let s = System.Console.ReadLine()
    System.Convert.ToInt32 s


let printArray (arr : 't array)= 
    printf "["
    Array.iteri (fun i elem -> printf "%A" elem; if i < arr.Length - 1 then printf ", ") arr
    printf "]\n"


[<EntryPoint>]
let main argv =
    let N = 9
    let a = [|for i in 1..10 -> enterInt (String.Format("{0}-е число массива", i))|]
    printf "Массив A:\n%A\n\n" a
    let b = [|for i in 1..20 -> Random().Next() % 100 + 1|]
    printf "Массив B:\n%A\n\n" b
    let c = Array.init 20 (fun k -> (2 * N + 1) * k)
    printf "Массив C:\n%A\n\n" c

    printf "Конкатенация массивов A и B:\n[ "
    Array.iter (fun elem -> printf "%d " elem) a
    Array.iter (fun elem -> printf "%d " elem) b
    printf "]\n\n"
    let l = 4
    let r = 13
    printf "Подмассив массива B от %d-го до %d-го элемента:\n[ " (l + 1) (r + 1)
    Array.iteri (fun i elem -> if i >= l && i <= r then printf "%d " elem) b
    printf "]\n\n"

    printf "Массив значений функции f(x) от элементов массива C:\n"
    printArray (Array.map (fun x -> N * x - 10) c)
    printf "\n"

    printf "Массив значений функции f(x, y) от элементов массивов B и C:\n"
    printArray (Array.map2 (fun x y -> (N + 1) * x + y) b c)
    printf "\n"

    printf "Произведение всех элементов массива B: %d\n" (Array.fold (*) 1 b)
    printf "Массив произведений соответствующих элементов массивов B и C:\n"
    printArray (Array.map2 (fun x y -> x * y) b c)
    printf "\nОтсортированные в порядке неубывания массив B:\n"
    printArray (Array.sort b)

    0 // return an integer exit code
