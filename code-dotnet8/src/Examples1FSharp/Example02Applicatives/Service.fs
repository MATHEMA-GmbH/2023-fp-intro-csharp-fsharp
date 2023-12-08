module Examples1FSharp.Example02Applicatives.Service

open System

// Example with FSharpPlus: https://fsprojects.github.io/FSharpPlus/type-validation.html
// deeper explanation: https://dev.to/choc13/grokking-applicative-validation-lh6

// https://www.trustbit.tech/blog/2019/12/09/functional-validation-in-f-using-applicatives
let apply fResult xResult = 
    match fResult,xResult with
    | Ok f, Ok x -> Ok (f x)
    | Error ex, Ok _ -> Error ex
    | Ok _, Error ex -> Error ex
    | Error ex1, Error ex2 -> Error (List.concat [ex1; ex2])

type Errors = String list

type InputDto = {
    receiverFirstName : String
    receiverLastName : String
    receiverTitle : String
    receiverAddress : String
    text : String
}

let notEmpty (s: String): Result<String, Errors> =
    if String.IsNullOrWhiteSpace s then
        Error ["is empty"]
    else
        Ok s

let shorterThan160 (s: String): Result<String, Errors> =
    if s.Length < 160 then
        Ok s
    else
        Error ["longer than 160"]

type NonEmptyString = NonEmptyString of String
let createNonEmptyString (s : String) : Result<NonEmptyString, Errors> =
    notEmpty s
    |> Result.map NonEmptyString

type Kartentext = Kartentext of String
let createKartentext (s : String) : Result<Kartentext, Errors> =
    let ne = notEmpty s
    let st = shorterThan160 s

    // necessary because we validate the same input value twice but need only one
    let ignoreSecondArgumentAndCreateText = fun s1 _ -> Kartentext s1

    Ok ignoreSecondArgumentAndCreateText
        |> apply <| ne
        |> apply <| st

type Empfaenger = {
    Vorname : NonEmptyString
    Nachname : NonEmptyString
    Postanschrift: NonEmptyString
    Anrede: NonEmptyString option
}

type Karte = {
    Empfaenger : Empfaenger
    Text : Kartentext
}

let noneIfEmpty (s: String): NonEmptyString option =
    match (createNonEmptyString s) with
    | Ok nes -> Some nes
    | Error _ -> None

let createEmpfaenger vorname nachname postanschrift anrede =
    {
        Vorname = vorname
        Nachname = nachname
        Postanschrift = postanschrift
        Anrede = anrede
    }

let createKarte empfaenger text =
    {
    Empfaenger = empfaenger
    Text = text
    }

let validate (input : InputDto) : String list = 
    let empfaenger = 
        Ok createEmpfaenger
        |> apply <| createNonEmptyString input.receiverFirstName
        |> apply <| createNonEmptyString input.receiverLastName
        |> apply <| createNonEmptyString input.receiverAddress
        |> apply <| (Ok (noneIfEmpty input.receiverTitle))

    let kartentext = createKartentext input.text

    let karte = 
        Ok createKarte
        |> apply <| empfaenger
        |> apply <| kartentext

    match karte with
    | Ok _ -> []
    | Error errors -> errors
