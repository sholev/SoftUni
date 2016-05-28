using System;

class NumbersNotDivisableByThreeAndSeven
{
    static void Main()
    {
        Console.WriteLine("Enter anything but a whole number to exit.");

        while (true)
        {
            int number = 0;

            try
            {
                Console.Write("Enter N: ");
                number = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                return;
            }

            for (int i = 1; i <= number; i++)
            {
                if (i % 3 != 0 && i % 7 != 0) // Only if not divisable by 3 and 7
                {
                    Console.Write("{0} ", i);
                }
            }

            Console.WriteLine("\r\n" + new string('-', 10));
        }
    }
}