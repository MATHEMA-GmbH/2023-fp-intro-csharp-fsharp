using CSharpFunctionalExtensions;

namespace Workshop;

/*
 * 
- Es gibt Empfänger
- Diese haben einen Vornamen (Pflichtfeld, darf nicht leer und auch nicht nur 
Whitespace sein) und einen Nachnamen (Pflichtfeld, darf nicht leer und auch nicht nur 
Whitespace sein)
- Diese haben eine Anrede (Optional, leer oder nur
 Whitespace zählt als nicht vorhanden)
- Diese haben eine Postanschrift (Pflichtfeld, nur Text, darf nicht
 leer und auch nicht nur Whitespace sein)
- Es gibt Grußkarten
- Diese haben einen Grußkartentext (Pflichtfeld, darf nicht
 leer und auch nicht nur Whitespace sein, darf nicht länger als 160 Zeichen sein)
- Diese haben einen Empfänger
 */
public class Übung2
{
        
}

public record Vorname
{
    public string Value { get; }

    public Vorname(string value)
    {
        if (!IstGültig(value))
        {
            throw new ArgumentException("Vorname ungültig");
        }

        Value = value;

    }

    private static bool IstGültig(string value)
    {
        return !string.IsNullOrWhiteSpace(value);
    }
}

public record Nachname
{
    public string Value { get; }

    public Nachname(string value)
    {
        if (!IstGültig(value))
        {
            throw new ArgumentException("Vorname ungültig");
        }

        Value = value;

    }

    private static bool IstGültig(string value)
    {
        return !string.IsNullOrWhiteSpace(value);
    }
}

public record Anrede
{
    public string Value { get; }

    public static Maybe<Anrede> Create(string value)
    {
        if (!IstGültig(value))
        {
            return Maybe<Anrede>.None;
        }

        return Maybe.From(new Anrede(value));
    }
    
    private Anrede(string value)
    {
        Value = value;
    }

    private static bool IstGültig(string value)
    {
        return !string.IsNullOrWhiteSpace(value);
    }
}

