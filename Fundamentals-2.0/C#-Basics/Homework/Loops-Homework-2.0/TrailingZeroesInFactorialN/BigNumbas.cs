using System;
using System.Numerics; // https://msdn.microsoft.com/en-us/library/system.numerics.biginteger.aspx

namespace TrailingZeroesInFactorialN
{
    class BigNumbas
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter anything but a whole number to exit.");

            while (true)
            {
                int input = 0;

                try
                {
                    Console.Write("Enter n: ");
                    input = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                }
                catch (Exception)
                {
                    return;
                }



                Console.WriteLine("Trailing zeroes of {0}! - {1}", input, GetTrailingZeroes(Factorial(input)));
                Console.WriteLine(new string('-', 10));
            }
        }

        private static int GetTrailingZeroes(BigInteger hugeNumber)
        {
            Console.Write("Converting BigInteger to String, this might take a while... ");
            string sHugeNumber = hugeNumber.ToString(); // This is slow for big numbers.
            Console.WriteLine(" - Done.");
            int counter = 0;

            for (int i = sHugeNumber.Length - 1; i >= 0; i--)
            {
                if (sHugeNumber[i] == '0')
                {
                    counter++;
                }
                else
                {
                    Console.WriteLine();
                    return counter;
                }
            }

            Console.WriteLine();
            return counter;
        }

        // http://stackoverflow.com/questions/16583665/for-loop-to-calculate-factorials
        private static BigInteger Factorial(int input)
        {
            BigInteger result = 1;
            int percent = GetPercent(input, input);

            Console.Write("Calculating factorial: ");
            for (int i = input; i > 1; i--)
            {
                result *= i;

                // This is not necessary, but watching it 
                // while waiting is a good time waster. :D
                if (percent != GetPercent(i, input) / 2) // Don't want more than 100 '|'.
                {
                    percent = GetPercent(i, input) / 2;  // Divided by two so we get
                    Console.Write('|');                  // half of the printing.
                }
            }

            Console.WriteLine();
            return result;
        }

        private static int GetPercent(double part, double whole)
        {
            return (int)((part / whole) * 100.0);
        }
    }

}
