module FSharpDemos.Tests.ExplorationTests

open Xunit
open FsUnit.Xunit
open Swensen.Unquote

open Exploration

[<Fact>]
let ``prepareOutput function works 👉``() =

    let simpsons =
        [
            { name = "Homer"; nickname = None }
            { name = "Bart"; nickname = Some "el Barto" }
        ]
    
    let actual = simpsons |> getResults 
    let expected = 8
    // actual |> should equal expected
    actual =! expected
