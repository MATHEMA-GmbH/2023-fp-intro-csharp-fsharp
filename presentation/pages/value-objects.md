## Immutability in C#  🧔🏻

Damit ein C# Objekt unveränderlich wird, muss gewährleistet sein, dass es auch **nach Erstellung nicht verändert wird**.

- interne Werte dürfen ausschließlich vom Konstruktor verändert werden
- kein public oder private setter
- kein parameterloser Konstrukor

---

### C# 9 and greater... 🧔🏻

C# records sind ein erster Schritt in die richtige Richtung:

- immutable
- Equality by structure

---

### Equality by structure 🧔🏻

Zwei Objekte sind gleich, wenn sie die gleichen Werte haben.

- `Equals` und `GetHashcode` überschreiben

```csharp
override bool Equals(Geld other)
    => other.Betrag   == this.Betrag &&
       other.Waehrung == this.Waehrung;

override int GetHashCode() { /* ... */ }
```

---

### Exkurs 🧔🏻

- manchmal genügt ein (leichtgewichtiges C#) record
- aber: eigentlich will man soviel Logik wie möglich in ein Objekt packen (OO, Value Objekt, DDD)
- (OO vs FP) und DDD
    - OO: Objekt mit Verhalten -> Ursprung von Value Objekt (und DDD)
    - FP: Strikte Trennung von Daten und Verhalten

Das Schöne an den unterschiedlichen Meinungen ist: 

- man kann es situationsbedingt einfach lösen 
- Und sich das Beste rauspicken
