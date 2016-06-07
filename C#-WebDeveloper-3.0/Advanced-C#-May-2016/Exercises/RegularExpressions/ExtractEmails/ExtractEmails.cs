namespace RegularExpressions
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class ExtractEmails
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string matchPattern = @"(?<=\s|^)[^\W_][\w.-]*[^\W_]@[^\W]+[\w.-]+\.[^\W]+";

            string[] matches = Regex.Matches(input, matchPattern).Cast<Match>().Select(m => m.Value).ToArray();
            Console.WriteLine(string.Join(Environment.NewLine, matches));
        }
    }
}
