// using CSharpDemos.Tests.TestHelper;
using CSharpDemos.ValueObjects;
using FluentAssertions;
using Xunit;

namespace CSharpDemos.Tests.ValueObjects
{
    public class NonEmptyStringTests
    {
        [Fact]
        public void Empty_returns_None()
        {
            NonEmptyStringVO.Create("").Match(() => true, x => false);
            NonEmptyStringVO.Create(null).Match(() => true, _ => false);
        }

        [Fact]
        public void Valid_returns_Some()
        {
            // version 1
            NonEmptyStringVO.Create("a").Match(
                () => false,
                _ => true);

            // version 2
            //NonEmptyStringVO.Create("a").Should(). BeEqualToNonEmptyString("a");
        }

        [Fact]
        public void Valid_has_correct_content()
        {
            // version 1
            NonEmptyStringVO.Create("a").Match(
                () => "a".Should().Be("b"),
                x => x.ToString().Should().Be("a"));

            // version 2
            // NonEmptyString.Create("").Should().BeNone();
        }
    }
}