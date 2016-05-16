using System;

namespace CalculateGCD
{
    class DidntSleepWell
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter anything but int to exit.");

            while (true)
            {
                int a = 0;
                int b = 0;

                try
                {
                    Console.Write("Enter a: ");
                    a = int.Parse(Console.ReadLine());
                    Console.Write("Enter b: ");
                    b = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    return;
                }

                Console.WriteLine("GCD({0}, {1}) = {2}", a, b, GCD(a, b));
                Console.WriteLine(new string('-', 10));
            }
        }

        // http://dotnet-snippets.com/snippet/euclidean-algorithm-for-gcd/613
        private static int GCD(int a, int b)
        {
            // Endless loop if there is a negative number.
            // That is why I'm getting rid of the sign.
            // Not sure if this is mathematically correct though.
            a = Math.Abs(a);
            b = Math.Abs(b);

            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            if (a == 0)
                return b;
            else
                return a;
        }
    }
}
