namespace FunctionalProgramming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ListOfPredicates
    {
        static void Main(string[] args)
        {
            var ceiling = int.Parse(Console.ReadLine());

            var divisors =
                Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse);

            var predicates = divisors.Select(divisor => (Func<int, bool>)(n => n % divisor == 0)).ToArray();

            var result = new List<int>();
            for (int i = 1; i <= ceiling; i++)
            {
                bool dreddApproved = true;
                foreach (Func<int, bool> predicate in predicates)
                {
                    if (!predicate(i))
                    {
                        dreddApproved = false;
                        break;
                    }
                }
                if (dreddApproved)
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}