using System;

class StringsAndObjects
{
    static void Main()
    {
        string first = "Hello";
        string second = "World";

        object together = first + ' ' + second;

        string union = together.ToString();

        Console.WriteLine(union);
    }
}
