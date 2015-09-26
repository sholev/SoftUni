using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

// Whoever came up with this must be the devil... :D
// Interesting read: http://stackoverflow.com/questions/1732348/regex-match-open-tags-except-xhtml-self-contained-tags/1732454

class ExtractHyberlinks
{
    static void Main()
    {
        string input = Console.ReadLine();
        StringBuilder inputText = new StringBuilder();

        while (input != "END")
        {
            inputText.AppendFormat("{0}\r\n", input);
            input = Console.ReadLine();
        }

        // Copy/Pasta pattern - couldn't solve it T_T
        string matchPattern = @"(?<=<a\s+(?:[^>]+\s+)?href\s*=\s*)(?:""([^""]*)""|'([^']*)'|([^\s>]+))(?=[^>]*>)";

        // http://stackoverflow.com/questions/11416191/how-to-convert-matchcollection-to-string-array
        // Trim here is used to remove the leftover " and '
        string[] matches = Regex.Matches(inputText.ToString(), matchPattern).Cast<Match>().Select(m => m.Value.Trim(@"""'".ToCharArray())).ToArray();

        Console.WriteLine(string.Join("\r\n", matches));
    }
}