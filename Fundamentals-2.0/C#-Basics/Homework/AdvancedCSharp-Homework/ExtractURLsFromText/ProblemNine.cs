using System;
using System.Linq;

namespace ExtractURLsFromText
{
    class ProblemNine
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter \"exit\" to exit.\r\n");

            while (true)
            {
                Console.WriteLine();
                Console.Write("Enter text: ");
                string inputText = Console.ReadLine();

                if (inputText.ToLower() == "exit")
                {
                    return;
                }

                // http://stackoverflow.com/questions/10576686/c-sharp-regex-pattern-to-extract-urls-from-given-string-not-full-html-urls-but
                var links = inputText.Split("\t\n ".ToCharArray(),
                      StringSplitOptions.RemoveEmptyEntries).Where(s => s.StartsWith("http://") ||
                                                                        s.StartsWith("www.") ||
                                                                        s.StartsWith("https://"));
                Console.WriteLine();
                Console.WriteLine("URLs:");
                Console.WriteLine();
                foreach (string s in links)
                {
                    Console.WriteLine(s.TrimEnd('.'));
                }
                Console.WriteLine(new string('-', 10));
            }            
        }
    }
}
