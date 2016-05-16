using System;
using System.Collections.Generic;
using System.Linq;

class SequencesOfEqualStrings
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        // http://stackoverflow.com/questions/47752/remove-duplicates-from-a-listt-in-c-sharp
        List<string> inputNoDupes = input.Distinct().ToList();

        // The dictionary could be skipped here, but I'm keeping it as a reference for future use.
        Dictionary<string, int> stringRepetitions = new Dictionary<string, int>();

        foreach (string s in inputNoDupes)
        {
            stringRepetitions.Add(s, GetNumberOfRepetitions(s, input));

            for (int i = 0; i < stringRepetitions[s]; i++)
            {
                Console.Write("{0} ", s);
            }
            Console.WriteLine();
        }
    }

    private static int GetNumberOfRepetitions(string s, string[] input)
    {
        int count = 0;

        foreach (string item in input)
        {
            if (item == s)
            {
                count++;
            }
        }

        return count;
    }
}
