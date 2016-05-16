using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SrabskoUnleashed
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            List<string> lines = new List<string>();

            while ((input = Console.ReadLine()) != "End")
            {
                lines.Add(input);
            }

            string pattern = @"([\S][a-zA-Z\s]+)\s@([a-zA-Z\s]+)\s(\d+)\s(\d+)";

            string singer = string.Empty;
            string venue = string.Empty;
            int ticketsPrice = 0;
            int ticketsCount = 0;
            int money = 0;

            var output = new Dictionary<string, Dictionary<string, int>>();

            foreach (var line in lines)
            {
                Match matches = Regex.Match(line, pattern);

                try
                {
                    singer = matches.Groups[1].Value;
                    venue = matches.Groups[2].Value;
                    ticketsPrice = int.Parse(matches.Groups[3].Value);
                    ticketsCount = int.Parse(matches.Groups[4].Value);
                    money = ticketsCount * ticketsPrice;

                    if (!output.ContainsKey(venue))
                    {
                        output[venue] = new Dictionary<string, int>();
                    }
                    if (!output[venue].ContainsKey(singer))
                    {
                        output[venue].Add(singer, 0);
                    }

                    output[venue][singer] += money;
                }
                catch (Exception) { }
                
            }

            foreach (var location in output)
            {
                Console.WriteLine($"{location.Key}");

                var sortedChalgars = from entry in location.Value orderby entry.Value descending select entry;

                foreach (var chalgar in sortedChalgars)
                {                    
                    Console.WriteLine($"#  {chalgar.Key} -> {chalgar.Value}");
                }
            }
        }
    }
}
