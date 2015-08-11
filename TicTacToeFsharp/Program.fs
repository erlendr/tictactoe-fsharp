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

let HasFilledColumn element gameboard boardsize =
    [|0..boardsize-1|]
    |> Array.map (fun x -> GetColumn x gameboard |> CountElement element = boardsize)
    |> Array.contains true

let HasFilledUpperLeftToLowerRightDiagonal element gameboard boardsize =
    // Source: http://stackoverflow.com/questions/2366899/f-array2d-slices/2369690#2369690
    let flatten (A:'a[,]) = A |> Seq.cast<'a>

    gameboard
    |> Array2D.mapi(fun i j x ->
        i = j && x = element
    )
    |> flatten
    |> Seq.filter(fun x -> x = true)
    |> Seq.length = boardsize

let HasFilledUpperRightToLowerLeftDiagonal element gameboard boardsize = 
    let flatten (A:'a[,]) = A |> Seq.cast<'a>

    let seqX = [|0..boardsize-1|];
    let seqY = Array.rev seqX;

    gameboard
    |> Array2D.mapi(fun i j x ->
        i = seqX.[i] && j = seqY.[i] && x = "0"
    )
    |> flatten
    |> Seq.filter(fun x -> x = true)
    |> Seq.length = boardsize

let PrintGameboard gameboard boardsize =
    [|0..boardsize-1|]
    |> Array.iter (fun x -> 
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

  
//    HasFilledRow "X" gameboard boardsize
//    HasFilledColumn "0" gameboard boardsize
//    HasFilledRow "0" gameboard boardsize
//    HasFilledRow "" gameboard boardsize

    gameboard.[0,0] <- "0";
    gameboard.[1,1] <- "0";
    gameboard.[2,2] <- "0";

    PrintGameboard gameboard boardsize
    
    HasFilledUpperLeftToLowerRightDiagonal "0" gameboard boardsize

    let gameboard = CreateGameboard boardsize

    gameboard.[0,2] <- "0";
    gameboard.[1,1] <- "0";
    gameboard.[2,0] <- "0";

    PrintGameboard gameboard boardsize

    HasFilledUpperRightToLowerLeftDiagonal "0" gameboard boardsize

    
    0 // return an integer exit code
