using System;
using System.Collections.Generic;
using System.Linq;

class SortedSubsetSums
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
        //List<string> subsets = new List<string>();
        bool matchingSubsetsExist = false;

        for (int mask = 0; mask < maskSize - 1; mask++)
        {
            List<int> temp = new List<int>();
            temp = GetSubset(mask + 1, inputNumbers);            

            if (temp.Sum() == sum)
            {
                temp.Sort();
                subsets.Add(temp);
                //subsets.Add(string.Format("{0} = {1}", string.Join(" + ", temp), sum));
                matchingSubsetsExist = true;
            }
        }

        subsets = subsets.OrderBy(a => a.Count()).ThenBy(a => a[0]).ToList();

        foreach (var subset in subsets)
        {
            Console.WriteLine("{0} = {1}", string.Join(" + ", subset), sum);
            //Console.WriteLine(subset);
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
