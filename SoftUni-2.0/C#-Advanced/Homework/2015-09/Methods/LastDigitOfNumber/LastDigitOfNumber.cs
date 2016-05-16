using System;

class LastDigitOfNumber
{
    static void Main()
    {
        Console.WriteLine(GetLastDifitAsWord(110));
        Console.WriteLine(GetLastDifitAsWord(111));
        Console.WriteLine(GetLastDifitAsWord(512));
        Console.WriteLine(GetLastDifitAsWord(345623));
        Console.WriteLine(GetLastDifitAsWord(1024));
        Console.WriteLine(GetLastDifitAsWord(5));
        Console.WriteLine(GetLastDifitAsWord(9876));
        Console.WriteLine(GetLastDifitAsWord(707));
        Console.WriteLine(GetLastDifitAsWord(12345678));
        Console.WriteLine(GetLastDifitAsWord(12309));
    }

    private static string GetLastDifitAsWord(int number)
    {
        string[] digitWords = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        return digitWords[number % 10];
    }
}
