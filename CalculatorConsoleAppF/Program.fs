open System

let add x y = x + y

let subtract x y = x - y

let divide x y = x / y

let multiply x y = x * y

let calculator x y = match x y with
| "+" -> add x y
| "-" -> subtract x y
| "/" -> divide x y
| "*" -> multiply x y
| _ -> Exception
[<EntryPoint>]