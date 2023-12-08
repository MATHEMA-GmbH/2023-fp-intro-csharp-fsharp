module Examples1FSharpTests.Example02Applicatives.ServiceTests

open Examples1FSharp.Example02Applicatives.Service
open Swensen.Unquote
open Xunit

[<Fact>]
let ``validating happy path`` () =
    let input = {
        receiverFirstName = "Hans"
        receiverLastName = "Maulwurf"
        receiverTitle = "Herr"
        receiverAddress = "Springfield"
        text = "Liebe Grüße!"
    }

    let validated = validate input

    let expectedResult = Error []

    validated =! expectedResult
