using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class SemanticHTML
{
    static void Main()
    {        
        List<string> inputLines = new List<string>();

        string matchOpening = @"(?:<div\s*)(.*)(?:id|class)\s*=\s*""([^\s]+)""(.*?)>";
        string replaceOpening = @"<$2 $1 $3>";
        string matchClosing = @"<\/div>\s*?<!--\s*?(\w{3,7})\s*?-->";
        string replaceClosing = @"</$1>";

        string input = Console.ReadLine();
        while (input != "END")
        {
            inputLines.Add(input);

            input = Console.ReadLine();
        }

        List<string> output = new List<string>();

        for (int i = 0; i < inputLines.Count; i++)
        {
            string temp = string.Empty;

            if (inputLines[i].Contains("<div"))
            {
                temp = Regex.Replace(inputLines[i], matchOpening, replaceOpening);   
                // Replace all the multiple spaces, which are not in the begining of the line with single space.          
                temp = Regex.Replace(temp, @"(?<=\S)[^\S\n]+", " ");
                // Get rid of space before >
                temp = Regex.Replace(temp, @"\s+>", ">");
                output.Add(temp);
            }
            else if (inputLines[i].Contains("</div"))
            {
                temp = Regex.Replace(inputLines[i], matchClosing, replaceClosing);                
                temp = Regex.Replace(temp, @"(?<=\S)[^\S\n]+", " ");
                temp = Regex.Replace(temp, @"\s+>", ">");
                output.Add(temp);
            }
            else
            {
                output.Add(inputLines[i]);
            }
        }

        Console.WriteLine(string.Join("\r\n", output));
    }
}