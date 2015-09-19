using System;
using System.Numerics; // https://msdn.microsoft.com/en-us/library/system.numerics.biginteger.aspx

// In the problem description it is said that (1 < n < 100).
// However we see an example where N = 0. I will use (1 < n < 100).

namespace CatalanNumbers
{
    class MathIsReallyNotMyThing
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter anything but an integer to exit.");

            while (true)
            {
                int numberN = 0;

                try
                {
                    Console.Write("Enter N: ");
                    numberN = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    return;
                }

                if (1 < numberN && numberN < 100)
                {
                    Console.WriteLine("Catalan(n) = {0}",
                        Factorial(2 * numberN) / (Factorial(numberN + 1) * Factorial(numberN)));
                }
                else
                {
                    Console.WriteLine("Input should be: 1 < N < 100");
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
