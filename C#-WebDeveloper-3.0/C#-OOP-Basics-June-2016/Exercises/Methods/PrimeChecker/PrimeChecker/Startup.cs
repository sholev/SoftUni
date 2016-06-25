namespace PrimeChecker
{
    using System;

    class Startup
    {
        static void Main(string[] args)
        {
            var input = long.Parse(Console.ReadLine());
            var number = new Number(input, Number.CheckPrime(input));
            Console.WriteLine(number.GetNextValidPrime());
        }
    }
}
