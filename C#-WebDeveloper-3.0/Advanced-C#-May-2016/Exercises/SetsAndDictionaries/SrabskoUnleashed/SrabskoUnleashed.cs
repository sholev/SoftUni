namespace SetsAndDictionariesOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class SrabskoUnleashed
    {
        static void Main(string[] args)
        {
            var venues = new Dictionary<string, Dictionary<string, int>>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                Match matches = Regex.Match(input, @"^([\S][a-zA-Z\s]+)\s@([a-zA-Z\s]+)\s(\d+)\s(\d+)$");

                if (!matches.Success)
                {
                    continue;
                }
                
                string singer = matches.Groups[1].Value;
                string venue = matches.Groups[2].Value;
                int ticketsPrice = int.Parse(matches.Groups[3].Value);
                int ticketsCount = int.Parse(matches.Groups[4].Value);
                int money = ticketsCount * ticketsPrice;

                if (!venues.ContainsKey(venue))
                {
                    venues[venue] = new Dictionary<string, int>();
                }

                if (!venues[venue].ContainsKey(singer))
                {
                    venues[venue][singer] = 0;
                }

                venues[venue][singer] += money;
            }

            foreach (var location in venues)
            {
                Console.WriteLine($"{location.Key}");

                foreach (var chalgar in location.Value.OrderByDescending(e => e.Value))
                {
                    Console.WriteLine($"#  {chalgar.Key} -> {chalgar.Value}");
                }
            }
        }
    }
}
