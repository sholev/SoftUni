using System;

class NumbersFromOneToN
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
                Console.Write("{0} ", i);
            }

            Console.WriteLine("\r\n" + new string('-', 10));
        }
    }
}