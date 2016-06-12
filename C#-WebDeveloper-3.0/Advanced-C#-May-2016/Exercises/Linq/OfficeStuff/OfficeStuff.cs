namespace Linq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class OfficeStuff
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());

            var officeStuff = new SortedDictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < count; i++)
            {
                var parameters = Regex.Match(
                    Console.ReadLine(),
                    @"^\|(?<company>\w+).+?(?<amount>\d+).+?(?<product>\w+)\|$");

                var company = parameters.Groups["company"].Value;
                var product = parameters.Groups["product"].Value;
                var amount = int.Parse(parameters.Groups["amount"].Value);

                if (!officeStuff.ContainsKey(company))
                {
                    officeStuff.Add(company, new Dictionary<string, int>());
                }

                if (!officeStuff[company].ContainsKey(product))
                {
                    officeStuff[company][product] = 0;
                }

                officeStuff[company][product] += amount;
            }

            officeStuff.Select(
                pair =>
                $"{pair.Key}: {String.Join(", ", pair.Value.Select(anotherPair => $"{anotherPair.Key}-{anotherPair.Value}"))}")
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}