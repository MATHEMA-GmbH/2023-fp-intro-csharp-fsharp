namespace Examples1CSharp.Example01ValueObject;

// Good practice
public record Person5(string FirstName, string LastName);

public record Person6
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
}

// Good practice
public record Person7
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
}

public record Person8
{
    public Person8(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; }
    public string LastName { get; }
}

public record Person9
{
    // Private constructor!
    private Person9(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    // Smart constructor
    public static Person9 Create(string firstName, string lastName)
    {
        if (!IsValid(firstName, lastName))
        {
            throw new ArgumentException($"Ups. Invalid LastName '{lastName}'");
        }
        
        return new Person9(firstName, lastName);
    }
    
    private static bool IsValid(string _, string lastName)
    {
        // Some validation logic
        return lastName != "Burns";
    }
    
    public string FirstName { get; }
    public string LastName { get; }
}
