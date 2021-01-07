open System

let h x y =
    (x - 2. * y) ** (cos x * cos x + log10 y)

let t x = 
    let f x = x |> log10 |> sqrt
    let g x = log10 x
    let a = 20.
    if x < a then f x
    else g x

    
(* Т. к. не существует квадрата [A; B] x [A; B], входящего в D(h),
    то ф-ей tabFunc используется прямоугольник [A1; B1] x [A2; B2] (м. б. квадратом)*)
let tabFunc f a1 b1 a2 b2 inc =
    let rec tabFunc' i j =
         if (i <= b1 && j <= b2) then
            printf "h(%.2f, %.2f) = %.3f\n" i j (f i j)
            tabFunc' i (j + inc)
         else if (i <= b1 && j > b2) then
             tabFunc' (i + inc) a2
    tabFunc' a1 a2
            

let findMax f l r inc = 
    let rec findMax' i max = 
        if i > r then max
        else 
            let cur = f i
            if cur > max then findMax' (i + inc) cur
            else findMax' (i + inc) max
    findMax' l (f l)

let enterFloat name =
    printf "Введите %s:\n" name
    let s = System.Console.ReadLine()
    System.Convert.ToDouble s


[<EntryPoint>]
let main argv =
    let a1 = enterFloat "A1"
    let b1 = enterFloat "B1"
    let a2 = enterFloat "A2"
    let b2 = enterFloat "B2"
    let inc = enterFloat "шаг d"
    printf "Табулировании функции h(x, y) в прямоугольнике [%.2f; %.2f] x [%.2f; %.2f] с шагом %.2f:\n" a1 b1 a2 b2 inc
    tabFunc h a1 b1 a2 b2 inc

    printf "\n"
    let c = enterFloat "C"
    let d = enterFloat "D"
    let inc2 = (d - c) / 50.
    printf "Максимальное значение функции t(x) на отрезке [%.2f; %.2f] = %.3f" c d (findMax t c d inc2)
    0 // return an integer exit code
