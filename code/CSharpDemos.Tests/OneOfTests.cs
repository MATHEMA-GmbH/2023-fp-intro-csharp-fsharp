using System.Collections.Generic;
using FluentAssertions;
using OneOf;
using Xunit;

namespace CSharpDemos.Tests;

public class OneOfTests
{
    private static OneOf<int, string, bool> DoMagic(string s)
    {
        if (s == "a") return 42;
        if (s == "b") return "B";
        return false;
    }
    
    [Theory]
    [MemberData(nameof(SampleData1))]
    public void Returning_OneOf(string input, OneOf<int, string, bool> expected) => 
        DoMagic(input).Should().Be(expected);

    public static IEnumerable<object[]> SampleData1()
    {
        yield return new object[] {"a", 42 };
        yield return new object[] {"b", "B"};
        yield return new object[] {"c", false};
    }

    [Theory]
    [MemberData(nameof(SampleData2))]
    public void Matching_OneOf(string input, string expected)
    {
        var response = DoMagic(input);
        
        var result = response.Match(
            number => $"The number is {number}",
            word => $"The word is {word}",
            boolean => $"The boolean is {boolean}"
        );
        
        result.Should().Be(expected);
    }

    public static IEnumerable<object[]> SampleData2()
    {
        yield return new object[] {"a", "The number is 42" };
        yield return new object[] {"b", "The word is B"};
        yield return new object[] {"c", "The boolean is False"};
    }

    [Fact]
    public void CustomOneOfTypeTest()
    {
        StringOrNumber x = 5;
        x.TryGetNumber().number.Should().Be(5);

        x = "5";
        x.TryGetNumber().number.Should().Be(5);

        x = "abc";
        x.TryGetNumber().isNumber.Should().BeFalse();
    }
    
    
    public class StringOrNumber : OneOfBase<string, int>
    {
        private StringOrNumber(OneOf<string, int> _) : base(_)
        {
        }

        public static implicit operator StringOrNumber(string _) => new(_);
        public static implicit operator StringOrNumber(int _) => new(_);

        public (bool isNumber, int number) TryGetNumber() =>
            Match(
                s => (int.TryParse(s, out var n), n),
                i => (true, i));
    }
}