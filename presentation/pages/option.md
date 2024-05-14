## Mögliches Vorhandensein eines Werts 🧑

#### oder: null ist gefährlich.

----

### Enthält die Signatur die ganze Wahrheit? 🧑

```csharp
// Enthält die Signatur die ganze Wahrheit?
public string Stringify<T>(T data)
{
    return null;
}
```

```csharp
// Sind Magic Values eine gute Idee?
public int Intify(string s)
{
    int result = -1;
    int.TryParse(s, out result);
    return result;
}
```

----

## Option 🧑

```fsharp
type Option<'T> = Some<'T> | None
```

- entweder ein Wert ist da - dann ist er in "Some" eingepackt
- oder es ist kein Wert da, dann gibt es ein leeres "None"
- alternative Bezeichnungen: Optional, Maybe

----

## Mit Option 🧑

```csharp
public Option<int> IntifyOption(string s)
{
    int result = -1;
    bool success = int.TryParse(s, out result);
    return success ? Some(result) : None;
}
```

----

### Wie komme ich an einen eingepackten Wert ran? 🧑

> **Pattern matching** allows you to match a value against some patterns to select a branch of the code.

```csharp
public string Stringify<T>(Option<T> data)
{
    return data.Match(
        None: () => "",
        Some: (existingData) => existingData.ToString()
    );
}
```

----

### Vorteile 🧑

- Explizite Semantik: Wert ist da - oder eben nicht
- Die Signatur von Match erzwingt eine Behandlung beider Fälle - nie wieder vergessene Null-Checks!
- Achtung: In C# bleibt das Problem, dass "Option" auch ein Objekt ist - und daher selbst null sein kann
- daher mindestens: in C# explizites NULL enablen mit `<Nullable>enable</Nullable>` 
