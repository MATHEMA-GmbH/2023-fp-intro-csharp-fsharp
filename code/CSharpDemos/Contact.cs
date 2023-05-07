using CSharpDemos.ValueObjects;
using LaYumba.Functional;
using System;
using static LaYumba.Functional.F;

namespace CSharpDemos
{
    public class Contact
    {
        private Contact(IdVO id, NonEmptyStringVO firstName, NonEmptyStringVO lastName,
            Option<DateOfBirthVO> dateOfBirth, Option<NonEmptyStringVO> twitterHandle)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            TwitterHandle = twitterHandle;
        }

        private static readonly Func<IdVO, NonEmptyStringVO, NonEmptyStringVO, Option<DateOfBirthVO>, Option<NonEmptyStringVO>, Contact>
            Create
            = (id, firstName, lastName, optDob, optTwitter)
                => new Contact(id, firstName, lastName, optDob, optTwitter);

        // Not sure if this function should be moved somewhere else
        public static Validation<Contact> CreateValidContact(Option<IdVO> optId, Option<NonEmptyStringVO> optFirstName,
            Option<NonEmptyStringVO> optLastName, Option<DateOfBirthVO> optDob,
            Option<NonEmptyStringVO> optTwitterHandle)
        {
            Validation<IdVO> ValidateId(Option<IdVO> opt)
                => opt.Match(
                    () => Error("invalid Id"),
                    x => Valid(x));

            //            Func<Option<Id>, Validation<Id>> ValidateId2 
            //                = opt => opt.Match(
            //                    () => Error("invalid Id"), 
            //                    x => Valid(x));

            Validation<NonEmptyStringVO> ValidateFirstName(Option<NonEmptyStringVO> opt)
                => opt.Match(
                    () => Error("invalid FirstName"),
                    s => Valid(s));

            Validation<NonEmptyStringVO> ValidateLastName(Option<NonEmptyStringVO> opt)
                => opt.Match(
                    () => Error("invalid LastName"),
                    s => Valid(s));

            return Valid(Create)
                .Apply(ValidateId(optId))
                .Apply(ValidateFirstName(optFirstName))
                .Apply(ValidateLastName(optLastName))
                .Apply(optDob)
                .Apply(optTwitterHandle);
        }

        public IdVO Id { get; }
        public NonEmptyStringVO FirstName { get; }
        public NonEmptyStringVO LastName { get; }
        public Option<DateOfBirthVO> DateOfBirth { get; }
        public Option<NonEmptyStringVO> TwitterHandle { get; }

        public override string ToString() => $"Id: {Id}: {FirstName} {LastName} (DOB: {DateOfBirth}, Twitter: {TwitterHandle})";
    }
}