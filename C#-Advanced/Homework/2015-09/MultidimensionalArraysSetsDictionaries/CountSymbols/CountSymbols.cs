using System;
using System.Collections.Generic;
using System.Linq;

class CountSymbols
{
    static void Main()
    {
        string input = Console.ReadLine();

        SortedDictionary<char, int> characterRepetitions = new SortedDictionary<char, int>();

        foreach (char c in input)
        {
            if (!characterRepetitions.ContainsKey(c))
            {
                characterRepetitions.Add(c, 1);
            }
            else
            {
                characterRepetitions[c]++;
            }
        }

        char[] charKeys = characterRepetitions.Keys.ToArray();

        foreach (var c in charKeys)
        {
            Console.WriteLine($"{c}: {characterRepetitions[c]} time/s");
        }
    }
}