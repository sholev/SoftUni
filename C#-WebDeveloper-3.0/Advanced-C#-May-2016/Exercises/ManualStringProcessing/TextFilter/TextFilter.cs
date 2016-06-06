namespace ManualStringProcessing
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    class TextFilter
    {
        static void Main(string[] args)
        {
            string[] filterWords = Regex.Split(Console.ReadLine(), @"[\s\,]+");
            StringBuilder inputText = new StringBuilder();
            inputText.Append(Console.ReadLine());

            foreach (string word in filterWords)
            {
                inputText.Replace(word, new string('*', word.Length));
            }

            Console.WriteLine(inputText.ToString());
        }
    }
}
