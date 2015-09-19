using System;
using System.Collections.Generic;

class LongestIncreasingSequence
{
    static void Main()
    {
        string input = Console.ReadLine();
        int[] inputNumbers = Array.ConvertAll(
            input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries),
            element => int.Parse(element));

        List<List<int>> sequences = new List<List<int>>();
        List<int> temp = new List<int>();

        temp.Add(inputNumbers[0]);

        for (int i = 1; i < inputNumbers.Length; i++)
        {
             if (inputNumbers[i - 1] < inputNumbers[i])
            {
                temp.Add(inputNumbers[i]);
            }
            else
            {
                sequences.Add(temp);
                temp = new List<int>();
                temp.Add(inputNumbers[i]);
            }
        }

        sequences.Add(temp);
        temp = new List<int>();

        foreach (var sequence in sequences)
        {
            // Get the longest sequence
            if (temp.Count < sequence.Count)
            {
                temp = sequence;
            }

            foreach (var number in sequence)
            {
                Console.Write("{0} ", number);
            }
            Console.WriteLine();
        }

        Console.WriteLine("Longest: {0}", string.Join(" ", temp));
    }
}
