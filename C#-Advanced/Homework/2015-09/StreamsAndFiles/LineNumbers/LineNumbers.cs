using System.IO;
using System.Collections.Generic;

class LineNumbers
{
    static void Main()
    {
        string inputFilePath = @"..\..\LoremIpsum.txt";
        string outputFilePath = @"..\..\LoremIpsumLineNumbers.txt";
        List<string> inputLines = new List<string>();
        string line = string.Empty;

        StreamReader readFile = new StreamReader(inputFilePath);

        using (readFile)
        {
            while ((line = readFile.ReadLine()) != null)
            {
                inputLines.Add(line);
            }
        }

        StreamWriter writeFile = new StreamWriter(outputFilePath);

        using (writeFile)
        {
            for (int i = 0; i < inputLines.Count; i++)
            {
                writeFile.WriteLine("{0} - {1}", i, inputLines[i]);
            }
        }
    }
}
