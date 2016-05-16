namespace Theaters.Business
{
    using System;
    using System.Collections.Generic;

    using Theaters.Exceptions;
    using Theaters.Interfaces;

    public class PerformanceDatabase : IPerformanceDatabase
    {
        private readonly SortedDictionary<string, SortedSet<Performance>> performances =
            new SortedDictionary<string, SortedSet<Performance>>();

        public void AddTheater(string theaterName)
        {
            if (this.performances.ContainsKey(theaterName))
            {
                throw new DuplicateTheaterException("Duplicate theatre");
            }

            this.performances[theaterName] = new SortedSet<Performance>();
        }

        public IEnumerable<string> ListTheaters()
        {
            var theaters = this.performances.Keys;
            return theaters;
        }

        public void AddPerformance(
            string theaterName,
            string performanceTitle,
            DateTime startDateTime,
            TimeSpan duration,
            decimal price)
        {
            if (!this.performances.ContainsKey(theaterName))
            {
                throw new TheaterNotFoundException("Theatre does not exist");
            }

            var performance = this.performances[theaterName];

            var endDateTime = startDateTime + duration;

            if (CheckOverlappingPerformances(performance, startDateTime, endDateTime))
            {
                throw new TimeDurationOverlapException("Time/duration overlap");
            }

            var newPerformance = new Performance(theaterName, performanceTitle, startDateTime, duration, price);
            performance.Add(newPerformance);
        }

        public IEnumerable<Performance> ListAllPerformances()
        {
            var theaters = this.performances.Keys;

            var result = new List<Performance>();

            foreach (var theater in theaters)
            {
                var performance = this.performances[theater];
                result.AddRange(performance);
            }

            return result;
        }

        public IEnumerable<Performance> ListPerformances(string theaterName)
        {
            if (!this.performances.ContainsKey(theaterName))
            {
                throw new TheaterNotFoundException("Theatre does not exist");
            }

            var theaterPerformances = this.performances[theaterName];
            return theaterPerformances;
        }

        private static bool CheckOverlappingPerformances(
            IEnumerable<Performance> performances,
            DateTime start,
            DateTime end)
        {
            foreach (var performance in performances)
            {
                var performanceStart = performance.StartDateTime;
                var performanceEnd = performance.StartDateTime + performance.Duration;

                var isOverlapping = (performanceStart <= start && start <= performanceEnd) 
                    || (performanceStart <= end && end <= performanceEnd) 
                    || (start <= performanceStart && performanceStart <= end) 
                    || (start <= performanceEnd && performanceEnd <= end);

                if (isOverlapping)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
