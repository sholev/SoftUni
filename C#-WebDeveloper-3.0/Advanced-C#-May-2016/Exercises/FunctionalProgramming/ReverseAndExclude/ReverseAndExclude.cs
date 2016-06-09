namespace FunctionalProgramming
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class ReverseAndExclude
    {
        static void Main(string[] args)
        {
            var numebrs = Regex.Split(Console.ReadLine().Trim(), "\\s+").Select(long.Parse).ToArray();
            var divisor = long.Parse(Console.ReadLine());

            Func<long[], long[]> reverse = longs => longs.Reverse().ToArray();
            // Where takes Func<T, bool> and not Predicate<T>
            Func<long, bool> isDivisable = number => number % divisor != 0;
            Func<long[], long[]> filter = longs => longs.Where(isDivisable).ToArray();

            Console.WriteLine(string.Join(" ", filter(reverse(numebrs))));
        }
    }
}
