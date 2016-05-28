using System;
using System.Collections.Generic;
using System.Linq;

namespace SequenceOfKNumbers
{
    class ExamProblemTwo
    {
        static void Main(string[] args)
        {
            List<string> sNumbers = Console.ReadLine().Split(' ').ToList();
            int repetitionsToRemove = int.Parse(Console.ReadLine());

            int index = 0;
            int repetitions = 1;

            while (index < sNumbers.Count - 1)
            {
                if (sNumbers[index] == sNumbers[index + 1])
                {
                    repetitions++;

                    if (repetitions == repetitionsToRemove)
                    {
                        sNumbers.RemoveRange((index - repetitionsToRemove) + 2, repetitionsToRemove);

                        repetitions = 1;
                        index -= repetitionsToRemove - 1;
                    }
                }
                else
                {
                    repetitions = 1;
                }

                index++;
            }

            if (repetitionsToRemove > 1)
            {
                Console.WriteLine(string.Join(" ", sNumbers));
            }
            else
            {
                Console.WriteLine();
            }
            
        }
    }
}
