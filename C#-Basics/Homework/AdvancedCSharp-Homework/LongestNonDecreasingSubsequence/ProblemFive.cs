using System;
using System.Collections.Generic;
using System.Linq;

// Not sure if 100% correct, but it does seem to work.

namespace LongestNonDecreasingSubsequence
{
    class ProblemFive
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter anything but int to exit.");
            
            while (true)
            {
                Console.Write("Enter sequence: ");
                string input = Console.ReadLine();

                int[] inputArray;

                try
                {
                    inputArray = Array.ConvertAll(input.Split(' '), s => int.Parse(s));
                }
                catch (Exception)
                {
                    return;
                }

                List<int> longestSubSeq = new List<int>();
                List<int> tempSubSeq = new List<int>();
                int maxDiff = inputArray.Max() - inputArray.Min() + 1;

                for (int diff = 0; diff < maxDiff; diff++)
                {
                    for (int pos = 0; pos < inputArray.Length; pos++)
                    {
                        tempSubSeq = getSubseqFromPosition(inputArray.ToList(), pos, diff);

                        if (longestSubSeq.Count < tempSubSeq.Count)
                        {
                            longestSubSeq = tempSubSeq;
                        }
                    }
                }

                Console.Write("Longest non-decreasing sequence: ");
                Console.WriteLine(string.Join(" ", longestSubSeq.ToArray()));
                Console.WriteLine(new string('-', 10));
            }
            
        }

        private static List<int> getSubseqFromPosition(List<int> inputList, int position, int diff)
        {
            List<int> resultList = new List<int>();
            resultList.Add(inputList[position]);

            for (int i = position + 1; i < inputList.Count; i++)
            {
                if (resultList.Last() <= inputList[i] && inputList[i] - resultList.Last() <= diff)
                {
                    resultList.Add(inputList[i]);
                }
            }

            return resultList;
        }
    }
}
