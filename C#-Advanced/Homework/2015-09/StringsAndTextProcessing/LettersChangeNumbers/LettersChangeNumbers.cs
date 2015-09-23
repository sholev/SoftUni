using System;

class LettersChangeNumbers
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(" \t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        decimal totalSum = 0;

        foreach (string element in input)
        {
            totalSum += NakovsGameResult(element);
        }

        Console.WriteLine("{0:F2}", totalSum);
    }

    private static decimal NakovsGameResult(string input)
    {
        char frontLetter = input[0];
        char backLetter = input[input.Length - 1];
        // http://stackoverflow.com/questions/20044730/convert-character-to-its-alphabet-integer-position
        int frontLetterPosition = (int)frontLetter % 32;
        int backLetterPosition = (int)backLetter % 32;
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
