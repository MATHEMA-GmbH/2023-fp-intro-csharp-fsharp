using System;
using CSharpDemos.ValueObjects;
using static LaYumba.Functional.F;

namespace CSharpDemos.Tests.TestHelper
{
    public static class ContactHelper
    {
        public static Contact CreateSampleContact(int id, string firstName, string lastName, DateTime? dob = null, string twitter = null)
        {
            var optId = IdVO.Create(id);
            var optFirstName = NonEmptyStringVO.Create(firstName);
            var optLastName = NonEmptyStringVO.Create(lastName);
            var optDob = dob != null ? Some(new DateOfBirthVO(dob.Value)) : None;
            var optTwitterHandle = twitter != null ? NonEmptyStringVO.Create(twitter) : None;

            var validContact = Contact.CreateValidContact(optId, optFirstName, optLastName, optDob, optTwitterHandle);
            return validContact.Match(_ => null, x => x);
        }
    }
}