using System;
using System.Collections.Generic;
using System.Globalization;

// I thought this was interesting, not that the console shows those symbols. :D
// http://stackoverflow.com/questions/15029238/reverse-a-string-with-accent-chars

class ReverseString
{
    static void Main()
    {
        string input = Console.ReadLine();

        Console.WriteLine(safeReverseString(input));
    }

    private static string safeReverseString(string input)
    {
        TextElementEnumerator enumerator = StringInfo.GetTextElementEnumerator(input);
        List<string> elements = new List<string>();

        while (enumerator.MoveNext())
        {
            elements.Add(enumerator.GetTextElement());
        }
        elements.Reverse();

        return string.Join("", (elements.ToArray()));
    }
}
