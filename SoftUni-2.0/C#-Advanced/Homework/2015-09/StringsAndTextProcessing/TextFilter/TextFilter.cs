using System;
using System.Text;

class TextFilter
{
    static void Main()
    {
        string[] filterWords = Console.ReadLine().Split(" ,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        StringBuilder inputText = new StringBuilder();
        inputText.Append(Console.ReadLine());

        foreach (string word in filterWords)
        {
            inputText.Replace(word, new string('*', word.Length));
        }

        Console.WriteLine(inputText.ToString());
    }
}