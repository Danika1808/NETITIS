open System
open System.Diagnostics.CodeAnalysis

type MaybeBuilder() =
    member this.Bind(x, f) = 
        match x with
        | None -> None
        | Some a -> f a
       
    member this.Return(x) = 
        Some x
   
let maybe = MaybeBuilder()

let add x y = x + y

let subtract x y = x - y

let multiply x y = x * y

let divide x y =
    match y with
    | 0.0 -> None
    | _ -> Some (x / y)


let calculate op x y =
        match op with
            | "+" -> Some (add x y)
            | "-" -> Some (subtract x y)
            | "*" -> Some (multiply x y)
            | "/" -> divide x y

[<EntryPoint>]
let main argv=           
    let a : float  = Console.ReadLine() |> Double.Parse
    let op = Console.ReadLine()
    let b : float  = Console.ReadLine() |> Double.Parse
    let result: float option = calculate op a b
    Console.WriteLine(result.Value)
    0