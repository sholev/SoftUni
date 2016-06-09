namespace FunctionalProgramming
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class FindEvenOrOdd
    {
        static void Main(string[] args)
        {
            var range = Regex.Split(Console.ReadLine(), "\\s+").Select(int.Parse).ToArray();
            var numbers = Enumerable.Range(range[0], range[1] - range[0] + 1);
            var soughtNumbers = Console.ReadLine();

            Predicate<int> isOdd = (n => Math.Abs(n) % 2 == 1);

            if (soughtNumbers == "odd")
            {
                Console.WriteLine(string.Join(" ", numbers.Where(i => isOdd(i))));
            }
            else
            {
                Console.WriteLine(string.Join(" ", numbers.Where(i => !isOdd(i))));
            }
        }
    }
}