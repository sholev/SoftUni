namespace FunctionalProgramming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class CustomMinFunction
    {
        static void Main(string[] args)
        {
            var input = Regex.Split(Console.ReadLine(), "\\s+").Select(int.Parse);

            Func<IEnumerable<int>, int> findMin = numbers => numbers.Min();

            Console.WriteLine(findMin(input));
        }
    }
}
