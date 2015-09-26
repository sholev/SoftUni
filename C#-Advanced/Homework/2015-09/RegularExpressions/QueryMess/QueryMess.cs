using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class QueryMess
{
    static void Main()
    {
        string input = Console.ReadLine();        
        List<string> output = new List<string>();
        
        string matchPattern = @"([\@\+\-\w%]+)=([\#\^\(\)\*\@\-\/.\w%+:]+)";

        while (input != "END")
        {
            MatchCollection matches = Regex.Matches(input, matchPattern);
            Dictionary<string, List<string>> matchResults = new Dictionary<string, List<string>>();

            foreach (Match m in matches)
            {
                // Get the name and value from the match, replace %20 and + with space,
                // and trimm for space leftovers around the strings.
                string name = m.Groups[1].ToString().Replace("%20", " ").Replace("+", " ").Trim();                
                string value = m.Groups[2].ToString().Replace("%20", " ").Replace("+", " ").Trim();
                // Replace any multiple whitespaces with single space.
                name = Regex.Replace(name, @"\s+", " ");
                value = Regex.Replace(value, @"\s+", " ");

                if (!matchResults.ContainsKey(name))
                {
                    matchResults.Add(name, new List<string>());
                }
                matchResults[name].Add(value);
            }

            StringBuilder temp = new StringBuilder();
            foreach (var entry in matchResults)
            {
                temp.AppendFormat("{0}=[{1}]", entry.Key, string.Join(", ", entry.Value));                
            }
            output.Add(temp.ToString());

            input = Console.ReadLine();
        }

        foreach (string line in output)
        {
            Console.WriteLine(line);
        }
    }
}