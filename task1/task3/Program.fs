open System


(* Т. к. область определения исходной функции была пустым множеством,
    то минус в первой скобке был заменен на плюс*)
let f = fun x -> (x * x + 3. + (x * x + 3.) ** 2.) ** (x * x + 3.)

let tabFunc f a b h =
    let rec tabFunc' i =
        if i <= b then
            printf "f(%.3f) = %.3f\n" i (f i)
            tabFunc' (i + h)
    tabFunc' a

let enterFloat name =
    printf "Введите %s:\n" name
    let s = System.Console.ReadLine()
    System.Convert.ToDouble s

[<EntryPoint>]
let main argv =
    let a = enterFloat "A"
    let b = enterFloat "B"
    let h = enterFloat "шаг h"
    tabFunc f a b h
    0 // return an integer exit code
