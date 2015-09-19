using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NightLife
{
    static void Main()
    {
        Dictionary<string, SortedDictionary<string, string[]>> performances = new Dictionary<string, SortedDictionary<string, string[]>>();
        Dictionary<string, string[]> tempVenuePerformance = new Dictionary<string, string[]>();
        string[] tempPerformances = new string[0];
        string input = Console.ReadLine();
        
        while (input != "END")
        {
            string[] locationVenuePerformer = input.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            if (!performances.ContainsKey(locationVenuePerformer[0]))
            {
                tempVenuePerformance.Add(locationVenuePerformer[1], )
                performances.Add(locationVenuePerformer[0], tempVenuePerformance);
            }

            input = Console.ReadLine();
        }
    }
}