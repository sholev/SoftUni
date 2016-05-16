namespace Theaters.Business
{
    using System;

    public class Performance : IComparable<Performance>
    {
        public Performance(
            string theaterName,
            string performanceTitle,
            DateTime startDateTime, 
            TimeSpan duration, 
            decimal price)
        {
            this.TheaterName = theaterName;
            this.PerformanceTitle = performanceTitle;
            this.StartDateTime = startDateTime;
            this.Duration = duration; this.Price = price;
        }

        public string TheaterName { get; }

        public string PerformanceTitle { get; }

        public DateTime StartDateTime { get; }

        public TimeSpan Duration { get; }

        public decimal Price { get; }

        int IComparable<Performance>.CompareTo(Performance otherPerformance)
        {
            int result = this.StartDateTime.CompareTo(otherPerformance.StartDateTime);

            return result;
        }

        public override string ToString()
        {
            string result =
                $"Performance(Tr32: {this.TheaterName};"
                + $" Tr23: {this.PerformanceTitle};"
                + $" startDateTime: {this.StartDateTime.ToString("dd.MM.yyyy HH:mm")},"
                + $" duration: {this.Duration.ToString("hh':'mm")}," 
                + $" price: {this.Price.ToString("f2")})";

            return result;
        }
    }
}
