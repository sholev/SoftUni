namespace RegularExpressions
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    class UseYourChaninsBuddy
    {
        static void Main(string[] args)
        {
            // Increase the Console.ReadLine(); character limit.
            // http://stackoverflow.com/questions/6081946/why-does-console-readline-have-a-limit-on-the-length-of-text-it-allows/6081967#6081967
            Console.SetIn(new StreamReader(Console.OpenStandardInput(16384)));

            var input = Console.ReadLine();
            var matchPattern = @"(?:<p>)(?<message>.*?)(?:<\/p>)";
            
            var matches = Regex.Matches(input, matchPattern).Cast<Match>().Select(m => m.Groups["message"].Value);
            var output = matches.Select(DecryptMessage).ToList();

            Console.WriteLine(string.Join("", output));
        }

        private static string DecryptMessage(string message)
        {
            StringBuilder result = new StringBuilder();

            foreach (var symbol in message)
            {
                result.Append(ConvertChar(symbol));
            }

            return Regex.Replace(result.ToString(), @"\s+", " ");
        }

        private static char ConvertChar(char symbol)
        {
            char result;

            if (symbol >= 'a' && symbol <= 'm')
            {
                result = (char)(symbol + 13);
            }
            else if (symbol >= 'n' && symbol <= 'z')
            {
                result = (char)(symbol - 13);
            }
            else if (symbol >= '0' && symbol <= '9')
            {
                result = symbol;
            }
            else
            {
                result = ' ';
            }

            return result;
        }
    }
}
