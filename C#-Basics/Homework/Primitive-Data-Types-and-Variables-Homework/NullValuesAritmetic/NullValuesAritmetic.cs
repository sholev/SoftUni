using System;

class NullValuesAritmetic
{
    static void Main()
    {
        int? var = null;
        double? kirech = null;

        Console.WriteLine(var);
        Console.WriteLine(kirech);

        var = 3;
        kirech = 4.5;

        Console.WriteLine(var);
        Console.WriteLine(kirech);
    }
}
