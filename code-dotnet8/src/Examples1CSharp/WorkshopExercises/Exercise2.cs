using System.Globalization;
using CSharpFunctionalExtensions;

namespace Examples1CSharp.WorkshopExercises;

public class Exercise2
{
}

public record Vorname
{
    private Vorname(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<Vorname> Create(string value) =>
        IsValid(value) 
            ? new Vorname(value) 
            : Result.Failure<Vorname>($"Ungültiger Vorname: '{value}'");

    private static bool IsValid(string value) => !string.IsNullOrWhiteSpace(value);
}

public record Nachname
{
    private Nachname(string value)
    {
        Value = value;
    }

    public string Value { get; }

    
    public static Result<Nachname> Create(string value) =>
        IsValid(value) 
            ? new Nachname(value) 
            : Result.Failure<Nachname>($"Ungültiger Nachname: '{value}'");

    private static bool IsValid(string value) => !string.IsNullOrWhiteSpace(value);
}

public record Anrede
{
    private Anrede(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Maybe<Anrede> Create(string value) =>
        IsValid(value) 
            ? new Anrede(value) 
            : Maybe.None;

    private static bool IsValid(string value) => !string.IsNullOrWhiteSpace(value);
}

public record Postanschrift
{
    private Postanschrift(string value)
    {
        Value = value;
    }

    public string Value { get; }
    
    public static Result<Postanschrift> Create(string value) =>
        IsValid(value) 
            ? new Postanschrift(value) 
            : Result.Failure<Postanschrift>($"Ungültige Postanschrift: '{value}'");

    private static bool IsValid(string value) => !string.IsNullOrWhiteSpace(value);
}

public record Empfänger(Vorname Vorname, Nachname Nachname, Maybe<Anrede> OptionaleAnrede, Postanschrift Postanschrift)
{
    public static Result<Empfänger> CreateV1(string vorname, string nachname, string anrede, string postanschrift)
    {
        // NOTE: At this point we don't know anything about `Bind` or `Map` yet!
        //
        var resultVorname = Vorname.Create(vorname);
        var resultNachname = Nachname.Create(nachname);
        var resultPostanschrift = Postanschrift.Create(postanschrift);

        // Pyramide of doom
        if (resultVorname.IsSuccess)
        {
            if (resultNachname.IsSuccess)
            {
                if (resultPostanschrift.IsSuccess)
                {
                    return Result.Success(
                        new Empfänger(
                            resultVorname.Value, 
                            resultNachname.Value, 
                            Anrede.Create(anrede), 
                            resultPostanschrift.Value));
                }
                return Result.Failure<Empfänger>(resultPostanschrift.Error);
            }
            return Result.Failure<Empfänger>(resultNachname.Error);
        }
        return Result.Failure<Empfänger>(resultVorname.Error);
    }
    
    public static Result<Empfänger> CreateV2(string vorname, string nachname, string anrede, string postanschrift)
    {
        // NOTE: At this point we don't know anything about `Bind` or `Map` yet!
        //
        // Pyramide of doom, with pattern matching is a little bit shorter
        return Vorname.Create(vorname)
            .Match(
                onSuccess: vn => Nachname.Create(nachname)
                    .Match(
                        onSuccess: nn => Postanschrift.Create(postanschrift)
                            .Match(
                                onSuccess: pa => Result.Success(
                                    new Empfänger(
                                        vn,
                                        nn,
                                        Anrede.Create(anrede),
                                        pa)),
                                onFailure: Result.Failure<Empfänger>),
                        onFailure: Result.Failure<Empfänger>),
                onFailure: Result.Failure<Empfänger>);
    }

    // Placing this here is just my OO background. I would have placed the logic in the Anrede record.
    public Maybe<Anrede> AnredeToUpper() =>
        OptionaleAnrede
            .Match(
                Some: anrede => Anrede.Create(anrede.Value.ToUpper(CultureInfo.InvariantCulture)),
                None: () => Maybe<Anrede>.None);
}


public record Grußkartentext 
{
    private Grußkartentext(string value)
    {
        Value = value;
    }

    public string Value { get; }

    
    public static Result<Grußkartentext> Create(string value) =>
        IsValid(value) 
            ? new Grußkartentext(value) 
            : Result.Failure<Grußkartentext>($"Ungültiger Grußkartentext: '{value}'");

    private static bool IsValid(string value) => 
        !string.IsNullOrWhiteSpace(value) && 
        value.Length <= 160;
}

public record Grußkarte(Grußkartentext Grußkartentext, Empfänger Empfänger);
