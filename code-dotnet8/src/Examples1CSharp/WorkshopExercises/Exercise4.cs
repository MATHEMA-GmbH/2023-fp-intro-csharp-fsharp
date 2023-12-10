using CSharpFunctionalExtensions;

namespace Examples1CSharp.WorkshopExercises;

public static class Exercise4
{
    public static Result<Grußkarte> Workflow(
        this Grußkarte grußkarte,
        Func<Grußkarte, Result<Grußkarte>> drucken,
        Func<Grußkarte, Result<Grußkarte>> verpacken,
        Func<Grußkarte, Result<Grußkarte>> versenden)
    {
        var result = drucken(grußkarte)
                .Bind(verpacken)
                .Bind(versenden)
                .Match(
                    onSuccess: Result.Success,
                    onFailure: Result.Failure<Grußkarte>);
            
        return result;
    }
}

