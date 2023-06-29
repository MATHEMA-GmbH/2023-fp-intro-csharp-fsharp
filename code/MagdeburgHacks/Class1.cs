using FluentAssertions;
using LaYumba.Functional;
using Xunit;
using static LaYumba.Functional.F;

namespace MagdeburgHacks
{
    public record Person(Name FirstName, DateOnly Birthday, Option<Name> Nickname)
    {
        public static int FilterByBirthday(IEnumerable<Person> persons, DateOnly date)
        {
            return persons.Count(person => person.Birthday == date);
        }
    }

    public class PrintService
    {
        public static Either<string, PostalCard> Print(string message)
        {
            var isValid = message.Length % 2 == 0;
            return isValid ? Right(new PostalCard(message)) : Left("Message is invalid.");
        }
    }

    public record PostalCard(string Message);

    public record Letter(PostalCard PostalCard);

    public record Email(string Message);

    public class PostService
    {
        public static Either<string, Letter> Send(PostalCard postalCard)
        {
            var isValid = postalCard.Message.Length < 5;
            return isValid ? Right(new Letter(postalCard)) : Left("PostalCard is too long.");
        }
    }

    public class EmailService
    {
        public static string Send(Either<string, Letter> message)
        {
            return message.Match(
                l => $"Error: {l}",
                letter => letter.PostalCard.Message
            );
        }
    }


    public class Greeting
    {
        public static string Greet(Person person, Func<Person, string> projection)
        {
            return projection(person);
        }
    }

    public record Name
    {
        public string Value { get; }

        private Name(string value)
        {
            Value = value;
        }

        public static Option<Name> Create(string value)
        {
            var r = new Name(value);
            return IsValid(value) ? Some(r) : None;
        }

        private static bool IsValid(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }


    public class SomeTest
    {
        [Fact]
        public void NameIsConstructable()
        {
            Action action = () => _ = Name.Create("Bart");
            action.Should().NotThrow<Exception>();
        }

        [Fact]
        public void NameIsConstructableWrongNameInputThrowsException()
        {
            var actual = Name.Create("");
            actual.Match(
                None: () => true.Should().BeTrue(),
                Some: x => throw new());
        }

        [Fact]
        public void Greet_Test()
        {
            var greet = Greeting.Greet(
                new(Name.Create("egal").Unwrap(), DateOnly.MaxValue, None),
                person => "Hallo " + person.FirstName.Value);
            greet.Should().Be("Hallo egal");
        }

        [Fact]
        public void FilterByBirthdayTest()
        {
            var persons = new List<Person>
            {
                new(Name.Create("F1").Unwrap(), DateOnly.MaxValue, None),
                new(Name.Create("F2").Unwrap(), new(2000, 01, 01), None),
                new(Name.Create("F3").Unwrap(), new(2000, 05, 01), None),
            };

            var count = Person.FilterByBirthday(persons, new(2000, 1, 1));


            count.Should().Be(1);
        }

        [Fact]
        public void WorkflowTest()
        {
            var text = "hi";
            var letter = PrintService
                .Print(text)
                .Bind(PostService.Send)
                .Match(Left: s => s,
                    Right: letter1 => letter1.PostalCard.Message);
            var actual = EmailService.Send(letter);
            
            actual.Should().Be("Error: hi");
        }
    }

    public static class TestExtensions
    {
        public static T Unwrap<T>(this Option<T> opt)
        {
            return opt.Match(
                None: () => throw new(),
                Some: x => x);
        }
    }
}