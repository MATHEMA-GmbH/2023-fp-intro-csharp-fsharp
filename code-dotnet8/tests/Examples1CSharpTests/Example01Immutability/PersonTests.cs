using Examples1CSharp.Example01Immutability;

namespace Examples1CSharpTests.Example01Immutability;

public class PersonTests
{
    [Fact]
    public void Person1_is_mutable()
    {
        var person1 = new Person1("John");
        person1.Name.Should().Be("John");
        person1.Name = "Jane";
        person1.Name.Should().Be("Jane");
    }
}
