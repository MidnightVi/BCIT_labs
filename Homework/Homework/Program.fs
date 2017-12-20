open System

type SquireRootResult =
    |NoRoots
    |OneRoot of double
    |TwoRoots of double * double 

let Calculate(a:double, b:double, c:double):SquireRootResult =
    let D = b*b - 4.0*a*c
    if D < 0.0 then NoRoots
    else if D = 0.0 then
        let r = -b/(2.0 * a)
        OneRoot r
    else
        let r1 = (-b + Math.Sqrt(D)) / (2.0 * a)
        let r2 = (-b - Math.Sqrt(D)) / (2.0 * a)
        TwoRoots (r1, r2)

let Print(a:double, b:double, c:double):unit =
    printf "a = %A, b = %A, c = %A. " a b c 
    let root = Calculate(a, b, c)
    let text = 
        match root with
        | NoRoots -> "No roots"
        | OneRoot(r) -> "One root" + r.ToString()
        | TwoRoots(r1, r2) -> "Two roots " + r1.ToString() + " and " + r2.ToString()
    printfn "%s" text

let Pause() =
        match System.Diagnostics.Debugger.IsAttached with
        | true ->
           printfn "Press any key to continue"
           System.Console.ReadLine() |> ignore
        | false -> ()

let rec Read() =
        printfn "Put a number"
        match System.Double.TryParse(System.Console.ReadLine()) with
        | false, _ -> printfn "Try again"; Read()
        | _, x -> x

[<EntryPoint>]
let main _ = 
    let mutable a = Read();
    let mutable b = Read();
    let mutable c = Read();
    Print(a, b, c)

    printfn "Test"
    a <- 1.0
    b <- 2.0
    c <- -3.0
    Print(a, b, c)

    Pause()

    0