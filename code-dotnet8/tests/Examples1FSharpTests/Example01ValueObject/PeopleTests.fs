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
    let hasValidNames (maybePerson: Person2 option) expectedPerson =
        match maybePerson with
        | None ->
            true =! false // fail
        | Some actualPerson ->
            Person2.value actualPerson =! expectedPerson // pass

    let validPerson = Person2.create "Homer" "Simpson"
    hasValidNames validPerson ("Homer", "Simpson")
    
    let invalidPerson = Person2.create "Homer" ""
    invalidPerson =! None
