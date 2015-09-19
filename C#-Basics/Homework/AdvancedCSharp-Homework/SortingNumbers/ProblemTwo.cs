using System;

namespace SortingNumbers
{
    class ProblemTwo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter anything but int to exit.");

            while (true)
            {
                Console.Write("How many numbers to sort: ".PadLeft(26));
                int arraySize = 0;
                int[] array = { 0 };

                try
                {
                    arraySize = int.Parse(Console.ReadLine());
                    array = new int[arraySize];

                    Console.WriteLine("Enter array content: ".PadLeft(26));
                    for (int i = 0; i < array.Length; i++)
                    {
                        Console.Write(new string(' ', 26));
                        array[i] = int.Parse(Console.ReadLine());
                    }
                }
                catch (Exception)
                {
                    return;
                }

                Array.Sort(array);

                Console.WriteLine("Sorted array: ".PadLeft(26));
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write(new string(' ', 26));
                    Console.WriteLine(array[i]);
                }

                Console.WriteLine(new string('-', 10).PadLeft(26));
            }
            
        }
    }
}
