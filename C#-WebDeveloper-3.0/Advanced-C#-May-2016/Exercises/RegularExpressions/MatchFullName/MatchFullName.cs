namespace RegularExpressions
{
    using System;
    using System.Text.RegularExpressions;

    class MatchFullName
    {
        static void Main(string[] args)
        {
            var pattern = @"\b[A-Z][a-z]{1,} [A-Z][a-z]{1,}\b";
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                var match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    Console.WriteLine(match.Value);
                }
            }
       } 
    }
}
