using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomizeNumbersFromOneToN
{
    class RNGesus
    {
        static void Main()
        {
            Console.WriteLine("Enter anything but integer to exit.");

            while (true)
            {
                int inputNum = 0;
                List<int> numbers = new List<int>();
                Random rng = new Random();

                try
                {
                    Console.Write("Enter N: ");
                    inputNum = int.Parse(Console.ReadLine());

                }
                catch (Exception)
                {
                    return;
                }

                for (int i = 1; i <= inputNum; i++)
                {
                    numbers.Add(i);
                }

                // http://stackoverflow.com/questions/273313/randomize-a-listt-in-c-sharp
                var randomNumbers = numbers.OrderBy(a => rng.Next());

                foreach (var num in randomNumbers)
                {
                    Console.Write("{0} ", num);
                }


                Console.WriteLine("\r\n" + new string('-', 10));
            }
        }
    }
}
