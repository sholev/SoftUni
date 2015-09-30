using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class WordCount
{
    static void Main()
    {
        string wordsToFindPath = @"..\..\Words.txt";
        string inputFilePath = @"..\..\Text.txt";
        string outputFilePath = @"..\..\Result.txt";

        List<string> inputWords = new List<string>();
        List<string> inputWordsToFind = new List<string>();
        Dictionary<string, int> wordsCount = new Dictionary<string, int>();
        string line = string.Empty;

        StreamReader readText = new StreamReader(inputFilePath);

        using (readText)
        {
            while ((line = readText.ReadLine()) != null)
            {
                inputWords.AddRange(Regex.Split(line, @"[\s-!.…,?_]+"));
            }
        }

        StreamReader readWords = new StreamReader(wordsToFindPath);

        using (readWords)
        {
            while ((line = readWords.ReadLine()) != null)
            {
                inputWordsToFind.Add(line);
            }
        }

        foreach (string find in inputWordsToFind)
        {
            int count = 0;

            foreach (string word in inputWords)
            {
                if (find.ToLower().Equals(word.ToLower()))
                {
                    count++;
                }
            }

            wordsCount.Add(find, count);
        }

        StreamWriter writeMatches = new StreamWriter(outputFilePath);

        using (writeMatches)
        {
            foreach (var word in wordsCount.OrderByDescending(key => key.Value))
            {
                writeMatches.WriteLine("{0} - {1}", word.Key, word.Value);
            }
        }
    }
}