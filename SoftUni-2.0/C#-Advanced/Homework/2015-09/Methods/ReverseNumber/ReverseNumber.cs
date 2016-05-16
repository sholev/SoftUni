using System;
using System.Linq;

class ReverseNumber
{
    static void Main()
    {
        Console.WriteLine(GetReversedNumber(256));
        Console.WriteLine(GetReversedNumber(123.45));
        Console.WriteLine(GetReversedNumber(0.12));
    }

    private static double GetReversedNumber(double number)
    {
        return double.Parse(new string(number.ToString().Reverse().ToArray()));
    }
}
