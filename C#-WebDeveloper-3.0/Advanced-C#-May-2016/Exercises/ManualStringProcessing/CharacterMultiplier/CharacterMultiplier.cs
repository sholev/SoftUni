namespace ManualStringProcessing
{
    using System;
    using System.Text.RegularExpressions;

    class CharacterMultiplier
    {
        static void Main(string[] args)
        {
            string[] input = Regex.Split(Console.ReadLine(), @"\s+");
            string firstWord = input[0];
            string secondWord = input[1];

            int minLength = Math.Min(firstWord.Length, secondWord.Length);
            int result = 0;
            for (int i = 0; i < minLength; i++)
            {
                result += firstWord[i] * secondWord[i];
            }

            result += RemainingCharCodes(minLength, firstWord.Length > secondWord.Length ? firstWord : secondWord);

            Console.WriteLine(result);
        }

        private static int RemainingCharCodes(int start, string str)
        {
            int sum = 0;
            for (int i = start; i < str.Length; i++)
            {
                sum += str[i];
            }
            return sum;
        }
    }
}
