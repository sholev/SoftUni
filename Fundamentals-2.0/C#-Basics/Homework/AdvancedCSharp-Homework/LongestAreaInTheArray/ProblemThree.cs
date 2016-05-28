using System;

namespace LongestAreaInTheArray
{
    class ProblemThree
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of array elements, or anything else to exit.");

            while (true)
            {
                int arrayLenth = 0;

                try
                {
                    Console.Write("Array size: ");
                    arrayLenth = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    return;
                }

                string[] stringArray = new string[arrayLenth];

                for (int i = 0; i < arrayLenth; i++)
                {
                    Console.Write("Element {0}: ", i);
                    stringArray[i] = Console.ReadLine();
                }

                int longestAreaLenth = 1;
                int repeatCounter = 1;
                int position = 0;

                for (int i = 1; i < arrayLenth; i++)
                {
                    if (stringArray[i] == stringArray[i - 1])   // Do we have a match
                    {
                        if (repeatCounter == longestAreaLenth)  // is it the biggest repetition,
                        {
                            position = i - longestAreaLenth;    // if yes, store position.
                        }

                        repeatCounter++;                        // Since we have a match, increase counter.

                        if (longestAreaLenth <= repeatCounter)  // Is it longer/equal to previous repetitions,
                        {
                            longestAreaLenth = repeatCounter;   // if yes, get its lenth.
                        }
                    }
                    else                                        // If we do not have a match
                    {
                        repeatCounter = 1;                      // reset counter.
                    }
                }

                if (longestAreaLenth == 1)                      // If we do not have a match, 
                {                                               // print the leftmost element
                    position = 0;
                }

                Console.WriteLine("Longest sequence is {0}: ", longestAreaLenth);

                for (int i = 0; i < longestAreaLenth; i++)
                {
                    Console.Write("Element {0}: ", i + position);
                    Console.WriteLine(stringArray[i + position]);
                }
                Console.WriteLine(new string('-', 10));
            }
            
        }
    }
}
