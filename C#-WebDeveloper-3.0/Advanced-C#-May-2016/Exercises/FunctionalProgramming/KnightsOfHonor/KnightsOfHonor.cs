namespace FunctionalProgramming
{
    using System;
    using System.Text.RegularExpressions;

    class KnightsOfHonor
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            // ReSharper disable once StringLiteralAsInterpolationArgument
            Action<string> printOnNewLine = s => Console.WriteLine(Regex.Replace(s, "(\\w+)\\s*", $"{"Sir ${1}"}{Environment.NewLine}"));

            printOnNewLine(input);
        }
    }
}
