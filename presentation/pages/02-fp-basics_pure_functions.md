## FP 101 - Pure Functions 🧔🏻

### Pure Functions in C# #

- haben keine Seiteneffekte
- sollten immer nach `static` umwandelbar sein

---

## Imperativ... 🧔🏻

**Wie** mache ich etwas 

```csharp
var people = new List<Person>();
{
    new Person { Age = 20, Income = 1000 },
    new Person { Age = 26, Income = 1100 },
    new Person { Age = 35, Income = 1300 }
};

var incomes = new List<int>();
foreach (var person in people)
{
    if (person.Age > 25)
        incomes.Add(person.Income);
}

var avg = incomes.Sum() / incomes.Count;
```

versus...

----

## Deklarativ 🧔🏻

**Was** will ich erreichen?

Bsp: Filter / Map / Reduce

```csharp
var people = new List<Person> {
  new Person { Age = 20, Income = 1000 },
  new Person { Age = 26, Income = 1100 },
  new Person { Age = 35, Income = 1300 }
}

var averageIncomeAbove25 = people
  .Where(p => p.Age > 25) // "Filter"
  .Select(p => p.Income)  // "Map"
  .Average();             // "Reduce"
```

- aussagekräftiger
- weniger fehleranfällig

---

## Pure functions in LINQ 🧔🏻

- ihr macht schon FP: LINQ und Lambdas!