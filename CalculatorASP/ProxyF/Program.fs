open System
open System.Text.RegularExpressions;
open System.Net.Http


type AsyncMaybeBuilder () =
    member this.Bind(x, f) =
        async {
            let! x' = x
            match x' with
            | Some s -> return! f s
            | None -> return None
            }

    member this.Return x =
        async{return x}

let asyncMaybe = new AsyncMaybeBuilder()

let checkAccess input =
    Regex.IsMatch(input, @"(-?\d+(?:\.\d+)?)\s*([-]?[*]?[%2B]?[%2F]?)\s(-?\d+(?:\.\d+)?)")
        
let GetOper op = 
    match op with
    | "+" -> "%2B"
    | "*" -> "*"
    | "/" -> "%2F"
    | "-" -> "-"
    | _ -> ""

let StatusCode (responce: HttpResponseMessage) = 
    asyncMaybe{
        return 
            match responce.IsSuccessStatusCode with
                |true ->Some (responce.Con)
                |false -> None
    }

let GiveRequest expression = async{

    let client = new HttpClient()
    let! response = client.GetAsync("http://localhost:51963?value=" + expression) |> Async.AwaitTask
    let! statusCode = StatusCode response
    return Some(statusCode)
    }

let RunCalculator expression =
    let result = Async.RunSynchronously(GiveRequest expression)
    Console.WriteLine(result.Value)

[<EntryPoint>]
let main argv = 
    let a = Console.ReadLine()
    let op = GetOper(Console.ReadLine())
    let b = Console.ReadLine()
    let expression = a + " " + op + " " + b;
    if checkAccess expression then RunCalculator expression
    else Console.WriteLine("Bad Request");
    0     