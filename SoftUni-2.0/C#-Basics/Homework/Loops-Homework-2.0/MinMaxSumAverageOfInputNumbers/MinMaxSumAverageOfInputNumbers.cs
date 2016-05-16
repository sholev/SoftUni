using System;
using System.Collections.Generic;
using System.Linq;

/* After finishing this I realised that it has to get N first and then
 * get N numbers. It works as intended right now, you just don't need
 * to enter N, instead you can enter "exit" when you're done.
 */

class MinMaxSumAverageOfInputNumbers
{
    static void Main()
    {
        List<double> dList = new List<double>();
        string input = string.Empty;

        while (true)
        {
            Console.WriteLine("\r\n\r\n Enter \"exit\" to exit, \"reset\" to start over.");
            Console.Write(" Add number: ");
            input = Console.ReadLine();

            if (input.ToLower() == "reset")
            {
                dList.Clear();
                Console.Clear();
                continue;
            }
            else if (input.ToLower() == "exit")
            {
                return;
            }
            else
            {
                try
                {
                    dList.Add(double.Parse(input));
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Wrong input.");
                    continue;
                }

                Console.Clear();
                Console.WriteLine(" min = {0:F}\r\n max = {1:F}\r\n sum = {2:F}\r\n avg = {3:F}\r\n",
                    dList.Min(), dList.Max(), dList.Sum(), dList.Average()); // Using Linq.

                Console.Write("  For numbers: ");
                foreach (var number in dList)
                {
                    Console.Write("{0:F} ", number);
                }
            }
        }
    }
}