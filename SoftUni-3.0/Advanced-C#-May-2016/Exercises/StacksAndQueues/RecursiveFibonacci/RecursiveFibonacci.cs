namespace RecursiveFibonacci
{
    using System;
    using System.Collections.Generic;

    class RecursiveFibonacci
    {
        static void Main(string[] args)
        {
            var position = int.Parse(Console.ReadLine());
            var storedPositions = new Dictionary<int, long>(position);

            if (storedPositions.Count >= 0)
            {
                storedPositions[0] = 0;
            }

            if (storedPositions.Count >= 1)
            {
                storedPositions[0] = 0;
                storedPositions[1] = 1;
            }

            Console.WriteLine(Fibonacci(position, storedPositions));
        }

        static long Fibonacci(int position, Dictionary<int, long> storedPositions)
        {
            if (position == 0 || position == 1)
            {
                return storedPositions[position];
            }

            if (storedPositions.ContainsKey(position))
            {
                return storedPositions[position];
            }

            return
                storedPositions[position] =
                Fibonacci(position - 1, storedPositions) + Fibonacci(position - 2, storedPositions);
        }
    }
}
