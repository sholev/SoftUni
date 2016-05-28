using System;
using System.Text.RegularExpressions;
using System.Linq;

class ExtractEmails
{
    static void Main()
    {
        string input = Console.ReadLine();
        // Need to get back to this and understand it better.
        string matchPattern = @"(?<=\s|^)([^\W_][\w.-]*[^\W_])@([^\W]+[\w.-]+[^\W]+)";

        // http://stackoverflow.com/questions/11416191/how-to-convert-matchcollection-to-string-array
        string[] matches = Regex.Matches(input, matchPattern).Cast<Match>().Select(m => m.Value).ToArray();
        Console.WriteLine(string.Join("\r\n", matches));
    }
}
