## Functional programming - F&#35;

    [0..10]
    |> List.map(fun x -> x + 1)
    |> List.filter(fun x -> x % 2 = 0)
    |> List.sortByDescending(fun x -> x)
    |> List.iter(fun x -> printf "%d, " x)

