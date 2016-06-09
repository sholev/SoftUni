namespace FunctionalProgramming
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class PredicateForNames
    {
        static void Main(string[] args)
        {
            var length = long.Parse(Console.ReadLine());
            var names = Regex.Split(Console.ReadLine().Trim(), "\\s+").ToArray();

            Predicate<string> nameMatchesLength = (s => s.Length <= length);

            var filteredNames = names.Where(n => nameMatchesLength(n));

            Console.WriteLine(string.Join(Environment.NewLine, filteredNames));
        }
    }
}
