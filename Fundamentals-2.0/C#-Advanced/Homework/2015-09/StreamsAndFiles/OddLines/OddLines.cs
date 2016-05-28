using System;
using System.IO;
using System.Collections.Generic;

class OddLines
{
    static void Main()
    {
        string inputFilePath = @"..\..\OddLines.txt";

        StreamReader readFile = new StreamReader(inputFilePath);
        List<string> oddLines = new List<string>();
        string line = string.Empty;
        bool lineIsOdd = false;

        using (readFile)
        {
            Console.WriteLine("File content:");
            while ((line = readFile.ReadLine()) != null)
            {
                Console.WriteLine(line);
                if (lineIsOdd)
                {
                    oddLines.Add(line);
                }
                lineIsOdd = !lineIsOdd;
            }
        }

        Console.WriteLine("Odd lines:");
        Console.WriteLine(string.Join("\r\n", oddLines));
    }
}