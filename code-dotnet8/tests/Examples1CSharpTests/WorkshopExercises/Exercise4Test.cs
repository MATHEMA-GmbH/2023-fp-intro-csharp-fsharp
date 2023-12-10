using CSharpFunctionalExtensions;
using Examples1CSharp.WorkshopExercises;
using FluentAssertions.Execution;

namespace Examples1CSharpTests.WorkshopExercises;

public class Exercise4Test
{
    [Fact]
    public void Workflow_Happy_Case()
    {
        // Arrange
        var grußkarte = GrußkarteFürHomer();

        // Act
        var actualResult = grußkarte.Workflow(
            drucken: Drucken,
            verpacken: Verpacken,
            versenden: Versenden);

        // Assert
        actualResult.IsSuccess.Should().BeTrue();
        var actual = actualResult.Value;
        using (new AssertionScope())
        {
            actual.Should().BeEquivalentTo(
                grußkarte, 
                options => options.Excluding(x => x.Empfänger.OptionaleAnrede));
            
            actual.Empfänger.OptionaleAnrede.Value.Value.Should().Be("MR");
        }
    }

    [Fact]
    public void Workflow_mit_DruckFehler()
    {
        // Arrange
        var grußkarte = GrußkarteFürHomer();

        // Act
        var actualResult = grußkarte.Workflow(
            drucken: DruckenFehler,
            verpacken: Verpacken,
            versenden: Versenden);
        
        // Assert
        actualResult.IsSuccess.Should().BeFalse();
        actualResult.Error.Should().Be("Drucken fehlgeschlagen");
    }

    [Fact]
    public void Workflow_mit_PackFehler()
    {
        // Arrange
        var grußkarte = GrußkarteFürHomer();

        // Act
        var actualResult = grußkarte.Workflow(
            drucken: Drucken,
            verpacken: VerpackenFehler,
            versenden: Versenden);
        
        // Assert
        actualResult.IsSuccess.Should().BeFalse();
        actualResult.Error.Should().Be("Verpacken fehlgeschlagen");
    }

    [Fact]
    public void Workflow_mit_VersandFehler()
    {
        // Arrange
        var grußkarte = GrußkarteFürHomer();

        // Act
        var actualResult = grußkarte.Workflow(
            drucken: Drucken,
            verpacken: Verpacken,
            versenden: VersendenFehler);
        
        // Assert
        actualResult.IsSuccess.Should().BeFalse();
        actualResult.Error.Should().Be("Versenden fehlgeschlagen");
    }
    
    private static Result<Grußkarte> Drucken(Grußkarte grußkarte) =>
        Result.Success(grußkarte with
        {
            Empfänger = grußkarte.Empfänger with
            {
                OptionaleAnrede = Maybe.From(grußkarte.Empfänger.OptionaleAnrede.Value.Schreiend())
            }
        });
    
    private static Result<Grußkarte> Verpacken(Grußkarte grußkarte) =>
        Result.Success(grußkarte);
    
    private static Result<Grußkarte> Versenden(Grußkarte grußkarte) =>
        Result.Success(grußkarte);

    private static Result<Grußkarte> DruckenFehler(Grußkarte grußkarte) =>
        Result.Failure<Grußkarte>("Drucken fehlgeschlagen");

    private static Result<Grußkarte> VerpackenFehler(Grußkarte grußkarte) =>
        Result.Failure<Grußkarte>("Verpacken fehlgeschlagen");
    
    private static Result<Grußkarte> VersendenFehler(Grußkarte grußkarte) =>
        Result.Failure<Grußkarte>("Versenden fehlgeschlagen");

    private static Grußkarte GrußkarteFürHomer() =>
        CreateGrußkarte(
            "Alles Gute zum Geburtstag!", 
            "Homer", 
            "Simpson", 
            "Mr", 
            "742 Evergreen Terrace");

    private static Grußkarte CreateGrußkarte(string grußkartentext, string vorname, string nachname, string anrede,
        string adresse) =>
        new(
            Grußkartentext.Create(grußkartentext).Value,
            Empfänger.CreateV2(
                vorname,
                nachname,
                anrede,
                adresse
            ).Value
        );
}
