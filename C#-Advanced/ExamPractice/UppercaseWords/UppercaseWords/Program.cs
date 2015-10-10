using System;
using System.Security;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            List<string> outputLines = new List<string>();

            while ((input = Console.ReadLine()) != "END")
            {
                outputLines.Add(handleReversing(input));
            }
            
            Console.WriteLine(SecurityElement.Escape(string.Join("\r\n", outputLines)));

        }

        private static string handleReversing(string input)
        {
            string result = input;
            string pattern = @"\b([A-Z\d]+)\b";
            string magicalPattern = "IHATEREGEX";
            Regex rageEscalator = new Regex(magicalPattern);
            List<string> upperCaseWords = Regex.Matches(result, pattern).Cast<Match>().Select(match => match.Value).ToList();
            result = Regex.Replace(result, pattern, magicalPattern); // Replace matches with aptly named placeholders.

            foreach (var word in upperCaseWords)
            {
                // http://stackoverflow.com/questions/1540620/check-if-a-string-has-at-least-one-number-in-it-using-linq

                if (isPalindrome(word))
                {
                    result = rageEscalator.Replace(result, doubleLetters(word), 1);
                }
                else
                {
                    result = rageEscalator.Replace(result, reverseString(word), 1);
                }
            }

            return result;
        }

        private static string doubleLetters(string input)
        {
            List<char> result = input.ToCharArray().ToList(); ;

            for (int i = 0; i < result.Count; i++)
            {
                if (result[i] >= 'A' && result[i] <= 'Z')
                {
                    result.Insert(i, result[i]);
                    i++;
                }
            }

            return new string(result.ToArray());
        }

        private static string reverseString(string input)
        {
            char[] forReverse = input.ToCharArray();
            Array.Reverse(forReverse);

            return new string(forReverse);
        }

        private static bool isPalindrome(string word)
        {
            word = Regex.Replace(word, @"[\d-]", string.Empty); // remove digits

            if (word.Equals(reverseString(word)))
            {
                return true;
            }

            return false;
        }
    }
}
