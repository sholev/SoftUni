namespace ManualStringProcessing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Palindromes
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            SortedSet<string> inputWords = new SortedSet<string>(Regex.Split(input, @"[\s,.?!]+"));

            Console.WriteLine($"[{string.Join(", ", inputWords.Where(w => w.SequenceEqual(w.Reverse())))}]");
        }
    }
}
