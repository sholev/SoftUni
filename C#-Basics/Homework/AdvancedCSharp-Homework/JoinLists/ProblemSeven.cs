using System;
using System.Collections.Generic;
using System.Linq;

namespace JoinLists
{
    class ProblemSeven
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter anything but int to exit.\r\n");

            while (true)
            {
                int pad = 18;
                List<int> inputNumbers = new List<int>();
                List<int> addThose = new List<int>();

                try
                {
                    Console.Write("Enter numbers: ".PadLeft(pad));
                    inputNumbers = Array.ConvertAll(Console.ReadLine().Split(' '), i => int.Parse(i)).ToList();
                    
                    Console.Write("numbers to add: ".PadLeft(pad));
                    addThose = Array.ConvertAll(Console.ReadLine().Split(' '), i => int.Parse(i)).ToList();
                }
                catch (Exception)
                {
                    return;
                }

                List<int> outputSorted = inputNumbers.Union(addThose).ToList();
                outputSorted.Sort();

                Console.Write("Result: ".PadLeft(pad));
                Console.WriteLine(string.Join(" ", outputSorted.ToArray()));
                Console.WriteLine(new string('-', pad));
            }
        }
    }
}
