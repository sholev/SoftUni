using System;
using System.IO; // StreamReader
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class UseYourChainsBuddy
{
    static void Main()
    {
        // Increase the Console.ReadLine(); character limit.
        // http://stackoverflow.com/questions/6081946/why-does-console-readline-have-a-limit-on-the-length-of-text-it-allows/6081967#6081967
        Console.SetIn(new StreamReader(Console.OpenStandardInput(16384)));

        string input = Console.ReadLine();
        string matchPattern = @"(?:<p>)(.*?)(?:<\/p>)";

        // Convert each match group string to char array and add it to a list.
        List<char[]> matches = Regex.Matches(input, matchPattern).Cast<Match>().Select(m => m.Groups[1].Value.ToCharArray()).ToList();
        List<string> output = new List<string>();

        foreach (char[] charArray in matches)
        {
            output.Add(decryptMessage(charArray));
        }

        Console.WriteLine(string.Join("", output));
    }

    private static string decryptMessage(char[] charArray)
    {
        StringBuilder result = new StringBuilder();

        foreach (char symbol in charArray)
        {
            result.Append(convertChar(symbol));
        }
        // Replace multiple whitespaces with single one.
        return Regex.Replace(result.ToString(), @"\s+", " ");
    }

    private static char convertChar(char symbol)
    {
        char result = new char();

        if (symbol >= 'a' && symbol <= 'm')
        {
            result = (char)(symbol + 13);
        }
        else if (symbol >= 'n' && symbol <= 'z')
        {
            result = (char)(symbol - 13);
        }
        else if (symbol >= '0' && symbol <= '9')
        {
            result = symbol;
        }
        else
        {
            result = ' ';
        }

        return result;
    }
}