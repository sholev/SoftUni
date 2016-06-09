namespace FunctionalProgramming
{
    using System;
    using System.Text.RegularExpressions;

    class ActionPrint
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            Action<string> printOnNewLine = s => Console.WriteLine(Regex.Replace(s, "\\s+", Environment.NewLine));

            printOnNewLine(input);
        }
    }
}
