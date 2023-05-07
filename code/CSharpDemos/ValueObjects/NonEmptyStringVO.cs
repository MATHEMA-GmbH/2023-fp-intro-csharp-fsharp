using LaYumba.Functional;
using System;
using System.Collections.Generic;

namespace CSharpDemos.ValueObjects
{
    public class NonEmptyStringVO : ValueObject
    {
        // smart ctor
        public static Func<string, Option<NonEmptyStringVO>> Create
            = s => s.IsNonEmpty()
                ? F.Some(new NonEmptyStringVO(s))
                : F.None;

        private NonEmptyStringVO(string potentialString)
        {
            Value = potentialString;
        }

        public string Value { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static implicit operator string(NonEmptyStringVO nonEmptyString)
        {
            return nonEmptyString.Value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}