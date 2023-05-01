## FP 101 - functions

### 1st class functions in C# #

Funktionen können als Parameter verwendet werden

---

...Ähnlichkeit mit Interfaces in der OO-Welt...

---

#### Strategy-Pattern

```csharp
interface ICalculateSalary
{
  int ByInput(int i);            // <- Methodensignatur
}

class Manager: ICalculateSalary
{
  int ByInput(int i) => i*2;     // <- Implementierung
}
```

```csharp
class SomeService
{
  int DoSomething(ICalculateSalary salary, int i) 
    => salary.ByInput(i);        // <- "deligiert"
}
```

(Verhalten als Parameter übergeben)
