namespace SetsAndDictionariesOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class UserLogs
    {
        static void Main(string[] args)
        {
            var data = new SortedDictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();
            while (input.ToLower() != "end")
            {
                var matchGroups = Regex.Match(input, @"IP=([\d.ABCDEFabcdef:]+)\smessage='.*?'\suser=(.+)").Groups;

                string ip = matchGroups[1].Value;
                string user = matchGroups[2].Value;

                if (!data.ContainsKey(user))
                {
                    data[user] = new Dictionary<string, int>();
                }

                if (!data[user].ContainsKey(ip))
                {
                    data[user][ip] = 1;
                }
                else
                {
                    data[user][ip]++;
                }

                input = Console.ReadLine();
            }

            foreach (var entry in data)
            {
                var user = entry.Key;
                var logs = string.Join(", ", entry.Value.Select(pair => $"{pair.Key} => {pair.Value}"));

                Console.WriteLine($"{user}:\r\n{logs}.");
            }
        }
    }
}
