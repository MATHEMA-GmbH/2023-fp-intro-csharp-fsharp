module FSharp8Features

// _.Property shorthand for (fun x -> x.Property)
//
// https://devblogs.microsoft.com/dotnet/announcing-fsharp-8/#_-property-shorthand-for-fun-x-x-property
type Person = {Name : string; Age : int}
let people = [ {Name = "Joe"; Age = 20} ; {Name = "Will"; Age = 30} ; {Name = "Joe"; Age = 51}]

let beforeThisFeature = 
    people 
    |> List.distinctBy (fun x -> x.Name)
    |> List.groupBy (fun x -> x.Age)
    |> List.map (fun (x,y) -> y)
    |> List.map (fun x -> x.Head.Name)
    |> List.sortBy (fun x -> x.ToString())

let possibleNow = 
    people 
    |> List.distinctBy _.Name
    |> List.groupBy _.Age
    |> List.map snd
    |> List.map _.Head.Name
    |> List.sortBy _.ToString()

// Nested record field copy and update
//
// https://devblogs.microsoft.com/dotnet/announcing-fsharp-8/#nested-record-field-copy-and-update
type SteeringWheel = { Type: string }
type CarInterior = { Steering: SteeringWheel; Seats: int }
type Car = { Interior: CarInterior; ExteriorColor: string option }

let beforeThisFeature' x = 
    { x with Interior = { x.Interior with 
                            Steering = {x.Interior.Steering with Type = "yoke"}
                            Seats = 5
                        }
    }

let withTheFeature x = { x with Interior.Steering.Type = "yoke"; Interior.Seats = 5 }
