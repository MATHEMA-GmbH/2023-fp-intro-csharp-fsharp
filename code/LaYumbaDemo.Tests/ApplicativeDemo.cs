using FluentAssertions;
using LaYumba.Functional;
using System.Linq;
using Xunit;
using static LaYumba.Functional.F;

namespace LaYumbaDemo.Tests
{
    public class ApplicativeDemo
    {
        [Fact]
        public void Sum_validation()
        {
            // Arrange
            int Sum(int a, int b, int c) => a + b + c;

            Validation<int> OnlyPositive(int i) =>
                i > 0
                    ? Valid(i)
                    : Error($"Number {i} is not positive.");

            Validation<int> AddNumbers(int a, int b, int c)
            {
                return Valid(Sum)              // returns int -> int -> int -> int
                    .Apply(OnlyPositive(a))    // returns int -> int -> int
                    .Apply(OnlyPositive(b))    // returns int -> int
                    .Apply(OnlyPositive(c));   // returns int
            }

            // Act
            var result = AddNumbers(1, 2, 3);

            // Assert
            result.Match(
                _ => true.Should().BeFalse(),
                x => x.Should().Be(6));
        }

        [Fact]
        public void Sum_validation_with_failures()
        {
            // Arrange
            int Sum(int a, int b, int c) => a + b + c;

            Validation<int> OnlyPositive(int i) =>
                i > 0
                    ? Valid(i)
                    : Error($"Number {i} is not positive.");

            Validation<int> AddNumbers(int a, int b, int c)
            {
                return Valid(Sum)              // returns int -> int -> int -> int
                    .Apply(OnlyPositive(a))    // returns int -> int -> int
                    .Apply(OnlyPositive(b))    // returns int -> int
                    .Apply(OnlyPositive(c));   // returns int
            }

            // Act
            var result = AddNumbers(-1, -2, -3);

            // Assert
            result.Match(
                errors => errors.Select(x => x.Message)
                    .Should().Contain("Number -1 is not positive.")
                    .And.Contain("Number -2 is not positive.")
                    .And.Contain("Number -3 is not positive."),
                _ => true.Should().BeFalse());
        }
    }
}