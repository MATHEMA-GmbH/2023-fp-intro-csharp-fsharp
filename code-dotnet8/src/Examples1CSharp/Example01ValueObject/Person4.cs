namespace Examples1CSharp.Example01ValueObject;

public class Person4(string name)
{
    public string FirstName { get; } = name;
    public string LastName { get; set; } = "";
}
