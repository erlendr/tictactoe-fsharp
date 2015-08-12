namespace TicTacToe.Tests

module Tests = 
    open FsUnit
    open NUnit.Framework
    
    [<Test>]
    let ``given a board width of 3, when creating gameboard, board width should be 3``() = 
        Game.CreateGameboard 3
        |> Array2D.length1
        |> should equal 3
    
    [<Test>]
    let ``given a board width of 3, when creating gameboard, board height should be 3``() = 
        Game.CreateGameboard 3
        |> Array2D.length2
        |> should equal 3
    
    [<Test>]
    let ``given a row having two "X" elements, when counting number of "X" elements, count should be 2``() = 
        [| "X"; "X"; "0" |]
        |> Game.CountElement "X"
        |> should equal 2
    
    [<Test>]
    let ``given a gameboard, when getting a row, result should be correct row``() = 
        let boardsize = 3
        let element = "X"
        let gameboard = Game.CreateGameboard boardsize
        gameboard.[0, 0] <- element
        gameboard.[0, 1] <- element
        gameboard.[0, 2] <- element
        Game.GetRow 0 gameboard |> should equal [| element; element; element |]
    
    [<Test>]
    let ``given a gameboard, when getting a column, result should be correct column``() = 
        let boardsize = 3
        let element = "X"
        let gameboard = Game.CreateGameboard boardsize
        gameboard.[0, 0] <- element
        gameboard.[1, 0] <- element
        gameboard.[2, 0] <- element
        Game.GetColumn 0 gameboard |> should equal [| element; element; element |]
    
    [<Test>]
    let ``given a gameboard with first row filled, when calling HasFilledRow, shoud be true``() = 
        let boardsize = 3
        let marker = "X"
        let gameboard = Game.CreateGameboard boardsize
        gameboard.[0, 0] <- marker
        gameboard.[0, 1] <- marker
        gameboard.[0, 2] <- marker
        Game.HasFilledRow marker gameboard boardsize |> should equal true
    
    [<Test>]
    let ``given a gameboard with first column filled, when calling HasFilledColumn, shoud be true``() = 
        let boardsize = 3
        let marker = "X"
        let gameboard = Game.CreateGameboard boardsize
        gameboard.[0, 0] <- marker
        gameboard.[1, 0] <- marker
        gameboard.[2, 0] <- marker
        Game.HasFilledColumn marker gameboard boardsize |> should equal true
