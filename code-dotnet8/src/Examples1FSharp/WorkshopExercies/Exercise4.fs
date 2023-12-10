module Exercise4

type Vorname = private Vorname of string

module Vorname =
    let create (vorname:string) =
        if vorname.Length > 0 then
            Some (Vorname vorname)
        else
            None

    let get (Vorname vorname) = vorname
    
type Nachname = private Nachname of string

module Nachname =
    let create (nachname:string) =
        if nachname.Length > 0 then
            Some (Nachname nachname)
        else
            None

    let get (Nachname nachname) = nachname
    
type Anrede = private Anrede of string

module Anrede =
    let create (anrede:string) =
        if anrede.Length > 0 then
            Some (Anrede anrede)
        else
            None

    let get (Anrede anrede) = anrede

type Postanschrift = private Postanschrift of string

module Postanschrift =
    let create (postanschrift:string) =
        if postanschrift.Length > 0 then
            Some (Postanschrift postanschrift)
        else
            None

    let get (Postanschrift postanschrift) = postanschrift

type Empfänger = {
    Vorname: Vorname
    Nachname: Nachname
    Anrede: Anrede option
    Postanschrift: Postanschrift
}

type Grußkartentext = private Grußkartentext of string

module Grußkartentext =
    let create (grußkartentext:string) =
        if grußkartentext.Length > 0 then
            Some (Grußkartentext grußkartentext)
        else
            None

    let get (Grußkartentext grußkartentext) = grußkartentext

type Grußkarte = {
    Empfänger: Empfänger
    Grußkartentext: Grußkartentext
}

type Drucken = Grußkarte -> Result<Grußkarte, string>
type Verpacken = Grußkarte -> Result<Grußkarte, string>
type Versenden = Grußkarte -> Result<Grußkarte, string>

type Workflow =
    Grußkarte
     -> Drucken
     -> Verpacken
     -> Versenden
     -> Result<Grußkarte, string> 

let workflow : Workflow =
    fun grußkarte drucken verpacken versenden ->
        grußkarte
        |> drucken
        |> Result.bind verpacken
        |> Result.bind versenden
        
let workflowApi drucken verpacken versenden grußkarte =
    workflow grußkarte drucken verpacken versenden
