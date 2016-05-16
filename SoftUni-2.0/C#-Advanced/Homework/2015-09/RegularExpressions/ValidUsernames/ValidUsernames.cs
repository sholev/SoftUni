using System;
using System.Linq;
using System.Text.RegularExpressions;

class ValidUsernames
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();

        string matchPattern = @"\b[a-zA-Z]\w{2,24}\b";
        // http://stackoverflow.com/questions/11416191/how-to-convert-matchcollection-to-string-array
        string[] matches = Regex.Matches(input, matchPattern).Cast<Match>().Select(m => m.Value).ToArray();
        int sum = 0;
        int biggestSumPosition = 0;

        for (int i = 1; i < matches.Length; i++)
        {
            if (matches[i - 1].Length + matches[i].Length > sum)
            {
                sum = matches[i - 1].Length + matches[i].Length;
                biggestSumPosition = i - 1;
            }
        }

        Console.WriteLine("{0}\r\n{1}", matches[biggestSumPosition], matches[biggestSumPosition + 1]);
    }
}