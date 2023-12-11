module Tests
open Swensen.Unquote
open Xunit
open WorkshopFSharp

[<Fact>]
let ``ToUpper can handle empty string`` () =
    let input = ""
    let actual = input |> ToUpper
    let expected = ""
    test <@actual=expected@>

[<Fact>]
let ``ToUpper can handle real string`` () =
    let input = "abc123"
    let actual = input |> ToUpper
    let expected = "ABC123"
    test <@actual=expected@>
    
[<Fact>]
let ``ToUpper can handle null string`` () =
    let input = null
    let actual = input |> ToUpper
    let expected  = ""
    test <@actual=expected@>
