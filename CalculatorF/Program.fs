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

let add  x y = x + y

let subtract x y = x - y

let multiply x y = x * y

let divide x y = maybe{
    let! x = match y with
    | 0.0 -> None
    | _ -> Some (x / y)
    return x
    }

let calculate op x y =  maybe{
        let! x = match op with
            | "+" -> Some(add x y)
            | "-" -> Some(subtract x y)
            | "*" -> Some(multiply x y)
            | "/" -> divide x y
            | _ -> None
        return x
    }
let styles = NumberStyles.AllowDecimalPoint

let provider = new CultureInfo("en-US")

let output  (result : float option)  =
    match result with
        | None -> Console.WriteLine("Mission Failed we'll get em next time")
        | Some result -> Console.WriteLine(result)
        
let getNumber (str:string) = maybe{
         let isNumber, number = Double.TryParse(str, styles, provider)
         let! str = match isNumber with
         | true -> Some(number)
         | false -> None
         return str
         }
         
[<EntryPoint>]
let main argv = 
    let a = getNumber(Console.ReadLine())
    let op = Console.ReadLine()
    let b = getNumber(Console.ReadLine())
    let result = maybe{
        let! calc = calculate op a.Value b.Value
        return calc
    }
    output result
    0    
   
 