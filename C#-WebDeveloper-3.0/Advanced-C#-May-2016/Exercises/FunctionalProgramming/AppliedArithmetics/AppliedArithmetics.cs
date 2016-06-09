namespace FunctionalProgramming
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    static class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            var numebrs = Regex.Split(Console.ReadLine().Trim(), "\\s+").Select(long.Parse).ToArray();

            Func<long[], long[]> add = (longs => longs.Select(e => e + 1).ToArray());
            Func<long[], long[]> multiply = (longs => longs.Select(e => e * 2).ToArray());
            Func<long[], long[]> subtract = (longs => longs.Select(e => e - 1).ToArray());
            Action<long[]> print = (longs => Console.WriteLine($"{string.Join(" ", longs)}"));

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                switch (input)
                {
                    case "add":
                        numebrs = add(numebrs);
                        break;
                    case "multiply":
                        numebrs = multiply(numebrs);
                        break;
                    case "subtract":
                        numebrs = subtract(numebrs);
                        break;
                    case "print":
                        print(numebrs);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }
    }
}
