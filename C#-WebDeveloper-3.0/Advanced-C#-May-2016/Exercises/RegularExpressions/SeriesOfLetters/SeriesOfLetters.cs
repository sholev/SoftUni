namespace RegularExpressions
{
    using System;
    using System.Text.RegularExpressions;

    class SeriesOfLetters
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            // Get (.) and \1* will include the rest of the same
            string matchPattern = @"(.)\1*";
            string replacement = @"$1";
            string output = Regex.Replace(input, matchPattern, replacement);
            Console.WriteLine(output);
        }
    }
}
