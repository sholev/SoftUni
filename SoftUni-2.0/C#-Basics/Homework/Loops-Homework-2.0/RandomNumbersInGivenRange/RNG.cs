using System;

namespace RandomNumbersInGivenRange
{
    class RNG
    {
        static void Main()
        {
            Console.WriteLine("Enter anything but integer to exit.");

            while (true)
            {
                int howManyNums = 0;
                int minNum = 0;
                int maxNum = 0;
                Random rng = new Random();

                try
                {
                    Console.Write("How many numbers: ");
                    howManyNums = int.Parse(Console.ReadLine());

                    Console.Write("Minimal number: ");
                    minNum = int.Parse(Console.ReadLine());

                    Console.Write("Maximal number: ");
                    maxNum = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    return;
                }

                if (minNum <= maxNum)
                {
                    for (int i = 0; i < howManyNums; i++)
                    {                                         // The max number seems to be excluded, thats why +1
                        Console.Write("{0} ", rng.Next(minNum, maxNum + 1));
                    }
                }
                else
                {
                    Console.WriteLine("Bad input, make sure that (min <= max)");
                }

                Console.WriteLine("\r\n" + new string('-', 10));
            }
        }
    }
}
