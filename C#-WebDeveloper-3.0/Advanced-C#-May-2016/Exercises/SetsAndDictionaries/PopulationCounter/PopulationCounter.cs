namespace PopulationCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PopulationCounter
    {
        static void Main(string[] args)
        {
            var countries = new Dictionary<string, long>();
            var cities = new Dictionary<string, Dictionary<string, long>>();
            string input = Console.ReadLine();
            while (input != "report")
            {
                string[] parameters = input.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                string city = parameters[0];
                string country = parameters[1];
                long population = long.Parse(parameters[2]);

                if (!countries.ContainsKey(country))
                {
                    countries[country] = 0L;
                    cities[country] = new Dictionary<string, long>();
                }

                countries[country] += population;

                if (!cities[country].ContainsKey(city))
                {
                    cities[country][city] = 0L;
                }

                cities[country][city] += population;

                input = Console.ReadLine();
            }

            foreach (var country in countries.OrderByDescending(pair => pair.Value))
            {
                Console.WriteLine($"{country.Key} (total population: {country.Value})");

                foreach (var city in cities[country.Key].OrderByDescending(pair => pair.Value))
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }
    }
}
