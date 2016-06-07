namespace RegularExpressions
{
    using System;
    using System.Text.RegularExpressions;

    class MatchPhoneNumber
    {
        static void Main(string[] args)
        {
            var pattern  = @"^\+359( |-)\d{1,2}\1\d{3}\1\d{4}$";

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                var spaceMatch = Regex.Match(input, pattern, RegexOptions.Multiline);

                if (spaceMatch.Success)
                {
                    Console.WriteLine(spaceMatch.Value);
                }
            }
        }
    }
}
