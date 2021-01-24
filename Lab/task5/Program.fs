open System
open System.Windows.Forms
open System.Drawing

let f1 x = 2. * x * x * x - x * x
let f2 x = 24. * x + 26.

let f x = f1 x - f2 x
let f' x = 6. * x * x - 2. * x - 24. // 1-я производная f
let f'' x = 12. * x - 2. // 2-я производная f


let EPS1 = 1. / 1E3
let EPS2 = 1. / 1E10


let rec findRoot f f' f'' a b eps =
    if abs (a - b) <= 2. * eps then 
        (a + b) / 2.
    else
        let mutable _a = a
        let mutable _b = b
        if f a * f'' a < 0. then _a <- a - f a / f' a / 10. // Делим на 100 т. к. ф-я слижком резкая
        if f b * f'' b < 0. then _b <- b - f b / f' b / 10.
        findRoot f f' f'' _a _b eps

[<EntryPoint>]
let main argv =
    let a = 3.
    let b = 4.
    let stopWatch2 = System.Diagnostics.Stopwatch.StartNew()
    let root2 = (findRoot f f' f'' a b EPS2)
    stopWatch2.Stop()
    let stopWatch1 = System.Diagnostics.Stopwatch.StartNew()
    let root1 = (findRoot f f' f'' a b EPS1)
    stopWatch1.Stop()
    printf "Корень f на отрезке [%.3f; %.3f] с точностью %.10f: %.10f\n" a b EPS1 root1
    printf "f(%.10f) = %.10f\n" root1 (f root1)
    printf "Вермя вычисления корня составило %.5f мс\n" stopWatch1.Elapsed.TotalMilliseconds
    printf "Корень f на отрезке [%.3f; %.3f] с точностью %.10f: %.10f\n" a b EPS2 root2
    printf "f(%.10f) = %.10f\n" root2 (f root2)
    printf "Вермя вычисления корня составило %.5f мс\n" stopWatch2.Elapsed.TotalMilliseconds

    // Объявляем экземпляр класса «Форма»:
    let form = new Form(BackColor = Color.White, Text = "Графическое решение")
    let fW = 500.0
    let fH = 500.0
    form.Width <- int fW // ширина окна формы,
    form.Height <- int fH // высота окна формы,
    form.Paint.Add( // рисование,
     fun drawGr->
    // объявляем экземпляр класса “Pen” – карандаш,
     let pen=new Pen(Color.Black,Width = 2.0f)
     // объявляем экземпляр класса “Brush” – кисть,
     let oX = fW / 2.0 // середина ширины окна формы,
     let oY = fH / 2.0 // середина высоты окна формы,
     drawGr.Graphics.DrawLine(pen, 0.0f, float32 oY, float32 fW, float32 oY) // рисуем ось OX,
     drawGr.Graphics.DrawLine(pen, float32 oX, 0.0f, float32 oX, float32 fH) // рисуем ось OY,
     for t in -6.0..0.01..6.0 do // строим график функции по точкам,
         let x = t * 30. // Растягиваем масштаб по оси OX
         let y1 = f1 t
         let brush=new SolidBrush(Color.Blue)
         drawGr.Graphics.FillEllipse(brush, float32 (oX + x), float32 (oY - y1), 3.0f, 3.0f) // «точка» графика,
         let y2 = f2 t
         let brush=new SolidBrush(Color.Red)
         drawGr.Graphics.FillEllipse(brush, float32 (oX + x), float32 (oY - y2), 3.0f, 3.0f) // «точка» графика,
    )
    printf "\nНажмите любую клавишу. Абсциссы точек пересчения графиков и будут корнями f\n"
    System.Console.ReadKey() |> ignore // ждём в консоли разрешения на построение,
    Application.Run(form) // открываем приложение Windows Forms из консольного приложения
    System.Console.ReadKey() |> ignore
    0 // return an integer exit code
