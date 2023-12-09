namespace Examples1CSharp.WorkshopExercises;

public static class Exercise3
{
    public static Empfänger MachDieAnredeGroß(Empfänger empfänger) => 
        empfänger with { OptionaleAnrede = empfänger.AnredeToUpper() };
}
