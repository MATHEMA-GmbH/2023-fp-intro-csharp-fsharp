module WorkshopFSharp

(*
- Die Anrede des Empfängers wird jetzt in Großbuchstaben ("ALL CAPS") umgewandelt, sofern vorhanden
- Es wird jetzt eine Menge von Grußkarten verarbeitet
- Für jeden Empfänger wird diese Umwandlung (potentiell) ausgeführt
*)

type Anrede = string
let ToUpper (anrede: Anrede): Anrede =
    if anrede = null then
        ""
    else
        anrede.ToUpper()

type Empfänger = {
    Anrede: Anrede option 
}
type Grußkarte = {
    Empfänger : Empfänger 
}
let GrußkarteToUpper (karten :Grußkarte list ) =
    List.map (fun g ->
        let e = g.Empfänger
        let a = e.Anrede
        let A = Option.map ToUpper  a
        let E = {
            e with Anrede = A 
        }
        let G = {
            g with Empfänger = E 
        }
        G
        ) karten
    
