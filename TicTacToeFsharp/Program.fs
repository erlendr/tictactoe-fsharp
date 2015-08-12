module Program

open System

[<EntryPoint>]
let main argv = 
    let gameboardsize = 3
    let gameboard = Game.CreateGameboard gameboardsize

    printfn "Tic Tac Toe"

    let rec gameLoop gb =
        printf "Please input coords: "
        let coords : string = Console.ReadLine()
        let parsedCoords = coords.Split [| ',' |]
        let coordX = Int32.Parse parsedCoords.[0]
        let coordY = Int32.Parse parsedCoords.[1]

        let newGb, success = Game.MakeMove gb Game.Player1 coordX coordY
        if success then
            Game.PrintGameboard newGb 3
        else
            printfn "Move not valid"
            gameLoop newGb

        if (Game.IsGameWon newGb) then
            printfn "Game won! Press any key to exit"
            Console.Read() |> ignore
        else
            gameLoop newGb
     
    gameLoop gameboard
    0 // return an integer exit code
