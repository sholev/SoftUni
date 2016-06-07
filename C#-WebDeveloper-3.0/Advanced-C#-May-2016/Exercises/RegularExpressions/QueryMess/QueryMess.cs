namespace RegularExpressions
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    class QueryMess
    {
        static void Main(string[] args)
        {
            string matchPattern = @"(?<name>[\@\+\-\w%]+)=(?<value>[\#\^\(\)\*\@\-\/.\w%+:]+)";

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                MatchCollection matches = Regex.Matches(input, matchPattern);

                Dictionary<string, List<string>> matchResults = new Dictionary<string, List<string>>();

                foreach (Match m in matches)
                {
                    string name = m.Groups["name"].Value.Replace("%20", " ").Replace("+", " ");
                    string value = m.Groups["value"].Value.Replace("%20", " ").Replace("+", " ");

                    name = Regex.Replace(name, @"(\s+)", " ").Trim();
                    value = Regex.Replace(value, @"(\s+)", " ").Trim();

                    if (!matchResults.ContainsKey(name))
                    {
                        matchResults.Add(name, new List<string>());
                    }
                    matchResults[name].Add(value);
                }

                StringBuilder temp = new StringBuilder();
                foreach (var entry in matchResults)
                {
                    Console.Write($"{entry.Key}=[{string.Join(", ", entry.Value)}]");
                }
                Console.WriteLine();
            }
        }
    }
}
