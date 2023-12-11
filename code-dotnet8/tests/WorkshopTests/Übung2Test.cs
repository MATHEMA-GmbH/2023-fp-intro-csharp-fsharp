using CSharpFunctionalExtensions;
using OneOf.Types;
using Workshop;
using Maybe = CSharpFunctionalExtensions.Maybe;

namespace WokshopTests;

public class Übung2Test
{
    [Fact]
    public void TestAnredeIstGültig()
    {
        var gültigerStr = "B";
        var maybe = Anrede.Create(gültigerStr);
        maybe.Match(
            Some: x => x.Value.Should().Be("B"),
            None: () => true.Should().Be(false));
    }
    [Fact]
    public void TestAnredeIstUngültig()
    {
        var ungültigerStr = "";
        var maybe = Anrede.Create(ungültigerStr);
        
        maybe.Match(
            Some: x => true.Should().Be(false),
            None: () => true.Should().Be(true));
    }
}
