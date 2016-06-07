namespace RegularExpressions
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class ValidUsernames
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var matchPattern = @"\b[a-zA-Z]\w{2,24}\b";

            var matches = Regex.Matches(input, matchPattern).Cast<Match>().Select(m => m.Value).ToArray();
            int biggestSum = 0;
            int biggestSumPosition = 0;

            for (int i = 1; i < matches.Length; i++)
            {
                if (matches[i - 1].Length + matches[i].Length > biggestSum)
                {
                    biggestSum = matches[i - 1].Length + matches[i].Length;
                    biggestSumPosition = i - 1;
                }
            }

            Console.WriteLine(matches[biggestSumPosition]);
            Console.WriteLine(matches[biggestSumPosition + 1]);
        }
    }
}
