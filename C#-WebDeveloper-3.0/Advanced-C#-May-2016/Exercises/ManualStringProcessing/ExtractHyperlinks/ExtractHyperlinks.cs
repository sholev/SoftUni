namespace ManualStringProcessing
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    class ExtractHyperlinks
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder inputText = new StringBuilder();

            while (input != "END")
            {
                inputText.AppendFormat("{0}\r\n", input);
                input = Console.ReadLine();
            }

            string pattern = @"(?<=<a\s+(?:[^>]+\s+)?href\s*=\s*)(?:""(?<lel>[^""]*)""|'(?<lel>[^']*)'|(?<lel>[^\s>]+))(?=[^>]*>)";

            string[] matches =
                Regex.Matches(inputText.ToString(), pattern)
                    .Cast<Match>()
                    .Select(m => m.Groups["lel"].Value)
                    .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, matches));
        }
    }
}
