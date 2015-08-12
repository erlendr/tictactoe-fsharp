module Program

open System

[<EntryPoint>]
let main argv = 
    let gameboardsize = 3
    let gameboard = Game.CreateGameboard gameboardsize

    printfn "Tic Tac Toe"
    let coords : string = Console.ReadLine()
    let parsedCoords = coords.Split [| ',' |]
    
    
    Console.Read() |> ignore
    0 // return an integer exit code
