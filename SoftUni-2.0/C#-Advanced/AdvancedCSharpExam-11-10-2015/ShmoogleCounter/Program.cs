using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ShmoogleCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = string.Empty;
            StringBuilder input = new StringBuilder();

            while ((line = Console.ReadLine()) != @"//END_OF_CODE")
            {
                input.AppendLine(line);
            }

            string patternDouble = @"\bdouble\s*(\b[a-zA-Z0-9]+\b).";
            string patternInt = @"\bint\s*(\b[a-zA-Z0-9]+\b).";
            List<string> doubleMatches = Regex.Matches(input.ToString(), patternDouble).
                Cast<Match>().Select(match => match.Groups[1].Value).ToList();
            List<string> intMatches = Regex.Matches(input.ToString(), patternInt).
                Cast<Match>().Select(match => match.Groups[1].Value).ToList();

            doubleMatches.Sort();
            intMatches.Sort();

            if (doubleMatches.Count > 0)
            {
                Console.WriteLine($"Doubles: {string.Join(", ", doubleMatches)}");
            }
            else
            {
                Console.WriteLine($"Doubles: None");
            }

            if (intMatches.Count > 0)
            {
                Console.WriteLine($"Ints: {string.Join(", ", intMatches)}");
            }
            else
            {
                Console.WriteLine($"Ints: None");
            }
            
        }
    }
}
