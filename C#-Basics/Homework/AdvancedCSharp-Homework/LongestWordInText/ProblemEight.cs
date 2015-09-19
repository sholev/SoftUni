using System;
using System.Linq;

// Doesn't take into account if there is more than one longest word.

namespace LongestWordInText
{
    class ProblemEight
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter \"exit\" to exit.\r\n");
            int pad = 15;

            while (true)
            {
                Console.Write("Enter text: ".PadLeft(pad));
                string inputText = Console.ReadLine();

                if (inputText == "exit")
                {
                    return;
                }

                Console.Write("Longest word: ".PadLeft(pad));
                Console.WriteLine(inputText.Split(' ').ToArray().OrderBy(s => s.Length).LastOrDefault());
                Console.WriteLine(new string('-', pad));
            }
            
        }
    }
}
