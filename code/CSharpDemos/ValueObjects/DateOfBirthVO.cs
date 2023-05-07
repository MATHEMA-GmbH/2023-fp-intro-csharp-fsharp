using System;
using System.Collections.Generic;

namespace CSharpDemos.ValueObjects
{
    public class DateOfBirthVO : ValueObject
    {
        public DateOfBirthVO(DateTime value)
        {
            Value = value.Date;
        }

        public DateTime Value { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static implicit operator DateTime(DateOfBirthVO dob)
        {
            return dob.Value;
        }

        public override string ToString()
        {
            return Value.ToString("yyyy-MM-dd");
        }
    }
}