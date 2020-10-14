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

let GiveRequest expression = async{

    let client = new HttpClient()
    let! response = client.GetAsync("http://localhost:51963?value=" + expression) |> Async.AwaitTask
    let! content = response.Content.ReadAsStringAsync() |> Async.AwaitTask
    let result = 
        match response.IsSuccessStatusCode with
        |true -> Some(content)
        |false -> None
    return result
    }

let output (result : string option) =
    match result with
        | None -> Console.WriteLine("Bad Request")
        | Some result -> Console.WriteLine(result)
[<EntryPoint>]
let main argv = 
    let a = Console.ReadLine()
    let op = GetOper(Console.ReadLine())
    let b = Console.ReadLine()
    let expression = a + " " + op + " " + b;
    let result = 
        match checkAccess expression with
        | true -> Async.RunSynchronously(GiveRequest expression) |> Some
        | false -> None
    output result.Value
    0