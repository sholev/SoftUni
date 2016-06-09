namespace FunctionalProgramming
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class CustomComparator
    {
        static void Main(string[] args)
        {
            var numbers = Regex.Split(Console.ReadLine().Trim(), "\\s+").Select(int.Parse).ToArray();

            Array.Sort(numbers,
                (a, b) =>
                    {
                        var remainderA = Math.Abs(a) % 2;
                        var remainderB = Math.Abs(b) % 2;

                        return remainderA != remainderB ? remainderA.CompareTo(remainderB) : a.CompareTo(b);
                    });

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}