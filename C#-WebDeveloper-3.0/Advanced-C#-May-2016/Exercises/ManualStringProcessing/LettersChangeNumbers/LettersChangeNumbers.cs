namespace ManualStringProcessing
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class LettersChangeNumbers
    {
        static void Main(string[] args)
        {
            string[] input = Regex.Split(Console.ReadLine().Trim(), @"\s+");
            decimal totalSum = input.Sum(s => NakovsGameResult(s));

            Console.WriteLine("{0:F2}", totalSum);
        }

        private static decimal NakovsGameResult(string input)
        {
            char frontLetter = input[0];
            char backLetter = input[input.Length - 1];

            int frontLetterPosition = frontLetter % 32;
            int backLetterPosition = backLetter % 32;
            decimal number = decimal.Parse(input.Substring(1, input.Length - 2));

            if (char.IsUpper(frontLetter))
            {
                number /= frontLetterPosition;
            }
            else
            {
                number *= frontLetterPosition;
            }

            if (char.IsUpper(backLetter))
            {
                number -= backLetterPosition;
            }
            else
            {
                number += backLetterPosition;
            }

            return number;
        }
    }
}
