namespace TicTacToe.Tests

module Tests =
    open FsUnit
    open NUnit.Framework
    
    let [<Test>] ``when creating gameboard, board width should equal 3`` () =
        Game.CreateGameboard 3 |> Array2D.length1 |> should equal 3

    let [<Test>] ``when creating gameboard, board height should equal 3`` () =
        Game.CreateGameboard 3 |> Array2D.length2 |> should equal 3

    let [<Test>] ``count element should return correct count`` () =
        [|"X"; "X"; "0";|] |> Game.CountElement "X" |> should equal 2

    let [<Test>] ``get row should return correct row`` () =
        let testArray = Array2D.create 3 3 ""
        testArray.[0,0] <- "X";
        testArray.[0,1] <- "X";
        testArray.[0,2] <- "X";
        Game.GetRow 0 testArray |> should equal [|"X"; "X"; "X";|]

    let [<Test>] ``get column should return correct column`` () =
        let testArray = Array2D.create 3 3 ""
        testArray.[0,0] <- "X";
        testArray.[1,0] <- "X";
        testArray.[2,0] <- "X";
        Game.GetColumn 0 testArray |> should equal [|"X"; "X"; "X";|]

    let [<Test>] ``has filled row should return correct result`` () =
        let boardsize = 3
        let marker = "X";
        let gameboard = Game.CreateGameboard boardsize
        gameboard.[0, 0] <- marker
        gameboard.[0, 1] <- marker
        gameboard.[0, 2] <- marker

        Game.HasFilledRow marker gameboard boardsize |> should equal true

    let [<Test>] ``has filled column should return correct result`` () =
        let boardsize = 3
        let marker = "X";
        let gameboard = Game.CreateGameboard boardsize
        gameboard.[0, 0] <- marker
        gameboard.[1, 0] <- marker
        gameboard.[2, 0] <- marker

        Game.HasFilledColumn marker gameboard boardsize |> should equal true
        