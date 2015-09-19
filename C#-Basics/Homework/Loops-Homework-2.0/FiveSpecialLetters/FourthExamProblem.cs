using System;
using System.Linq;

namespace FiveSpecialLetters
{
    class FourthExamProblem
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            char[] letters =     { 'a', 'b', 'c', 'd', 'e' };
            int[] letterWeight = {  5,  -12,  47,  7,  -32 };
            bool exists = false;

            string validWeightStrings = string.Empty;

            for (int i = 0; i <= 44444; i++)
            {
                if (!IsNotValid(i) &&
                    GetWeight(i, letterWeight) >= start &&
                    GetWeight(i, letterWeight) <= end)
                {
                    // Adding to string for sorting later.
                    // This could be skipped and printed instead.
                    validWeightStrings += GetLetters(i, letters);
                    exists = true;
                }
            }

            if (exists)
            {   // The sorting could be skipped, I've added it for testing
                // since I had problems passing the judge.
                validWeightStrings = validWeightStrings.Trim();
                string[] forSorting = validWeightStrings.Split(' ');
                Array.Sort(forSorting);
                Console.WriteLine(string.Join(" ", forSorting));
            }
            else
            {
                Console.WriteLine("No");
            }

        }

        private static bool IsNotValid(int number)
        {
            string sNumber = number.ToString();

            // Does sNumber contain invalid character:
            return sNumber.IndexOfAny("56789".ToCharArray()) != -1;
        }

        private static string GetLetters(int combination, char[] letters)
        {
            // A bit of a mess here, makes it hard to understand.
            char[] sCombination = combination.ToString().PadLeft(5, '0').ToCharArray();
            int[] weightIndexes = Array.ConvertAll(sCombination, c => (int)char.GetNumericValue(c));
            string result = string.Empty;

            for (int i = 0; i < weightIndexes.Length; i++)
            {
                result += letters[weightIndexes[i]];
            }
            result +=' ';

            return result;
        }

        private static int GetWeight(int combination, int[] weight)
        {
            // Even a worse mess...
            char[] sCombination = combination.ToString().PadLeft(5, '0').ToCharArray();
            sCombination = sCombination.Distinct().ToArray();
            int[] weightIndexes = Array.ConvertAll(sCombination, c => (int)char.GetNumericValue(c));
            int weightResult = 0;

            for (int i = 0; i < weightIndexes.Length; i++)
            {
                weightResult += (i + 1) * weight[weightIndexes[i]];
            }

            return weightResult;
        }
    }
}
