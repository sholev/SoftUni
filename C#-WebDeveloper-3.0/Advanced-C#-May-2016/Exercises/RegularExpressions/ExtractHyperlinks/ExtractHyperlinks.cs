namespace RegularExpressions
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    class ExtractHyperlinks
    {
        static void Main(string[] args)
        {
            var inputText = new StringBuilder();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                inputText.AppendLine(input);
            }

            var pattern = @"(?<=<a\s+(?:[^>]+\s+)?href\s*=\s*)(?:""(?<link>[^""]*)""|'(?<link>[^']*)'|(?<link>[^\s>]+))(?=[^>]*>)";

            var matches = Regex.Matches(inputText.ToString(), pattern).Cast<Match>().Select(m => m.Groups["link"].Value);

            Console.WriteLine(string.Join(Environment.NewLine, matches));
        }
    }
}
