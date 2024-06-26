using CSharpDemos.ValueObjects;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using LaYumba.Functional;

namespace CSharpDemos.Tests.TestHelper
{
    public static class NonEmptyStringTestExtensions
    {
        public static NonEmptyStringAssertions Should(this Option<NonEmptyStringVO> instance)
        {
            return new NonEmptyStringAssertions(instance);
        }
    }

    public class NonEmptyStringAssertions
        : ReferenceTypeAssertions<Option<NonEmptyStringVO>, NonEmptyStringAssertions>
    {
        public NonEmptyStringAssertions(Option<NonEmptyStringVO> instance)
        : base(instance)
        {
        }

        protected override string Identifier => "nonEmptyString";

        public AndConstraint<NonEmptyStringAssertions> BeEqualToNonEmptyString(
            string otherString,
            string because = "",
            params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(!string.IsNullOrWhiteSpace(otherString))
                .FailWith("You can't compare NonEmptyString if you provide an empty NonEmptyString.")
                .Then
                .Given(() => Subject)
                .ForCondition(opt => opt.Match(
                    () => false,
                    x => x.Value == otherString))
                .FailWith("Expected {context:nonEmptyString} to be {0}{reason}, but found {1}",
                    otherString, Subject);

            return new AndConstraint<NonEmptyStringAssertions>(this);
        }

        public AndConstraint<NonEmptyStringAssertions> NotBeEqualNonEmptyString(
            string otherString,
            string because = "",
            params object[] becauseArgs)
        {
            Execute.Assertion
                .Given(() => Subject)
                .ForCondition(opt => opt.Match(
                    () => false,
                    x => x.Value != otherString))
                .FailWith("Expected {context:nonEmptyString} not to be {0}{reason}, but found {1}",
                    otherString, Subject);

            return new AndConstraint<NonEmptyStringAssertions>(this);
        }

        public AndConstraint<NonEmptyStringAssertions> BeNone(
            string because = "",
            params object[] becauseArgs)
        {
            Execute.Assertion
                .Given(() => Subject)
                .ForCondition(opt => opt.Match(
                    () => true,
                    x => x.Value == null))
                .FailWith("Expected {context:nonEmptyString} to be None {reason}, but found {0}",
                    Subject);

            return new AndConstraint<NonEmptyStringAssertions>(this);
        }
    }
}