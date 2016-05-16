namespace Stacks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ReverseNumbers
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>();

            Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList()
                .ForEach(n => numbers.Push(n));

            while (numbers.Count > 0)
            {
                Console.Write($"{numbers.Pop()} ");
            }

            Console.WriteLine();
        }
    }
}
