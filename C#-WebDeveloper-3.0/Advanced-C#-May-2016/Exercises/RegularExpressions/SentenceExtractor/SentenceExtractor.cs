namespace RegularExpressions
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class SentenceExtractor
    {
        static void Main(string[] args)
        {
            string keyword = Console.ReadLine();
            string input = Console.ReadLine();

            string sentencePattern = $@"(?<=\s|^)(?:\s)*([^?!.]*\b{keyword}\b[^!?.]*[!.?])";
            string[] matches = Regex.Matches(input, sentencePattern).Cast<Match>().Select(m => m.Value).ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, matches));
        }
    }
}
