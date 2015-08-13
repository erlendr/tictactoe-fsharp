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
        printf "\nPlayer %i: Please input coords x,y: " playerList.Head.Number

        let coords : string = Console.ReadLine()
        let parsedCoords = coords.Split [| ',' |]

        if parsedCoords.Length < 2 then
            printfn "Invalid format, try again.\n"
            gameLoop gb (List.rev playerList)
        else ()

        let couldParse, coordX = Int32.TryParse parsedCoords.[0]
        let couldParse, coordY = Int32.TryParse parsedCoords.[1]
        if not couldParse then
            printfn "Invalid format, try again.\n"
            gameLoop gb (List.rev playerList)
        else ()

        let newGameboard, moveSuccessful = Game.MakeMove gb playerList.Head coordX coordY
        if moveSuccessful then
            printfn ""
            Game.PrintGameboard newGameboard
        else
            printfn "Move not valid, try again.\n"
            gameLoop newGameboard (List.rev playerList)

        if (Game.IsGameWon newGameboard) then
            printfn "\nGame won by player %i! Press any key to exit" playerList.Head.Number
            Console.Read() |> ignore
        else
            gameLoop newGameboard (List.rev playerList)
     
    gameLoop gameboard players
    0 // return an integer exit code
