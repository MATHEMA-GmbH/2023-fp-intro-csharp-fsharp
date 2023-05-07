using FluentAssertions;
using LaYumba.Functional;
using System;
using System.Collections.Generic;
using Xunit;
using static LaYumba.Functional.F;
using Enum = LaYumba.Functional.Enum;

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

        private ISet<string> ValidCountryCodes = new HashSet<string> { "ch", "uk", "de" };

        Func<string, Validation<CountryCode>> validCountryCode
            => s => CountryCode.Create(ValidCountryCodes, s).Match(
                None: () => Error($"{s} is not a valid country code"),
                Some: c => Valid(c));

        // string -> Validation<PhoneNumber.NumberType>
        Func<string, Validation<PhoneNumber.NumberType>> validNumberType
            = s => Enum.Parse<PhoneNumber.NumberType>(s).Match(
                None: () => Error($"{s} is not a valid number type"),
                Some: n => Valid(n));

        // string -> Validation<PhoneNumber.Number>
        Func<string, Validation<Number>> validNumber
            = s => Number.Create(s).Match(
                None: () => Error($"{s} is not a valid number"),
                Some: n => Valid(n));


        Validation<PhoneNumber> CreatePhoneNumber
            (string type, string countryCode, string number)
            => Valid(PhoneNumber.Create)
                .Apply(validNumberType(type))
                .Apply(validCountryCode(countryCode))
                .Apply(validNumber(number));
        // TODO
    }
}