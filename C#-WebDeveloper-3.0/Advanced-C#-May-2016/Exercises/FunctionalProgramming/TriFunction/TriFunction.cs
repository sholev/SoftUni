namespace FunctionalProgramming
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class TriFunction
    {
        static void Main(string[] args)
        {
            var minSum = int.Parse(Console.ReadLine());
            var names = Regex.Split(Console.ReadLine(), "\\s+");

            Func<string, int, bool> sumIsValidFunc =
                (name, sum) => name.ToCharArray().Sum(c => c) > sum;

            Func<string[], int, Func<string, int, bool>, string> firstValidNameFunc =
                (nameArrays, sum, function) => nameArrays.FirstOrDefault(name => function(name, sum));

            Console.WriteLine(firstValidNameFunc(names, minSum, sumIsValidFunc));
        }
    }
}
