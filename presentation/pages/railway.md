## Praktische Anwendung: Railway Oriented Programming

Funktionale Programmierung wird oft als "Zusammenstecken" von Funktionen dargestellt...

---

Beispiel:

```txt
f1: Eingabe string, Ausgabe int
f1: string -> int // FP Syntax

f2: Eingabe int, Ausgabe bool
f2: int -> bool // FP Syntax
```

---

```csharp
// Klassisch ===========================================================
int F1(string s) => int.TryParse(s, out var i) ? i : 0;
bool F2(int i) => i > 0;

// "verschachtelter" Aufruf
F2(F1("1")) // -> true
F2(F1("0")) // -> false

// "composition"
bool F3(string s) => F2(F1(s));
```

```csharp
// Method Chaining =====================================================
// mit C# extension methods
static int F1(this string s) => int.TryParse(s, out var i) ? i : 0;
static bool F2(this int i) => i > 0;

// Lesbarer (erst F1, dann F2)
"1".F1().F2() // ->true
"0".F1().F2() // ->false

// Lesbarer (erst F1, dann F2)
bool F3(string s) => s.F1().F2();
```

---

Problem: Keine standardisierte Strategie für Fehlerbehandlung 

- Wenn wir davon ausgehen, dass Funktionen auch einen Fehlerfall haben, benötigen wir einen **neuen Datentyp**, der das abbilden kann

---

#### Result/Either

- kann entweder 
  - das Ergebnis beinhalten, oder 
  - einen Fehlerfall
- `Either` besteht aus zwei Teilen
  - `Left`
  - `Right` ("richtig"...)
- `Result` besteht aus zwei Teilen
  - `Failure`
  - `Success`

---

- In Railway-Sprech bedeutet dass, dass man "zweigleisig" fährt:
- Jede **Funktion** bekommt eine Eingabe, und 
  - hat "im Bauch" eine Weiche, die entscheidet ob 
    - auf das Fehlergleis oder 
    - auf das Erfolgsgleis umgeschaltet wird.
- Die Wrapperklasse mit der **Funktion** ist das Entscheidende!

---

- In anderen Worten: die Funktionen haben aktuell 1 Eingabe (1 Gleis), und 2 Ausgaben (2 Gleise)

<img
  class="absolute bottom-50 left-10 w-200"
  src="/images/rop-tracks-Page-2.png"
/>


---

- Man benötigt also einen Mechanismus, der eine 2-gleisige Ausgabe so umwandelt, dass eine Funktion, die eine 1-gleisige Eingabe erwartet, damit umgehen kann

<img
  class="absolute bottom-10 left-20 w-180"
  src="/images/rop-tracks-Page-4.png"
/>

---

#### Was muss dieser Mechanismus können?

- wenn die Eingabe fehlerhaft ist, muss die Funktion nichts tun, und kann den Fehler weiterreichen
- wenn die Eingabe nicht fehlerhaft ist, wird der Wert an die Funktion gegeben
- Das ist genau die **Monade** mit ihrem **bind**
- Damit können wir elegant beliebig lange Ketten bauen
