module Examples1FSharpTests.DemoTests

open FsUnit.Xunit
open Swensen.Unquote
open Xunit

[<Fact>]
let ``This test can have readable whitespaces in the test method name`` () =
    Assert.True(true)
    
[<Fact>]
let ``We can use different assertion libraries - 1 - plain xunit`` () =
    Assert.Equal(1, 1)
    
[<Fact>]
let ``We can use different assertion libraries - 2 - FsUnit`` () =
    1 |> should equal 1
    
[<Fact>]
let ``We can use different assertion libraries - 3 - Unquote 1/2`` () =
    test <@ 1 = 1 @>

[<Fact>]
let ``We can use different assertion libraries - 3 - Unquote 2/2`` () =
    // Short hand syntax
    1 =! 1


type GrußkarteDummy = { Text: string; Empfänger: string }
type GrußkarteDummy2 = { Text: string; Empfänger: string }

[<Fact>]
let ``German Umlauts are no problem`` () =
    let actual = { GrußkarteDummy.Text = "Hallo"; Empfänger = "Welt" }
    let expected = { GrußkarteDummy.Text = "Hallo"; Empfänger = "Welt" }
    
    actual =! expected
    
