open System
open System.Globalization

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
            | "+" -> Some(add x y)
            | "-" -> Some(subtract x y)
            | "*" -> Some(multiply x y)
            | "/" -> divide x y
            | _ -> None

let styles = NumberStyles.AllowDecimalPoint
let provider = new CultureInfo("en-US")

let getNumber (str:string) = 
         let isNumber, number = Double.TryParse(str, styles, provider)
         if isNumber then Some(number) else None

let output  (result : float option)  =
    if
        result = None then Console.WriteLine("Введено неверное значение или попытка деления на нуль")
    else
        Console.WriteLine(result.Value)
        
[<EntryPoint>]
let main argv = 
    let a = getNumber(Console.ReadLine()).Value
    let op = Console.ReadLine()
    let b = getNumber(Console.ReadLine()).Value
    let result = calculate op a b
    output result
    0
    
   
 