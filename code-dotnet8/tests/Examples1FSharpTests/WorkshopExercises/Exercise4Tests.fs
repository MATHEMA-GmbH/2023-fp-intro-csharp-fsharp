module Exercise4Tests

open Exercise4
open Swensen.Unquote
open Xunit

let erstelleGültigeGrußkarte
    (vorname:string)
    (nachname:string)
    (anrede:string)
    (anschrift:string)
    (grußkartentest:string) : Grußkarte =
    {
        Empfänger = {
            Vorname = Vorname.create vorname |> Option.get
            Nachname = Nachname.create nachname |> Option.get
            Anrede = Anrede.create anrede
            Postanschrift = Postanschrift.create anschrift |> Option.get
        }
        Grußkartentext = Grußkartentext.create grußkartentest |> Option.get
    }
    
let homer = erstelleGültigeGrußkarte "Homer" "Simpson" "Herr" "Evergreen Terrace 742" "Hallo Welt"

let drucken grußkarte = Ok grußkarte
let verpacken grußkarte = Ok grußkarte
let versenden grußkarte = Ok grußkarte

let druckenFehler grußkarte = Error "Drucken fehlgeschlagen"
let verpackenFehler grußkarte = Error "Verpacken fehlgeschlagen"
let versendenFehler grußkarte = Error "Versenden fehlgeschlagen"

[<Fact>]
let ``Workflow happy path`` () =
    let actual = workflowApi drucken verpacken versenden homer 
    let expected = Ok homer
    actual =! expected

[<Fact>]
let ``Workflow mit Druckfehler`` () =
    let actual = workflowApi druckenFehler verpacken versenden homer 
    let expected = Error "Drucken fehlgeschlagen"
    actual =! expected
    
[<Fact>]
let ``Workflow mit Packfehler`` () =
    let actual = workflowApi drucken verpackenFehler versenden homer 
    let expected = Error "Verpacken fehlgeschlagen"
    actual =! expected
    
[<Fact>]
let ``Workflow mit Versandfehler`` () =
    let actual = workflowApi drucken verpacken versendenFehler homer 
    let expected = Error "Versenden fehlgeschlagen"
    actual =! expected
