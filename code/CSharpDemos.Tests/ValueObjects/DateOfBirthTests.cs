using CSharpDemos.ValueObjects;
using FluentAssertions;
using FluentAssertions.Extensions;
using Xunit;

namespace CSharpDemos.Tests.ValueObjects
{
    public class DateOfBirthTests
    {
        [Fact]
        public void Formatting() =>
            new DateOfBirthVO(31.December(1900).At(23, 59, 59))
                .ToString()
                .Should()
                .Be("1900-12-31");
    }
}