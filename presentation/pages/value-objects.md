# Value Objects

----

## Value Objects

Warum?

- Methoden sollten nicht lügen!
  - Null: NullPointerException, Null-Checks
  - Antipattern: Primitive Obsession

----

### Beispiele

```csharp
// 😡
void Einzahlen(int wert, SomeEnum waehrung) { /* ... */ }

// 😀
void Einzahlen(Geld geld) { /* ... */ }
```

```csharp
class Kunde {
    int Alter { get; set; } // 😡
    
    // ist `i` das aktuelle Alter oder das Geburtsjahr??
    bool IstVolljaehrig(int i) { /* ... */}
}

class Kunde {
    Alter Alter { get; set; } // 😀

    bool IstVolljaehrig(Alter alter) { /* ... */}

    bool IstVolljaehrig(Geburtsjahr geburtsjahr) { /* ... */}
}
```

---

![img](/images/wikipedia-value-objects.png)

---

## Value Objects

- nur gültige Objekte erlaubt
- immutable
- equality by structure

---

### Nur gültige Objekte

Es muss bei der Erstellung gewährleistet sein, dass das Objekt gültig ist.

---

### Nur gültige Objekte

Optionen:

- Konstruktor mit allen Parametern
- statische Hilfsmethode & privater Konstruktor

---

#### Value Objects erstellen / 1

```csharp
class Geld 
{
    int Betrag { get; }
    Waehrung Waehrung { get; }

    Geld(int betrag, Waehrung waehrung) {
        if (!IsValid(betrag, Waehrung)) 
            throw new InvalidGeldException();

        Betrag = betrag;
        Waehrung = waehrung;
    }

    bool IsValid(int betrag, Waehrung waehrung)
        => betrag > 0 && waehrung != Waehrung.Undefined;
}
```

---

#### Value Objects erstellen / 2

```csharp
class Geld 
{
    int Betrag { get; }
    Waehrung Waehrung { get; }

    static Geld Create(int betrag, Waehrung waehrung) {
        return new Geld(betrag, waehrung);
    }

    // private ctor
    private Geld(int betrag, Waehrung waehrung) {
        if (!IsValid(betrag, Waehrung)) 
            throw new InvalidGeldException();

        Betrag = betrag;
        Waehrung = waehrung;
    }

    bool IsValid(int betrag, Waehrung waehrung)
        => betrag > 0 && waehrung != Waehrung.Undefined;
}
```

---

### Immutability

Damit ein C# Objekt unveränderlich wird, muss gewährleistet sein, dass es auch **nach Erstellung nicht verändert wird**.

- interne Werte dürfen ausschließlich vom Konstruktor verändert werden
- kein public oder private setter
- kein parameterloser Konstrukor

---

### Equality by structure

Zwei Objekte sind gleich, wenn sie die gleichen Werte haben.

---

### Exkurs: Vergleichbarkeit

- Equality by reference
- Equality by id
- Equality by structure

---

### Equality by structure

Zwei Objekte sind gleich, wenn sie die gleichen Werte haben.

- `Equals` und `GetHashcode` überschreiben

```csharp
override bool Equals(Geld other)
    => other.Betrag   == this.Betrag &&
       other.Waehrung == this.Waehrung;

override int GetHashCode() { /* ... */ }
```

---

### C# 9 and greater...

C# records sind ein erster Schritt in die richtige Richtung:

- immutable

---

### Exkurs

- manchmal genügt ein (leichtgewichtiges C#) record
- aber: eigentlich will man soviel Logik wie möglich in ein Objekt packen (OO, Value Objekt, DDD)
- (OO vs FP) und DDD
    - OO: Objekt mit Verhalten -> Ursprung von Value Objekt (und DDD)
    - FP: Strikte Trennung von Daten und Verhalten

Das Schöne an den unterschiedlichen Meinungen ist: 

- man kann es situationsbedingt einfach lösen 
- Und sich das Beste rauspicken
