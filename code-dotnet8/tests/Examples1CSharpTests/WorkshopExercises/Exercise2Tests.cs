using CSharpFunctionalExtensions;
using Examples1CSharp.WorkshopExercises;
using FluentAssertions.Execution;

namespace Examples1CSharpTests.WorkshopExercises;

public class Exercise2Tests
{
    [Fact]
    public void Empfänger_erstellen_v1_funktioniert_Happy_Path()
    {
        // Act
        var resultHomer = Empfänger.CreateV1(
            "Homer",
            "Simpson",
            "Herr",
            "Evergreen Terrace 742"
        );

        // Assert
        resultHomer.IsSuccess.Should().BeTrue();
        using (new AssertionScope())
        {
            var homer = resultHomer.Value!;
            homer.Vorname.Value.Should().Be("Homer");
            homer.Nachname.Value.Should().Be("Simpson");
            homer.AnredeMaybe.Value.Value.Should().Be("Herr");
            homer.Postanschrift.Value.Should().Be("Evergreen Terrace 742");
        }
    }
    
    [Fact]
    public void Empfänger_erstellen_v1_fehlende_Anrede_funktioniert_Happy_Path()
    {
        // Act
        var resultHomer = Empfänger.CreateV1(
            "Homer",
            "Simpson",
            "", // !! Keine Anrede
            "Evergreen Terrace 742"
        );

        // Assert
        resultHomer.IsSuccess.Should().BeTrue();
        resultHomer.Value.AnredeMaybe.Should().Be(Maybe<Anrede>.None);
    }
    
    [Theory]
    [MemberData(nameof(InvalidSampleData))]
    public void Empfänger_erstellen_v1_mit_ungültigen_Eingaben_gibt_richtige_Fehlermeldung(
        string vorname,
        string nachname,
        string anrede,
        string postanschrift,
        string fehlerMeldung)
    {
        // Act
        var resultHomer = Empfänger.CreateV1(
            vorname,
            nachname,
            anrede,
            postanschrift
        );

        // Assert
        resultHomer.IsFailure.Should().BeTrue();
        resultHomer.Error.Should().Be(fehlerMeldung);
    }
    
    [Fact]
    public void Empfänger_erstellen_v2_funktioniert_Happy_Path()
    {
        // Act
        var resultHomer = Empfänger.CreateV2(
            "Homer",
            "Simpson",
            "Herr",
            "Evergreen Terrace 742"
        );

        // Assert
        resultHomer.IsSuccess.Should().BeTrue();
        using (new AssertionScope())
        {
            var homer = resultHomer.Value!;
            homer.Vorname.Value.Should().Be("Homer");
            homer.Nachname.Value.Should().Be("Simpson");
            homer.AnredeMaybe.Value.Value.Should().Be("Herr");
            homer.Postanschrift.Value.Should().Be("Evergreen Terrace 742");
        }
    }
    
    [Theory]
    [MemberData(nameof(InvalidSampleData))]
    public void Empfänger_v2_erstellen_mit_ungültigen_Eingaben_gibt_richtige_Fehlermeldung(
        string vorname,
        string nachname,
        string anrede,
        string postanschrift,
        string fehlerMeldung)
    {
        // Act
        var resultHomer = Empfänger.CreateV2(
            vorname,
            nachname,
            anrede,
            postanschrift
        );

        // Assert
        resultHomer.IsFailure.Should().BeTrue();
        resultHomer.Error.Should().Be(fehlerMeldung);
    }

    public static IEnumerable<object[]> InvalidSampleData
    {
        get
        {
            const string empty = "";
            return new List<object[]>
            {
                new object[] { empty, "Simpson", "Herr", "Evergreen Terrace 742", "Ungültiger Vorname: ''" },
                new object[] { "Homer", empty, "Herr", "Evergreen Terrace 742", "Ungültiger Nachname: ''" },
                new object[] { "Homer", "Simpson", "Herr", empty, "Ungültige Postanschrift: ''" },
            };
        }
    }

    [Theory]
    [InlineData(0, false)]
    [InlineData(1, true)]
    [InlineData(160, true)]
    [InlineData(161, false)]
    public void Grußkartentext_erstellen_funktioniert(int stringLength, bool isValid) => 
        Grußkartentext
            .Create(new String('x', stringLength))
            .IsSuccess
            .Should().Be(isValid);

    [Fact]
    public void Grußkarte_erstellen_funktioniert_Happy_Path()
    {
        // Arrange
        var resultHomer = Empfänger.CreateV1(
            "Homer",
            "Simpson",
            "Herr",
            "Evergreen Terrace 742"
        );
        var resultGrußkartentext = Grußkartentext.Create("Hallo Homer!");

        var grußkartentext = resultGrußkartentext.Value;
        var empfänger = resultHomer.Value;

        // Act
        var grußkarte = new Grußkarte(grußkartentext, empfänger);
        
        // Assert
        using (new AssertionScope())
        {
            grußkarte.Grußkartentext.Value.Should().Be("Hallo Homer!");
            var homer = grußkarte.Empfänger;
            homer.Vorname.Value.Should().Be("Homer");
            homer.Nachname.Value.Should().Be("Simpson");
            homer.AnredeMaybe.Value.Value.Should().Be("Herr");
            homer.Postanschrift.Value.Should().Be("Evergreen Terrace 742");
        }
    }
}
