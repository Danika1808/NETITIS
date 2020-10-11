namespace Calculator.DesignPatterns.Proxy

type MaybeBuilder() =
    member this.Bind(x, f) = 
        match x with
        | None -> None
        | Some a -> f a
        
    member this.Return(x) = 
        Some x

type AsyncMaybeBuilder () =
    member this.Bind(x, f) =
        async {
            let! x' = x
            match x' with
            | Some s -> return! f s
            | None -> return None
            }

    member this.Return(x) =
        async{return x}

open System.Text.RegularExpressions;
open System
open System.Globalization

module Proxy =
    let private pattern = @"-?\d+(?:\.\d+)?)\s*([-+*\/])\s*(-?\d+(?:\.\d+)?"

    let private maybeAsync = new AsyncMaybeBuilder()

    let private maybe = new MaybeBuilder()

    let CheckAccess input =
        Regex.IsMatch(input, pattern) 
    
    let private add x y = x + y
    
    let private subtract x y = x - y
    
    let private multiply x y = x * y
    
    let private divide x y = maybe{
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
    let private styles = NumberStyles.AllowDecimalPoint
    
    let private provider = new CultureInfo("en-US")
            
    let getNumber (str:string) = maybe{
        let isNumber, number = Double.TryParse(str, styles, provider)
        let! str = match isNumber with
            | true -> Some(number)
            | false -> None
        return str
    }