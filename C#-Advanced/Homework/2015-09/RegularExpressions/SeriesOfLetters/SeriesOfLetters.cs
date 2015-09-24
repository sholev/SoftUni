using System;
using System.Text.RegularExpressions;

class SeriesOfLetters
{
    static void Main()
    {
        string input = Console.ReadLine();
        // Get character (.) and \1* 
        string matchPattern = @"(.)\1*";
        string replacement = @"$1";
        Console.WriteLine(Regex.Replace(input, matchPattern, replacement));
    }
}