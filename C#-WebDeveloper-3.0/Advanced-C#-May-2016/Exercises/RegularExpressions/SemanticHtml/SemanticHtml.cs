namespace RegularExpressions
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class SemanticHtml
    {
        static void Main(string[] args)
        {
            var inputLines = new List<string>();

            var matchOpening = @"(?:<div\s*)(.*)(?:id|class)\s*=\s*""([^\s]+)""(.*?)>";
            var replaceOpening = @"<$2 $1 $3>";
            var matchClosing = @"<\/div>\s*?<!--\s*?(\w{3,7})\s*?-->";
            var replaceClosing = @"</$1>";

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                inputLines.Add(input);
            }

            var output = new List<string>();

            foreach (string line in inputLines)
            {
                string temp;

                if (line.Contains("<div"))
                {
                    temp = Regex.Replace(line, matchOpening, replaceOpening);
                    // Replace all the multiple spaces, which are not in the begining of the line with single space.
                    temp = Regex.Replace(temp, @"(?<=\S)[^\S\n]+", " ");
                    // Get rid of space before >
                    temp = Regex.Replace(temp, @"\s+>", ">");
                    output.Add(temp);
                }
                else if (line.Contains("</div"))
                {
                    temp = Regex.Replace(line, matchClosing, replaceClosing);
                    temp = Regex.Replace(temp, @"(?<=\S)[^\S\n]+", " ");
                    temp = Regex.Replace(temp, @"\s+>", ">");
                    output.Add(temp);
                }
                else
                {
                    output.Add(line);
                }
            }

            Console.WriteLine(string.Join("\r\n", output));
        }
    }
}
