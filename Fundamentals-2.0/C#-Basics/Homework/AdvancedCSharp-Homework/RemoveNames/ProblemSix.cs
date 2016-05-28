using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoveNames
{
    class ProblemSix
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter \"exit\" to exit.");

            while (true)
            {
                int pad = 18;
                List<string> inputNames = new List<string>();
                string[] removeThose = new string[0];

                Console.Write("Enter names: ".PadLeft(pad));
                inputNames = Console.ReadLine().Split(' ').ToList();

                if (inputNames[0].ToLower() == "exit")
                {
                    return;
                }

                Console.Write("Names to remove: ".PadLeft(pad));
                removeThose = Console.ReadLine().Split(' ');

                if (removeThose[0].ToLower() == "exit")
                {
                    return;
                }

                for (int i = 0; i < removeThose.Length; i++)
                {
                    inputNames.RemoveAll(x => x == removeThose[i]);
                }

                Console.Write("Result: ".PadLeft(pad));
                Console.WriteLine(string.Join(" ", inputNames.ToArray()));
                Console.WriteLine(new string('-', pad));
            }            
        }
    }
}
