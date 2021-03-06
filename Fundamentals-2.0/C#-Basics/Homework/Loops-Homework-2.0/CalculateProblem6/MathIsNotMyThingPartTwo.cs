﻿using System;
using System.Numerics; // https://msdn.microsoft.com/en-us/library/system.numerics.biginteger.aspx

// Calculate N! / K!
// Use only one loop.

namespace CalculateProblem6
{
    class MathIsNotMyThingPartTwo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter anything but an integer to exit.");

            while (true) // First loop is for convenient repetition.
            {
                int numberN = 0;
                int numberK = 0;

                try
                {
                    Console.Write("Enter N: ");
                    numberN = int.Parse(Console.ReadLine());
                    Console.Write("Enter K: ");
                    numberK = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    return;
                }

                if (1 < numberK && numberK < numberN && numberN < 100)
                {
                    // No loop used, unless Factorial(); is a loop. :)
                    Console.WriteLine("N! / K! = {0}", Factorial(numberN) / Factorial(numberK));
                }
                else
                {
                    Console.WriteLine("Input should be: 1 < K < N < 100");
                }
                Console.WriteLine(new string('-', 10));
            }
        }

        // I'm not sure if this counts as a loop. :)
        // BigInteger - An attempt to avoid overflowing. Not sure if successful.
        // http://stackoverflow.com/questions/16583665/for-loop-to-calculate-factorials
        private static BigInteger Factorial(int i)
        {
            if (i <= 1)
                return 1;
            return i * Factorial(i - 1);
        }
    }
}
