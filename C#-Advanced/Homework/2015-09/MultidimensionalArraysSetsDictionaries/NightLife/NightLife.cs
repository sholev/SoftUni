using System;
using System.Collections.Generic;

class NightLife
{ 
    static void Main()
    {
        Dictionary<string, SortedDictionary<string, SortedSet<string>>> performances = new Dictionary<string, SortedDictionary<string, SortedSet<string>>>();

        string input = Console.ReadLine();
        
        while (input != "END")
        {
            string[] cityVenuePerformer = input.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string city = cityVenuePerformer[0];
            string venue = cityVenuePerformer[1];
            string performer = cityVenuePerformer[2];

            if (!performances.ContainsKey(city))
            {
                performances[city] = new SortedDictionary<string, SortedSet<string>>();
            }
            if (!performances[city].ContainsKey(venue))
            {
                performances[city][venue] = new SortedSet<string>();
            }
            if (!performances[city][venue].Contains(performer))
            {
                performances[city][venue].Add(performer);
            }

            input = Console.ReadLine();
        }

        foreach (var cityVenue in performances)
        {
            Console.WriteLine($"\r\n{cityVenue.Key}");

            foreach (var venueWithPerformers in cityVenue.Value)
            {
                Console.WriteLine("->{0}: {1}", venueWithPerformers.Key, string.Join(", ", venueWithPerformers.Value));
            }
        }
    }
}