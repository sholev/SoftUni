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

        // In the loop I'm checking one number ahead,
        // so I'm starting with adding the first one.
        temp.Add(inputNumbers[0]);

        for (int i = 1; i < inputNumbers.Length; i++)
        {
            // If the next number is bigger, add it to the same list.
            if (inputNumbers[i - 1] < inputNumbers[i])
            {
                temp.Add(inputNumbers[i]);
            }
            // If it isn't bigger, save the list and start the next sequence list.
            else
            {
                sequences.Add(temp);
                temp = new List<int>();
                temp.Add(inputNumbers[i]);
            }
        }

        // Add the last sequence to the list of sequences
        sequences.Add(temp);
        temp = new List<int>();

        foreach (var sequence in sequences)
        {
            // Save the longest sequence
            if (temp.Count < sequence.Count)
            {
                temp = sequence;
            }
            // Print all sequences
            foreach (var number in sequence)
            {
                Console.Write("{0} ", number);
            }
            Console.WriteLine();
        }

        Console.WriteLine("Longest: {0}", string.Join(" ", temp));
    }
}
