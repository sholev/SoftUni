namespace Theaters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Theaters.Business;
    using Theaters.Interfaces;

    public class CommandTools
    {
        public string ExecuteAddTheaterCommand(IPerformanceDatabase performancesDatabase, string name)
        {
            performancesDatabase.AddTheater(name);
            return "Theatre added";
        }

        public string ExecutePrintAllTheatersCommand(IEnumerable<string> theaters)
        {
            var inputTheaters = theaters.ToList();

            var theatersCount = inputTheaters.Count();
            if (theatersCount > 0)
            {
                return String.Join(", ", inputTheaters);
            }
            return "No theatres";
        }

        public string ExecutePrintAllPerformancesCommand(IEnumerable<Performance> performances)
        {
            var inputPerformances = performances.ToList();

            if (!inputPerformances.Any())
            {
                return "No performances";
            }

            var output = new List<string>();
            foreach (Performance performance in inputPerformances)
            {
                string title = performance.PerformanceTitle;
                string theater = performance.TheaterName;
                string time = performance.StartDateTime.ToString("dd.MM.yyyy HH:mm");

                output.Add($"({title}, {theater}, {time})");
            }

            return string.Join(", ", output);
        }

        public string ExecutePrintPerformancesCommand(IEnumerable<Performance> performances)
        {
            var inputPerformances = performances.ToList();

            var output = inputPerformances.Select(
                performance =>
                    {
                        string date = performance.StartDateTime.ToString("dd.MM.yyyy HH:mm");
                        return $"({performance.PerformanceTitle}, {date})";
                    });

            if (inputPerformances.Any())
            {
                return string.Join(", ", output);
            }

            return "No performances";
        }
    }
}
