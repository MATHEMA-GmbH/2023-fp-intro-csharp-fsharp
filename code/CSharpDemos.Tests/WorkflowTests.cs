using FluentAssertions;
using LaYumba.Functional;
using System;
using System.Collections.Immutable;
using Xunit;
using static CSharpDemos.Tests.TestHelper.ContactHelper;
using static LaYumba.Functional.F;

namespace CSharpDemos.Tests
{
    public class WorkflowTests
    {
        [Fact]
        public void AddWorkflow()
        {
            // Arrange
            var emptyAddressBook = new AddressBook(ImmutableList<Contact>.Empty);
            var homer = CreateSampleContact(1, "Homer", "Simpson");

            Func<Contact, Either<string, Contact>> sendMailFunction = c => Right(homer);

            // Act
            var result = emptyAddressBook.AddWorkflow(sendMailFunction, homer);

            // Assert
            result.ToString().Should().Be("Right(AddressBook. Number of entries: 1)");
        }

        [Fact]
        public void AddWorkflow_with_failing_email_send()
        {
            // Arrange
            var emptyAddressBook = new AddressBook(ImmutableList<Contact>.Empty);
            var homer = CreateSampleContact(1, "Homer", "Simpson");

            Func<Contact, Either<string, Contact>> sendMailFunction = c => Left("ups");

            // Act
            var result = emptyAddressBook.AddWorkflow(sendMailFunction, homer);

            // Assert
            result.ToString().Should().Be("Left(ups)");
        }
    }
}