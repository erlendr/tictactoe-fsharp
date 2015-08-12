module Program

[<EntryPoint>]
let main argv = 
    let boardsize = 3
    let gameboard = Game.CreateGameboard boardsize
    //    HasFilledRow "X" gameboard boardsize
    //    HasFilledColumn "0" gameboard boardsize
    //    HasFilledRow "0" gameboard boardsize
    //    HasFilledRow "" gameboard boardsize
    gameboard.[0, 0] <- "0"
    gameboard.[1, 1] <- "0"
    gameboard.[2, 2] <- "0"
    Game.PrintGameboard gameboard boardsize
    Game.HasFilledUpperLeftToLowerRightDiagonal "0" gameboard boardsize |> ignore
    let gameboard = Game.CreateGameboard boardsize
    gameboard.[0, 2] <- "0"
    gameboard.[1, 1] <- "0"
    gameboard.[2, 0] <- "0"
    Game.PrintGameboard gameboard boardsize
    Game.HasFilledUpperRightToLowerLeftDiagonal "0" gameboard boardsize |> ignore
    0 // return an integer exit code
