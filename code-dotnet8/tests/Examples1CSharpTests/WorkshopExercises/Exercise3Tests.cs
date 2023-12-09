using CSharpFunctionalExtensions;
using Examples1CSharp.WorkshopExercises;
using FluentAssertions.Execution;

namespace Examples1CSharpTests.WorkshopExercises;

public class Exercise3Tests
{
    [Fact]
    public void Empfänger_Anrede_in_Großbuchstaben_umwandeln()
    {
        // Arrange
        var homer = Empfänger.CreateV1(
            "Homer",
            "Simpson",
            "Herr",
            "Evergreen Terrace 742"
        ).Value!;

        // Act
        var homerInGroß = Exercise3.MachDieAnredeGroß(homer);

        // Assert
        homerInGroß.OptionaleAnrede.Value.Value.Should().Be("HERR");
    }
    
    // Create a bunch of Grußkarten with different recipients and differing optional salutations
    // and then use Exercise3.MachDieAnredeGroß to convert all optional salutations to uppercase.
    // Then check that all optional salutations are uppercase.
    [Fact]
    public void Alle_Optionalen_Anreden_in_Großbuchstaben_umwandeln()
    {
        // Arrange
        var homer = Empfänger.CreateV1(
            "Homer",
            "Simpson",
            "Herr",
            "Evergreen Terrace 742"
        ).Value!;
        var marge = Empfänger.CreateV1(
            "Marge",
            "Simpson",
            "Frau",
            "Evergreen Terrace 742"
        ).Value!;
        var bart = Empfänger.CreateV1(
            "Bart",
            "Simpson",
            "", // !! Keine Anrede
            "Evergreen Terrace 742"
        ).Value!;
        var lisa = Empfänger.CreateV1(
            "Lisa",
            "Simpson",
            "Frau",
            "Evergreen Terrace 742"
        ).Value!;
        var maggie = Empfänger.CreateV1(
            "Maggie",
            "Simpson",
            "Frau",
            "Evergreen Terrace 742"
        ).Value!;
        var ned = Empfänger.CreateV1(
            "Ned",
            "Flanders",
            "Herr",
            "Evergreen Terrace 744"
        ).Value!;
        var maude = Empfänger.CreateV1(
            "Maude",
            "Flanders",
            "Frau",
            "Evergreen Terrace 744"
        ).Value!;
        var barney = Empfänger.CreateV1(
            "Barney",
            "Gumble",
            "Herr",
            "Evergreen Terrace 742"
        ).Value!;
        var moe = Empfänger.CreateV1(
            "Moe",
            "Szyslak",
            "Herr",
            "Evergreen Terrace 742"
        ).Value!;
        var lenny = Empfänger.CreateV1(
            "Lenny",
            "Leonard",
            "Herr",
            "Evergreen Terrace 742"
        ).Value!;
        var carl = Empfänger.CreateV1(
            "Carl",
            "Carlson",
            "Herr",
            "Evergreen Terrace 742"
        ).Value!;
        
        var text = Grußkartentext.Create("test").Value!;
        
        var grußkarten = new List<Grußkarte>
        {
            new(text, homer),
            new(text, marge),
            new(text, bart),
            new(text, lisa),
            new(text, maggie),
            new(text, ned),
            new(text, maude),
            new(text, barney),
            new(text, moe),
            new(text, lenny),
            new(text, carl),
        };
                
        // Act
        var actual =
            grußkarten
                .Select(g => 
                    g with { Empfänger = Exercise3.MachDieAnredeGroß(g.Empfänger) })
                .ToList();

        // Assert
        using (new AssertionScope())
        {
            actual[0].Empfänger.OptionaleAnrede.Value.Value.Should().Be("HERR");
            actual[1].Empfänger.OptionaleAnrede.Value.Value.Should().Be("FRAU");
            actual[2].Empfänger.OptionaleAnrede.HasNoValue.Should().BeTrue();
            actual[3].Empfänger.OptionaleAnrede.Value.Value.Should().Be("FRAU");
            actual[4].Empfänger.OptionaleAnrede.Value.Value.Should().Be("FRAU");
            actual[5].Empfänger.OptionaleAnrede.Value.Value.Should().Be("HERR");
            actual[6].Empfänger.OptionaleAnrede.Value.Value.Should().Be("FRAU");
            actual[7].Empfänger.OptionaleAnrede.Value.Value.Should().Be("HERR");
            actual[8].Empfänger.OptionaleAnrede.Value.Value.Should().Be("HERR");
            actual[9].Empfänger.OptionaleAnrede.Value.Value.Should().Be("HERR");
            actual[10].Empfänger.OptionaleAnrede.Value.Value.Should().Be("HERR");
        }
    }
}
