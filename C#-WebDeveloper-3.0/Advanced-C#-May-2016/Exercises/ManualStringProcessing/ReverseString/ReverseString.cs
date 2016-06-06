namespace ManualStringProcessing
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    class ReverseString
    {
        static void Main()
        {
            string input = Console.ReadLine();

            Console.WriteLine(SafeReverseString(input));
        }

        // http://stackoverflow.com/questions/15029238/reverse-a-string-with-accent-chars
        private static string SafeReverseString(string input)
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
}
