using System;
using System.Linq;
using System.Text.RegularExpressions;

class SentenceExtractor
{
    static void Main()
    {
        string keyword = Console.ReadLine();
        string input = Console.ReadLine();

        string matchPattern = string.Format(@"(?<=\s|^)(?:\s)*([^?!.]*\b{0}\b[^!?.]*[!.?])", keyword);
        // http://stackoverflow.com/questions/11416191/how-to-convert-matchcollection-to-string-array
        string[] matches = Regex.Matches(input, matchPattern).Cast<Match>().Select(m => m.Value).ToArray();
        Console.WriteLine(string.Join("\r\n", matches));
    }
}