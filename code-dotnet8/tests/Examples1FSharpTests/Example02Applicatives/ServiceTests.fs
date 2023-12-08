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

    let expectedResult = []

    validated =! expectedResult

[<Fact>]
let ``empty first name gives error`` () =
    let input = {
        receiverFirstName = ""
        receiverLastName = "Maulwurf"
        receiverTitle = "Herr"
        receiverAddress = "Springfield"
        text = "Liebe Grüße!"
    }

    let validated = validate input

    let expectedResult = ["is empty"]

    validated =! expectedResult

[<Fact>]
let ``too long text gives error`` () =
    let input = {
        receiverFirstName = "Hans"
        receiverLastName = "Maulwurf"
        receiverTitle = "Herr"
        receiverAddress = "Springfield"
        text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere nisl cursus nibh dapibus, ac interdum diam posuere. Mauris nec neque at metus ultricies venenatis. Pellentesque lobortis dolor eu efficitur vulputate. Fusce id euismod nisi, eget fringilla mi. Mauris dictum orci erat, id gravida quam eleifend ut. Vestibulum sed tortor eget risus imperdiet pellentesque. Donec non eleifend tellus. Suspendisse erat metus, porta sed tellus quis, aliquam efficitur felis. Aenean quis tincidunt tellus. In hac habitasse platea dictumst. Fusce tincidunt lorem convallis, faucibus est iaculis, porta arcu."
    }

    let validated = validate input

    let expectedResult = ["longer than 160"]

    validated =! expectedResult

[<Fact>]
let ``errors are accumulated`` () =
    let input = {
        receiverFirstName = ""
        receiverLastName = ""
        receiverTitle = "Herr"
        receiverAddress = "Springfield"
        text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere nisl cursus nibh dapibus, ac interdum diam posuere. Mauris nec neque at metus ultricies venenatis. Pellentesque lobortis dolor eu efficitur vulputate. Fusce id euismod nisi, eget fringilla mi. Mauris dictum orci erat, id gravida quam eleifend ut. Vestibulum sed tortor eget risus imperdiet pellentesque. Donec non eleifend tellus. Suspendisse erat metus, porta sed tellus quis, aliquam efficitur felis. Aenean quis tincidunt tellus. In hac habitasse platea dictumst. Fusce tincidunt lorem convallis, faucibus est iaculis, porta arcu."
    }

    let validated = validate input

    let expectedResult = ["is empty"; "is empty"; "longer than 160"]

    validated =! expectedResult
