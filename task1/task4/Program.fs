open System

let f = log10 >> sqrt
let g x = (tan x) ** (1. / 5.)

let p = f << g

let q = f >> g

let EPS = 0.000001


let findMaxOrMin op f l r inc = 
    let rec findMaxOrMin' i m = 
        if i > r + EPS then m
        else 
            let cur = f i
            if (op cur m) then findMaxOrMin' (i + inc) cur
            else findMaxOrMin' (i + inc) m
    findMaxOrMin' l (f l)
    
let findMaxPair f g l r inc =
    let findMax h = findMaxOrMin (>) h l r inc
    (findMax f, findMax g)

let findMinPair f g l r inc =
    let findMin h = findMaxOrMin (<) h l r inc
    (findMin f, findMin g)
    
let tabFunc f l r inc =
    let rec tabFunc' i =
        if i <= r + EPS then
            printf "f(%.2f) = %.3f\n" i (f i)
            tabFunc' (i + inc)
    tabFunc' l



[<EntryPoint>]
let main argv =
    let a = 1.
    let b = 1.5
    let inc = (b - a) / 9.
    printf "При x, принадлежащему [%.2f; %.2f], max(p(x), q(x))  = %A\n" a b (findMaxPair p q a b inc)
    printf "При x, принадлежащему [%.2f; %.2f], min(p(x), q(x))  = %A\n" a b (findMinPair p q a b inc)
    printf "\nПусть f(x) = p(x). Тогда:\n"
    tabFunc p a b inc
    printf "\nПусть f(x) = q(x). Тогда:\n"
    tabFunc q a b inc
    0 // return an integer exit code
