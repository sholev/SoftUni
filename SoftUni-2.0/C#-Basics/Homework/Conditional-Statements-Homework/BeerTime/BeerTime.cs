using System;

/* Resources:
 * http://stackoverflow.com/questions/1504494/find-if-current-time-falls-in-a-time-range
 * https://msdn.microsoft.com/en-us/library/system.datetime.parse(v=vs.110).aspx
 * http://stackoverflow.com/questions/1026841/how-to-get-only-time-from-date-time-c-sharp
 */

class BeerTime
{
    static void Main()
    {
        string inputTime = string.Empty;
        DateTime time = new DateTime();
        TimeSpan beerTimeStart = new TimeSpan(12, 59, 59); // for some reason it doesnt work properly if set (13, 00, 0)
        TimeSpan beerTimeEnd = new TimeSpan(03, 00, 0);

        Console.WriteLine("Type in \"exit\" to exit.");

        while (inputTime != "exit")
        {
            Console.Write("Enter time (hh:mm tt): ");
            inputTime = Console.ReadLine();

            try
            {
                time = DateTime.Parse(inputTime);

                if ((time.TimeOfDay >= beerTimeEnd) && (time.TimeOfDay <= beerTimeStart)) 
                    Console.WriteLine("not-beer time");

                else
                    Console.WriteLine("beer time");
            }
            catch (Exception)
            {
                Console.WriteLine("invalid time");
            }

            Console.WriteLine(new string('-', 10));
        }

    }
}