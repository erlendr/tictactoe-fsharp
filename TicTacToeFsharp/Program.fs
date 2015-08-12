module Program

open System

[<EntryPoint>]
let main argv = 
    let gameboardsize = 3
    let gameboard = Game.CreateGameboard gameboardsize

    printfn "Tic Tac Toe"
    printfn "-----------"
    printfn ""

    let players = [Game.Player1; Game.Player2]

    let rec gameLoop gb (playerList : Game.Player list) =
        printf "Player %i: Please input coords x,y: " playerList.Head.Number

        let coords : string = Console.ReadLine()
        let parsedCoords = coords.Split [| ',' |]

        let coordX = Int32.Parse parsedCoords.[0]
        let coordY = Int32.Parse parsedCoords.[1]

        let newGameboard, moveSuccessful = Game.MakeMove gb playerList.Head coordX coordY
        if moveSuccessful then
            Game.PrintGameboard newGameboard 3
        else
            printfn "Move not valid, try again."
            gameLoop newGameboard (List.rev playerList)

        if (Game.IsGameWon newGameboard) then
            printfn "Game won! Press any key to exit"
            Console.Read() |> ignore
        else
            gameLoop newGameboard (List.rev playerList)
     
    gameLoop gameboard players
    0 // return an integer exit code
