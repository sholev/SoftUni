namespace RegularExpressions
{
    using System;
    using System.Text.RegularExpressions;

    class ReplaceATag
    {
        static void Main(string[] args)
        {
            var input = String.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                var matchPattern = @"<a\s*href=(?<url>.+?(?=>))>(?<text>.+?)<\/a>";
                var replacement = @"[URL href=${url}]${text}[/URL]";

                var result = Regex.Replace(input, matchPattern, replacement);

                Console.WriteLine(result);
            }
        }
    }
}
