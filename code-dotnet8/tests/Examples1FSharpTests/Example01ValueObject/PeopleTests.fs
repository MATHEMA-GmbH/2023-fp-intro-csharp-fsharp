module Examples1FSharpTests.Example01ValueObject.PeopleTests

open Examples1FSharp.Example01ValueObject.People
open Swensen.Unquote
open Xunit

[<Fact>]
let ``Person1 is immutable`` () =
    let homer =  { Person1.FirstName = "Homer"; LastName = "Simpson"}
    // homer.FirstName <- "Bart"  // Error: Won't compile
    true =! true

[<Fact>]
let ``Person1 is comparable`` () =
    let homer1 =  { Person1.FirstName = "Homer"; LastName = "Simpson"}
    let homer2 =  { Person1.FirstName = "Homer"; LastName = "Simpson"}
    homer1 =! homer2
    
[<Fact>]
let ``Person2 has logic`` () =
    // test helper method
    let hasValidNames (input: Person2 option) i =
        match input with
        | None -> true =! false // fail, should have been valid
        | Some x -> Person2.value x =! i // pass, should have been valid

    let validPerson = Person2.create "Homer" "Simpson"
    hasValidNames validPerson ("Homer", "Simpson")
    
    let invalidPerson = Person2.create "Homer" ""
    invalidPerson =! None
