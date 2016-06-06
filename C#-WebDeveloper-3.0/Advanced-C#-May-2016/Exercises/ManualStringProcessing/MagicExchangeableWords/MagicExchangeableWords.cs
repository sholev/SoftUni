namespace ManualStringProcessing
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class MagicExchangeableWords
    {
        static void Main(string[] args)
        {
            string[] input = Regex.Split(Console.ReadLine(), @"\s+");
            string stringOne = input[0];
            string stringTwo = input[1];

            Console.WriteLine(AreExchangeable(stringOne, stringTwo).ToString().ToLower());
        }

        private static bool AreExchangeable(string stringOne, string stringTwo)
        {
            string[] sequenceOne = stringOne.ToCharArray().Select(char.ToString).ToArray();
            string[] sequenceTwo = stringTwo.ToCharArray().Select(char.ToString).ToArray();

            ReplaceSingleSymbols(sequenceOne);
            ReplaceSingleSymbols(sequenceTwo);

            bool secondContainsFirst = sequenceOne.All(element => sequenceTwo.Contains(element));
            bool firstContainsSecond = sequenceTwo.All(element => sequenceOne.Contains(element));

            return secondContainsFirst && firstContainsSecond;
        }

        private static void ReplaceSingleSymbols(string[] sequence)
        {
            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i].Length == 1)
                {
                    ReplaceWithCount(sequence, sequence[i], i);
                }
            }
        }

        private static void ReplaceWithCount(string[] sequence, string replacementTarget, int replacementNumber)
        {
            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i].Equals(replacementTarget))
                {
                    sequence[i] = "Replacement" + replacementNumber;
                }
            }
        }
    }
}