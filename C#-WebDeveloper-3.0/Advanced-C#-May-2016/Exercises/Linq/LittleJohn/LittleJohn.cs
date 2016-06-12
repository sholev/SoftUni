namespace Linq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class LittleJohn
    {
        static void Main(string[] args)
        {
            var inputLines =
                new List<string> { Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine() };

            var arrows = new[] { ">>>----->>", ">>----->", ">----->" };
            var arrowCounter =
                new Dictionary<string, int> { { arrows[0], 0 }, { arrows[1], 0 }, { arrows[2], 0 } };

            foreach (var line in inputLines)
            {
                string currentLine = line;
                foreach (var arrow in arrows)
                {
                    while (ReplaceFirst(ref currentLine, arrow, "I\'ll Never Gonna Let You Go"))
                    {
                        arrowCounter[arrow]++;
                    }
                }
            }

            var number = arrowCounter[arrows[0]] + (arrowCounter[arrows[1]] * 10) + (arrowCounter[arrows[2]] * 100);
            //Console.WriteLine(number);
            var binary = Convert.ToString(number, 2);
            binary = binary + string.Join("", binary.Reverse());
            Console.WriteLine(Convert.ToInt32(binary, 2));
        }

        private static bool ReplaceFirst(ref string text, string search, string replace)
        {
            int index = text.IndexOf(search, StringComparison.Ordinal);

            if (index < 0)
            {
                return false;
            }

            text = $"{text.Substring(0, index)}{replace}{text.Substring(index + search.Length)}";
            return true;
        }
    }
}
