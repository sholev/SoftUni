using System;
using System.Numerics; // https://msdn.microsoft.com/en-us/library/system.numerics.biginteger.aspx

// Calculate 1 + 1!/X + 2!/X2 + … + N!/XN
// Use only one loop.

namespace CalculateProblem5
{
    class MathIsNotMyThing
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter anything but an integer to exit.");

            while (true) // First loop is for convenient repetition.
            {
                int numberN = 0;
                int numberX = 0;
                double resultS = 1.0;

                try
                {
                    Console.Write("Enter N: ");
                    numberN = int.Parse(Console.ReadLine());
                    Console.Write("Enter X: ");
                    numberX = int.Parse(Console.ReadLine());

                    for (int i = 1; i <= numberN; i++) // Does that count for only one loop? I'm not sure. :D
                    {
                        resultS += double.Parse(Factorial(i).ToString()) / Math.Pow(numberX, i);
                    }
                }
                catch (Exception)
                {
                    return;
                }

                Console.WriteLine("{0:F5}", resultS);
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
