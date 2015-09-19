using System;
using System.Collections.Generic;
using System.Linq;

class SubsetSums
{ 
    static void Main()
    {
        int sum = int.Parse(Console.ReadLine());

        string input = Console.ReadLine();
        int[] inputNumbers = Array.ConvertAll(
            input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries),
            element => int.Parse(element));

        // Remove duplicates
        inputNumbers = inputNumbers.Distinct().ToArray();

        int maskSize = (int)Math.Pow(2, inputNumbers.Length);
        List<List<int>> subsets = new List<List<int>>();
        bool matchingSubsetsExist = false;

        for (int mask = 0; mask < maskSize - 1; mask++)
        {
            subsets.Add(GetSubset(mask + 1, inputNumbers));

            if (subsets[mask].Sum() == sum)
            {
                Console.WriteLine("{0} = {1}", string.Join(" + ", subsets[mask]), sum);
                matchingSubsetsExist = true;
            }
        }

        if (!matchingSubsetsExist)
        {
            Console.WriteLine("No matching subsets.");
        }

    }

    private static List<int> GetSubset(int mask, int[] numbers)
    {
        List<int> temp = new List<int>();

        for (int i = 0; i < numbers.Length; i++)
        {
            if (((mask >> i) & 1) == 1)
            {
                temp.Add(numbers[i]);
            }
        }

        return temp;
    }
}
