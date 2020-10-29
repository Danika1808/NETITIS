namespace ClassLibrary

open System.Net.Http
open System

module Request =
    let GiveRequest expression = async{

        let client = new HttpClient()
        let! response = client.GetAsync("http://localhost:51963?value=" + expression) |> Async.AwaitTask
        let! content = response.Content.ReadAsStringAsync() |> Async.AwaitTask

        content
    }

    let output expression = 
        let result = GiveRequest expression
        result
