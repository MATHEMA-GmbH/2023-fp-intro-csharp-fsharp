# Einführung in F# #

![img](/images/fsharp256.png)

----

## F# #

- Ursprünglich: Microsoft Forschungsprojekt
- Heute: Community-driven
- inspiriert von OCaml
- Multi-Paradigma
- Fokus auf funktionale Programmierung

<img
  class="absolute top-10 right-10 w-100"
  src="/images/fsharp256.png"
/>

----

## F# #

- erzwingt keine puren Funktionen, sondern erlaubt Seiteneffekte
- Statisch typisiert
- integriert ins .NET Ökosystem
- C# / VB.NET Interop

<img
  class="absolute top-10 right-10 w-100"
  src="/images/fsharp256.png"
/>

----

## Besonderheiten

- Significant whitespace
- Reihenfolge der Definitionen in Datei wichtig
- Reihenfolge der Dateien im Projekt wichtig

<img
  class="absolute top-10 right-10 w-100"
  src="/images/fsharp256.png"
/>

----

## Immutability als Default

```fsharp
// Achtung: = ist hier keine Zuweisung, sondern heißt 
// "linke und rechte Seite sind gleich und bleiben es auch immer"
// (oder wie in Mathe: "es sei x gleich 3")
let x = 3
let add a b = a + b
let m = if 3 > 0 then 7 else 42

// Mutability nur auf Wunsch - normalerweise unnötig
let mutable y = 3
y <- 42
```

----

## Typ-Inferenz

```fsharp
// Typen werden automatisch geschlussfolgert sofern möglich
let double a = a * 2 // int -> int

// Explizite Angaben möglich
let doubleExplicit (a: int) : int = a * 2
```

----

## Currying

> Currying ist die Umwandlung einer Funktion mit mehreren Parametern in eine neue Funktion mit nur einem Parameter, die wiederum eine Funktion zurückgibt mit dem Rest der Parameter.

```fsharp
// int -> int -> int -> int
// eigentlich: int -> (int -> (int -> int))
let addThree a b c = a + b + c
```

----

## Partial Application

- Eine Funktion mit mehreren Parametern bekommt nur einen Teil ihrer Argumente übergeben - der Rest bleibt offen und kann später ausgefüllt werden
- klappt nur so einfach wegen automatischem Currying in F#

```fsharp
// Partial Application
let add a b = a + b // int -> (int -> (int))
let add2 = add 2 // (int -> (int)), "a" ist mit 2 ausgefüllt, "b" ist noch offen
let six = add2 4 // (int)
let ten = add2 8 // (int)
```

----

## Pipe-Operator

```fsharp
// der letzte Parameter kann mit dem Ergebnis 
// der vorherigen Expression ausgefüllt werden
let triple a = a * 3
4 |> triple // ergibt 12
4 |> triple |> triple // ergibt 36
```

----

## Discriminated Unions

```fsharp
// Discriminated Unions ("Tagged Union", "Sum Type", "Choice Type")
type Vehicle = Bike | Car | Bus

// Pattern Matching zur Behandlung der verschiedenen Fälle
let vehicle = Bike
let laneText = 
  match vehicle with
  | Bike -> "Use the bike lane"
  | Car -> "Use the car driving lane"
  | Bus -> "The bus uses its own lane"

```

----

## Discriminated Unions mit Werten

```fsharp
// auch mit unterschiedlichen(!) Daten an jedem Fall möglich
type Shape =
    | Circle of float
    | Rectangle of float * float

let c = Circle 42.42

match c with
| Circle radius -> radius * radius * System.Math.PI
| Rectangle(width, height) -> width * height
```

----

## Record Types

```fsharp
// Record Type
type ShoppingCart = {
    products: Product list
    total: float
    createdAt: System.DateTime
}

// Typ muss nur angegeben werden wenn er nicht eindeutig ist
// hier wird er z.B. automatisch erkannt
let shoppingCart = {
    products = []
    total = 42.42
    createdAt = System.DateTime.Now
}
```

----

## ...Also known as...

- Discriminated Union
  - OR-Type
  - Sum-Type: Der Zustand ergibt sich aus der Summe der Auswahlmöglichkeiten (*)
- Record Type
  - AND-Type
  - Product-Type: Der Zustand ergibt sich aus dem kartesischen Produkt aller Möglichkeiten jedes Feldes (*)

(*) Algebraic Data Types

----

### Algebraic Data Types: Sum Type

```fsharp
type Vehicle = Bike | Car | Bus
```

Alle möglichen Zustände von `Vehicle` sind: `Bike`, `Car`, oder `Bus`. 

Dies entspricht der **Summe** der Auswahlmöglichkeiten.

----

### Algebraic Data Types: Product Type

```fsharp
type TruthTable {
  Wert1: bool
  Wert2: bool
}
```

Alle möglichen Zustände von `TruthTable` sind:

- `true`, `false`
- `true`, `true`
- `false`, `false`
- `false`, `true`

Diese Menge nennt man kartesisches **Produkt**.

----

## Record Types

- Immutable by default
- Unmöglich einen ungültigen Record zu erzeugen
- Structural Equality
- Hint: C# Value Objects out of the box
- ✨ seit C# 9: `records`

----

## Structural Equality

```fsharp
// Structural Equality
type Thing = {content: string; id: int}
let thing1 = {content = "abc"; id = 15}
let thing2 = {content = "abc"; id = 15}
let equal = (thing1 = thing2) // true
```

- Record Types mit Structural Equality sind ideal, um sehr kompakt "Value Objects" ausdrücken zu können

----

## Structural Equality vs. DDD Aggregates

- Möchte man die Standard-Equality nicht, ist es best practice, Equality und Comparison zu verbieten
- dann muss explizit auf eine Eigenschaft verglichen werden (z.B. die Id)

```fsharp
[<NoEquality; NoComparison>]
type NonEquatableNonComparable = {
    Id: int
}

let compare n1 n2 = (n1.Id = n2.Id)
```
