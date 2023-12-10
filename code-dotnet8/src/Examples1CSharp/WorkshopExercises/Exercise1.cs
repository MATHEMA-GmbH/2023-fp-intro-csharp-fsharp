namespace Examples1CSharp.WorkshopExercises;

public static class Exercise1
{
    public static double CalculateAverageSalary(IEnumerable<Person> people) =>
        people
            .Where(person => person.IsAdult())
            .Average(person => person.Salary.Value);
}

// Immutable
public record Person(Age Age, Salary Salary)
{
    public bool IsAdult() => Age.IsAdult();
}

// Immutable Value Object (contains validation logic)
public record Age
{
    private Age(int value)
    {
        Value = value;
    }

    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public int Value { get; }

    public static Age Create(int value)
    {
        if (!IsValid(value))
        {
            throw new ArgumentException($"Ups. Invalid Age '{value}'");
        }

        return new Age(value);
    }

    private static bool IsValid(int age) => age > 0;
    
    public bool IsAdult() => Value >= 18;
}

// Immutable
public record Salary(int Value);
