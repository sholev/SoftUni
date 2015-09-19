using System;
using System.Globalization;

namespace DifferenceBetweenDates
{
    class ProblemOne
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter anything but date in format (dd.MM.yyyy) to exit.");

            while (true)
            {
                DateTime firstDate = new DateTime();
                DateTime secondDate = new DateTime();
                TimeSpan daysInBetween = new TimeSpan();

                try
                {
                    Console.Write("First Date: ".PadLeft(15));
                    firstDate = DateTime.ParseExact(Console.ReadLine(), "d.MM.yyyy", CultureInfo.InvariantCulture);

                    Console.Write("Second Date: ".PadLeft(15));
                    secondDate = DateTime.ParseExact(Console.ReadLine(), "d.MM.yyyy", CultureInfo.InvariantCulture);
                }
                catch (Exception)
                {
                    return;
                }

                daysInBetween = secondDate - firstDate;

                Console.Write("Days In Between: ".PadLeft(15));
                Console.WriteLine(daysInBetween.Days);    // If we do not want negative numbers
                                                          // we could use Math.Abs(daysInBetween.Days)
                Console.WriteLine(new string('-', 10).PadLeft(15));
            }
        }
    }
}
