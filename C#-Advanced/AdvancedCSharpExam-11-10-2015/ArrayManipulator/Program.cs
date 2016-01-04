using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputArray = Console.ReadLine()
                .Split(" ,". ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            string inputCommand = string.Empty;

            while ((inputCommand = Console.ReadLine()) != "end")
            {
                string[] commands = inputCommand.Split();

                switch (commands[0])
                {
                    case "exchange":
                       
                        inputArray = exchangeAtIndex(inputArray, commands[1]);
                        //printArray(inputArray);
                        break;

                    case "max":
                        if (commands[1] == "even")
                        {
                            printMaxEven(inputArray);
                        }
                        else if (commands[1] == "odd")
                        {
                            printMaxOdd(inputArray);
                        }
                        break;

                    case "min":
                        if (commands[1] == "even")
                        {
                            pringMinEven(inputArray);
                        }
                        else if (commands[1] == "odd")
                        {
                            printMinOdd(inputArray);
                        }
                        break;

                    case "first":
                        if (int.Parse(commands[1]) > inputArray.Count)
                        {
                            Console.WriteLine("Invalid count");
                            break;
                        }
                        if (commands[2] == "even")
                        {
                            firstEvenUntillIndex(inputArray, commands[1]);
                        }
                        else if (commands[2] == "odd")
                        {
                            firstOddUntillIndex(inputArray, commands[1]);
                        }
                        break;

                    case "last":
                        if (int.Parse(commands[1]) > inputArray.Count)
                        {
                            Console.WriteLine("Invalid count");
                            break;
                        }
                        if (commands[2] == "even")
                        {
                            lastEvenHalfUntillIndex(inputArray, commands[1]);
                        }
                        else if (commands[2] == "odd")
                        {
                            lastOddUntillIndex(inputArray, commands[1]);
                        }
                        break;
                    default:
                        break;
                }                
            }
            printArray(inputArray);
        }

        private static void lastOddUntillIndex(List<int> inputArray, string strIndex)
        {
            List<int> output = new List<int>();

            output = inputArray.Where(item => item % 2 != 0).ToList();

            int index = Math.Min(output.Count - 1, int.Parse(strIndex));

            printArray(output.Skip(index).ToList());
        }

        private static void lastEvenHalfUntillIndex(List<int> inputArray, string strIndex)
        {
            List<int> output = new List<int>();

            output = inputArray.Where(item => item % 2 == 0).ToList();

            int index = Math.Min(output.Count, int.Parse(strIndex));

            printArray(output.Skip(index).ToList());
        }

        private static void firstOddUntillIndex(List<int> inputArray, string strIndex)
        {
            List<int> output = new List<int>();

            output = inputArray.Where(item => item % 2 != 0).ToList();

            int index = Math.Min(output.Count, int.Parse(strIndex));

            printArray(output.Take(index).ToList());
        }

        private static void firstEvenUntillIndex(List<int> inputArray, string strIndex)
        {
            List<int> output = new List<int>();

            output = inputArray.Where(item => item % 2 == 0).ToList();

            int index = Math.Min(output.Count, int.Parse(strIndex));

            printArray(output.Take(index).ToList());
        }

        private static void printMinOdd(List<int> inputArray)
        {
            int minEven = -1;
            minEven = inputArray.Where(item => item % 2 != 0).Min();
            if (minEven != -1)
            {
                Console.WriteLine(inputArray.LastIndexOf(minEven));
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        private static void pringMinEven(List<int> inputArray)
        {
            try
            {
                int minOdd = -1;
                minOdd = inputArray.Where(item => item % 2 == 0).Min();
                if (minOdd != -1)
                {
                    Console.WriteLine(inputArray.LastIndexOf(minOdd));
                }
                else
                {
                    Console.WriteLine("No matches");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("No matches");
            }
        }

        private static void printMaxOdd(List<int> inputArray)
        {
            int maxOdd = -1;
            maxOdd = inputArray.Where(item => item % 2 != 0).Max();
            if (maxOdd != -1)
            {
                Console.WriteLine(inputArray.LastIndexOf(maxOdd));
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        private static void printMaxEven(List<int> inputArray)
        {
            int maxEven = -1;
            maxEven = inputArray.Where( item => item % 2 == 0).Max();
            if (maxEven != -1)
            {
                Console.WriteLine(inputArray.LastIndexOf(maxEven));
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        private static List<int> exchangeAtIndex(List<int> inputArray, string strIndex)
        {
            List<int> output = new List<int>();
            if (int.Parse(strIndex) >= inputArray.Count)
            {
                Console.WriteLine("Invalid index");
                return inputArray;
            }
            try
            {
                int index = int.Parse(strIndex);
                output.AddRange(inputArray.Skip(index + 1).ToList());
                output.AddRange(inputArray.Take(index + 1).ToList());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid index");
                return inputArray;
            }

            return output;
        }

        private static void printArray(List<int> inputArray)
        {
            Console.WriteLine("[" + string.Join(", ", inputArray) + "]");
        }
    }
}
