## Method chaining - example

### F&#35;

    open System
    open System.Text

    [<EntryPoint>]
    let main argv = 
        
        [|65uy; 84uy; 72uy|]
        |> Encoding.UTF8.GetString
        |> Console.WriteLine

        0
