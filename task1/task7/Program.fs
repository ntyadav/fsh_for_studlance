open System
open System.Numerics

let rec factorial n =
    if n = 0 then 1I
    else BigInteger.Multiply(BigInteger.op_Explicit(decimal n), factorial (n - 1))

let seriesSum n =
    let rec sum k res =
        if k > n then res
        else
            let cur = BigInteger.Divide(BigInteger.Pow(10I, 2 * k + 1), factorial (2 * k + 1))
            sum (k + 1) (res + cur)
    sum 0 0I

[<EntryPoint>]
let main argv =
    printf "sh10 = %f\n" (sinh 10.)
    printf "Частичная сумма от 0 до 100: %A\n" (seriesSum 50)
    0