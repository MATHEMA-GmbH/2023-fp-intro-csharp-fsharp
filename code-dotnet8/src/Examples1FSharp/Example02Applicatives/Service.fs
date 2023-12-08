module Examples1FSharp.Example02Applicatives.Service

open System

type Errors = String list

type InputDto = {
    receiverFirstName : String
    receiverLastName : String
    receiverTitle : String
    receiverAddress : String
    text : String
}

type NonEmptyString = NonEmptyString of String
type Kartentext = Kartentext of String

let createNonEmptyString (s : String) : Result<NonEmptyString, Errors> =
    // TODO: validation
    Ok (NonEmptyString s)

let createKartentext (s : String) : Result<Kartentext, Errors> =
    // TODO: validation
    Ok (Kartentext s)

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

let validate (input : InputDto) : Result<Karte, Errors> = 
    // intern Kette: Result<Karte, Errors>
    // dann Fehler extrahieren und zurückgeben
    Error []
