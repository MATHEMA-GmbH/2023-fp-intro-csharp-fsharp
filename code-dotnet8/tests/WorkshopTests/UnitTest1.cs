using Workshop;

namespace WokshopTests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        // Arrange
        var input1 = 1;
        var input2 = 2;
        
        // Act
        var actual = Class1.Add(input1, input2);
        
        // Assert
        var expected = 3;
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void TestCalculateAvgIncomeOfPersonList()
    {
        // Arrange

        var list = new List<Person>()
        {
            new(17, 800),
            new(20, 1500),
            new(51, 7000),
            new(18, 2000)
        };
        // Act
        var result = list
            .Where(IstVolljährig())
            .Select(x=> x.Income)
            .Average();
        // Assert
        var expected = 3500.0;
        result.Should().Be(expected);
    }

    private static Func<Person, bool> IstVolljährig() => 
        x => x.Age >= 18;
}
