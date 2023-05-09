module Exploration

type Person =
    { name: string
      nickname: string option }

let people =
    [ { name = "Homer"; nickname = None }
      { name = "Bart"
        nickname = Some "el Barto" } ]

let toUpper (s: string) = s.ToUpper()

let getNickname (person: Person) : string option = person.nickname

let countLength (s: string option) =
    match s with
    | None -> 0
    | Some value -> value.Length
let nicknameToLength = getNickname >> Option.map toUpper >> countLength
let getResults people =
     people
     |> List.map nicknameToLength
     |> List.max 
