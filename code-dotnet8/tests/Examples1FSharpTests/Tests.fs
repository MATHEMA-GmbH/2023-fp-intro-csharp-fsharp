module Tests

open System
open Examples1FSharp
open Xunit

[<Fact>]
let ``My test`` () =
    let actual = Say.hello "World"
    Assert.True (true)