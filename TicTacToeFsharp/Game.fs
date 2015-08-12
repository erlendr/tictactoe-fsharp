
#if INTERACTIVE
#else
module Game
#endif
let CreateGameboard size = Array2D.create<string> size size "-"
let CountElement element array = Array.filter (fun x -> x = element) array |> Array.length
let GetRow rowNumber (gameboard : string [,]) = gameboard.[rowNumber, *]
let GetColumn colNumber (gameboard : string [,]) = gameboard.[*, colNumber]
let HasFilledRow element gameboard boardsize =
    [|0..boardsize-1|]
    |> Array.map (fun x -> GetRow x gameboard |> CountElement element = boardsize)
    |> Array.contains true

let HasFilledColumn element gameboard boardsize =
    [|0..boardsize-1|]
    |> Array.map (fun x -> GetColumn x gameboard |> CountElement element = boardsize)
    |> Array.contains true

let HasFilledUpperLeftToLowerRightDiagonal element gameboard boardsize = 
    let flatten (A : 'a [,]) = A |> Seq.cast<'a>
    gameboard
    |> Array2D.mapi (fun i j x -> i = j && x = element)
    |> flatten
    |> Seq.filter (fun x -> x = true)
    |> Seq.length
    = boardsize

let HasFilledUpperRightToLowerLeftDiagonal element gameboard boardsize = 
    let flatten (A : 'a [,]) = A |> Seq.cast<'a>
    let seqX = [| 0..boardsize - 1 |]
    let seqY = Array.rev seqX
    gameboard
    |> Array2D.mapi (fun i j x -> i = seqX.[i] && j = seqY.[i] && x = element)
    |> flatten
    |> Seq.filter (fun x -> x = true)
    |> Seq.length
    = boardsize

let PrintGameboard gameboard boardsize = 
    [| 0..boardsize - 1 |] |> Array.iter (fun x -> 
                                  GetRow x gameboard |> Array.iteri (fun i y -> 
                                                            match i = boardsize - 1 with
                                                            | true -> printfn " | %s |" y
                                                            | false -> printf " | %s" y))
