## "Programming Patterns" in FP

![Scott Wlaschin shows FP patterns in one of his talks](/images/patterns-and-principles-in-fp.png)

----

## Kleine Funktionen zu größeren verbinden

- Gängige Vorgehensweise: Kleine Funktionen werden zu immer größeren Funktionalitäten zusammengesteckt ("Komposition")
- Problem: Nicht alle Funktionen passen gut zusammen

----

### Problem: Wert in Container, Funktion kann nichts damit anfangen


```csharp
// C#
using LaYumba.Functional;
using static LaYumba.Functional.F;

static class X
{
  string ToUpper(string s) => s.ToUpper();

  Option<string> StringToOption(string s)
    => string.IsNullOrEmpty(s) ? None : Some(s)

  NonEmptyStringToUpper(string s)
  {
    var nonEmpty = StringToOption(s);
    // passt nicht: "string" erwartet, aber "string option" bekommen
    return ToUpper(s);
  }
}
```

----


```fsharp
// F#
module X

let toUpper (s: string) : string = s.ToUpper()

let stringToOption (s: string) : string option =
    if String.IsNullOrWhiteSpace s then
        None
    else
        Some s

let nonEmptyStringToUpper (s: string) : ??? =
    let nonEmpty = stringToOption s
    // passt nicht: "string" erwartet, aber "string option" bekommen
    let nonEmptyUpper = toUpper nonEmpty
```

----

### Funktor ("Mappable")

![img](/images/Funktor_1.png)

----

### Funktor ("Mappable")

- Container mit "map" Funktion (die bestimmten Regeln folgt): "Mappable"
- Bezeichnung in der FP-Welt: **Funktor**

```fsharp
  map: (a -> b) -> F a -> F b
```

- Andere Bezeichnungen für "map": fmap (z.B. in Haskell), Select (LINQ), &lt;$&gt;, &lt;!&gt;

----

### Funktor = Lösung für "Wert in Container, Funktion kann nichts damit anfangen"

- Option.map
- List.map, Seq.map, Result.map, ...

```fsharp
let toUpper (s: string) : string = s.ToUpper()

let stringToOption (s: string) : string option =
    if String.IsNullOrWhiteSpace s then
        None
    else
        Some s

let nonEmptyStringToUpper (s: string) : string option =
    let nonEmpty = stringToOption s
    let nonEmptyUpper = Option.map toUpper nonEmpty
```
