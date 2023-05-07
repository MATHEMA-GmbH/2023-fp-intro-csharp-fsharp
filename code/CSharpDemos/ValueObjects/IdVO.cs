using LaYumba.Functional;
using System;
using System.Collections.Generic;

namespace CSharpDemos.ValueObjects
{
    public class IdVO : ValueObject
    {
        // smart ctor
        public static readonly Func<int, Option<IdVO>> Create
            = i => i.IsValidId()
                ? F.Some(new IdVO(i))
                : F.None;

        private IdVO(int value)
        {
            Value = value;
        }

        public int Value { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static implicit operator int(IdVO id)
        {
            return id.Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}