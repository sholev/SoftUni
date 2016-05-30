namespace BasicDictionaryOperations
{
    using System;
    using System.Collections.Generic;

    class CountSymbols
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var characterRepetitions = new SortedDictionary<char, int>();

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
            
            foreach (var c in characterRepetitions)
            {
                Console.WriteLine($"{c.Key}: {c.Value} time/s");
            }
        }
    }
}
