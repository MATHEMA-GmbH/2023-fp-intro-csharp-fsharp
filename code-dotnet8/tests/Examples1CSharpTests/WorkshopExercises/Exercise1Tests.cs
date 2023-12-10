using Examples1CSharp.WorkshopExercises;

namespace Examples1CSharpTests.WorkshopExercises;

public class Exercise1Tests
{
    [Fact]
    public void Calculate_Average_Salary_works()
    {
        Person[] people = {
            new(Age.Create(10), new Salary(1000)),
            new(Age.Create(20), new Salary(2000)),
            new(Age.Create(30), new Salary(3000)),
            new(Age.Create(40), new Salary(4000)),
            new(Age.Create(50), new Salary(5000)),
        };

        var averageSalary = Exercise1.CalculateAverageSalary(people);

        averageSalary.Should().Be(3500);
    }
}
