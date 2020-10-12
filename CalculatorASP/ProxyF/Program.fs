open System
open System.Net
open System.Text.RegularExpressions;
open System.IO

type MaybeBuilder() =
    member this.Bind(x,f)=
        match x with
        |None -> None
        |Some a -> f a
    member this.Return(x)=
        Some x

let maybe = new MaybeBuilder()

type AsyncMaybeBuilder () =
    member this.Bind(x, f) =
        async {
            let! x' = x
            match x' with
            | Some s -> return! f s
            | None -> return None
            }

    member this.Return x' =
        async{return x'}

let asyncMaybe = new AsyncMaybeBuilder()

let checkAccess input =
    Regex.IsMatch(input, @"(-?\d+(?:\.\d+)?)\s*([-%2B*%2F])\s*(-?\d+(?:\.\d+)?)")
        
let getOper op = 
    match op with
    | "+" -> "%2B"
    | "*" -> "*"
    | "/" -> "%2F"
    | "-" -> "-"
    | _ -> ""

let giveRequest expression = async{

    let request = WebRequest.Create("http://localhost:51963?value=" + expression, Method = "GET", ContentType = "text/plain")
    let response  = request.GetResponse()
    let stream = response.GetResponseStream();
    let readStream = new StreamReader(stream)
    return readStream.ReadToEnd()
    }

let RunCalculator expression =
    let result = Async.RunSynchronously(giveRequest expression)
    result

[<EntryPoint>]
let main argv = 
    let a = Console.ReadLine()
    let op = getOper(Console.ReadLine())
    let b = Console.ReadLine()
    let expression = a + " " + op + " " + b;
    let result = match checkAccess expression with
    | true -> RunCalculator expression
    | false -> "Bad request"
    printf"%s"result
    0     