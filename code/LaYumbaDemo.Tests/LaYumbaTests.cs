using FluentAssertions;
using Xunit;

namespace LaYumbaDemo.Tests
{
    // From "Functional Programming with C#"
    public class LaYumbaTests
    {
        [Fact]
        public void SmokeTest()
        {
            true.Should().BeTrue();
        }
        // ========================================================================================
        // Chapter 5: Function composition, method chaining, functional domain modeling
        // TODO

        // ========================================================================================
        // Chapter 8:
        // 8.5.3 Failing fast with monadic flow
        // FP-JARGON: APPLICATIVE
        // Listing 8.18 Validation using applicative flow
        // Validation<PhoneNumber> CreatePhoneNumber
        //     (string type, string countryCode, string number)
        //     => Valid(PhoneNumber.Create)
        //         .Apply(validNumberType(type))
        //         .Apply(validCountryCode(countryCode))
        //         .Apply(validNumber(number));
        // TODO
    }
}