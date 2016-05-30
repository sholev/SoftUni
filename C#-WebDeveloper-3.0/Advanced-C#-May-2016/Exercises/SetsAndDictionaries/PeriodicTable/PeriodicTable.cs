namespace BasicSetOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PeriodicTable
    {
        static void Main(string[] args)
        {
            var inputCount = int.Parse(Console.ReadLine());

            var elements = new SortedSet<string>();
            for (int i = 0; i < inputCount; i++)
            {
                Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList()
                    .ForEach(e => elements.Add(e));
            }

            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
