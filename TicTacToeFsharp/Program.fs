let CreateGameboard size =
    Array2D.create<string> size size "-";

let CountElement element array =
    Array.filter (fun x -> x = element) array |> Array.length

let GetRow rowNumber (gameboard : string[,]) =
    gameboard.[rowNumber,*]

let GetColumn colNumber (gameboard : string[,]) =
    gameboard.[*, colNumber]

let HasFilledRow element gameboard boardsize =
    [|0..boardsize-1|]
    |> Array.map (fun x -> GetRow x gameboard |> CountElement element = boardsize)
    |> Array.contains true

let PrintGameboard gameboard boardsize =
    [|0..boardsize-1|]
    |> Array.map (fun x -> 
        GetRow x gameboard
        |> Array.iteri(fun i y -> 
            match i = boardsize-1 with
            | true -> printfn " | %s |" y
            | false -> printf " | %s" y
        )
    )

[<EntryPoint>]
let main argv =
    let boardsize = 3 
    let gameboard = CreateGameboard boardsize
    gameboard.[0,0] <- "X";
    gameboard.[0,1] <- "X";
    gameboard.[0,2] <- "X";

    gameboard.[1,0] <- "0";
    gameboard.[1,1] <- "0";
    gameboard.[1,2] <- "0";
  
    HasFilledRow "X" gameboard boardsize
    HasFilledRow "0" gameboard boardsize
    HasFilledRow "" gameboard boardsize
    PrintGameboard gameboard boardsize
    0 // return an integer exit code
