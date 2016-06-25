namespace FibonacciNumbers
{
    using System;

    class Startup
    {
        static void Main(string[] args)
        {
            var startPosition = int.Parse(Console.ReadLine());
            var endPosition = int.Parse(Console.ReadLine());

            var fibonacci = new Fibonacci(endPosition);
            var result = fibonacci.GetNumbersInRange(startPosition, endPosition);

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
