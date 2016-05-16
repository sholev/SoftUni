using System;
using System.Text.RegularExpressions;

class ReplaceHtmlUrlTag
{
    static void Main()
    {
        string input = Console.ReadLine();
        // Match <a\s*href=["|'], get the first group $1 untill ["|']>, match $2 untill </a>
        string matchPattern = @"<a\s*href=[""|'](.*?)[""|']>(.*?)<\/a>";
        string replacement = @"[URL=$1]$2[/URL]";
        Console.WriteLine(Regex.Replace(input, matchPattern, replacement));
    }
}
