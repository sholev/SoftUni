using System;
using System.Collections.Generic;

// It is slow. On the edge of not passing the judge slow. :(

class MagicStrings
{
    static void Main()
    {
        int diff = Byte.Parse(Console.ReadLine());
        char[] charsInUse  = new char[] {'k', 'n', 'p', 's'};
        char[] charsWeight = new char[] {'1', '4', '5', '3'};
        char[] forbidden = new char[] {'0', '2', '6', '7', '8', '9' };
        int results = 0;
        List<string> forSorting = new List<string>();

        for (int i = 1111; i <= 5555; i++)
            if (IsCorrect(i, forbidden))
                for (int l = 1111; l <= 5555; l++)
                    if (IsCorrect(l, forbidden) && Math.Abs(GetWeight(i) - GetWeight(l)) == diff)
                    {
                        forSorting.Add(GetChars(i, charsInUse, charsWeight) + GetChars(l, charsInUse, charsWeight));
                        results++;
                    }

        forSorting.Sort();
        Console.WriteLine(String.Join("\r\n", forSorting.ToArray())); // http://stackoverflow.com/questions/4981390/convert-a-list-to-a-string-in-c-sharp

        if (results == 0)
            Console.WriteLine("No");
    }

    private static string GetChars(int iNumbers, char[] charsInUse, char[] charsWeight)
    {
        string sNumbers = iNumbers.ToString();
        string result = String.Empty;

        for (int i = 0; i < sNumbers.Length; i++)
            for (int l = 0; l < charsInUse.Length; l++)
                if (sNumbers[i] == charsWeight[l])
                    result += charsInUse[l];

        return result;
    }

    private static int GetWeight(int iNumber)
    {
        string sNumber = iNumber.ToString();
        int weight = 0;

        for (int i = 0; i < sNumber.Length; i++)
            weight += Int32.Parse(sNumber[i].ToString()); // http://stackoverflow.com/questions/239103/c-sharp-char-to-int
        
        return weight;
    }

    private static bool IsCorrect(int iNumber, char[] forbidden)
    {
        string sNumber = iNumber.ToString();

        if (sNumber.IndexOfAny(forbidden) != -1) // http://stackoverflow.com/questions/1390749/check-if-a-string-contains-one-of-10-characters
                return false;

        return true;
    }
}