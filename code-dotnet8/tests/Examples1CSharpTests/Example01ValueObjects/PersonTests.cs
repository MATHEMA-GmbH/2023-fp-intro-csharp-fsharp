using Examples1CSharp.Example01ValueObject;

namespace Examples1CSharpTests.Example01ValueObjects;

public class PersonTests
{
    [Fact]
    public void Person1_is_mutable()
    {
        var person = new Person1("Homer");
        person.Name.Should().Be("Homer");
        person.Name = "Bart";
        person.Name.Should().Be("Bart");
    }

    [Fact]
    public void Person2_is_immutable()
    {
        var person = new Person2("Homer");
        person.Name.Should().Be("Homer");
        // person.Name = "Bart"; // Error: Won't compile
    }

    [Fact]
    public void Person3_is_immutable()
    {
        var person = new Person3("Homer");
        person.Name.Should().Be("Homer");
        // person.Name = "Bart"; // Error: Won't compile
    }
    
    [Fact]
    public void Person4_is_mutable()
    {
        var person = new Person4("Maggy");
        person.FirstName.Should().Be("Maggy");
        
        person.LastName = "Simpson";
        person.LastName.Should().Be("Simpson");
        
        person.LastName = "Burns"; // Valid but not recommended
    }

    [Fact]
    public void Person5_is_immutable()
    {
        var person = new Person5("Homer", "Simpson");
        person.FirstName.Should().Be("Homer");
        person.LastName.Should().Be("Simpson");
        // person.FirstName = "Bart"; // Error: Won't compile        
        // person.LastName = "Burns"; // Error: Won't compile
    }

    [Fact]
    public void Person6_is_mutable()
    {
        var person = new Person6 { FirstName = "Homer", LastName = "Simpson"};
        person.FirstName.Should().Be("Homer");
        person.LastName.Should().Be("Simpson");
        person.FirstName = "Bart";        
        person.LastName = "Burns";
        person.FirstName.Should().Be("Bart");
        person.LastName.Should().Be("Burns");
    }
    
    [Fact]
    public void Person7_is_immutable()
    {
        var person = new Person7 { FirstName = "Homer", LastName = "Simpson"};
        person.FirstName.Should().Be("Homer");
        person.LastName.Should().Be("Simpson");
        // person.FirstName = "Bart"; // Error: Won't compile        
        // person.LastName = "Burns"; // Error: Won't compile

        // Pro Tipp: You can use FluentAssertions `BeEquivalentTo` to compare objects
        var person5 = new Person5("Homer", "Simpson");
        person.Should().BeEquivalentTo(person5); // Comparing properties
    }
    
    [Fact]
    public void Person8_is_immutable()
    {
        var person = new Person8("Homer", "Simpson");
        person.FirstName.Should().Be("Homer");
        person.LastName.Should().Be("Simpson");
        // person.FirstName = "Bart"; // Error: Won't compile        
        // person.LastName = "Burns"; // Error: Won't compile
    }
    
    [Fact]
    public void Person5_is_comparable()
    {
        var homer = new Person5("Homer", "Simpson");
        var monty = new Person5("Monty", "Burns");
        homer.Should().NotBe(monty); // To be expected...
        var anotherHomer = new Person5("Homer", "Simpson");
        homer.Should().Be(anotherHomer); // This is cool!
    }

    [Fact]
    public void Person9_has_logic()
    {
        // Happy case
        var homer = Person9.Create("Homer", "Simpson");
        homer.Should().BeOfType<Person9>();
        
        // Invalid case
        Action action = () =>  Person9.Create("Monty", "Burns");
        action.Should().Throw<ArgumentException>().WithMessage("Ups. Invalid LastName 'Burns'");
    }
}
