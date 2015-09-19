using System;
using System.Collections.Generic;
using System.Linq;

namespace CrossingSequences
{
    class ExamProblemFour
    {
        static void Main(string[] args)
        {
            List<int> tribSequence = new List<int>();
            List<int> numberSpiral = new List<int>();
            List<int> tempSpiral = new List<int>();

            tribSequence.Add(int.Parse(Console.ReadLine()));
            tribSequence.Add(int.Parse(Console.ReadLine()));
            tribSequence.Add(int.Parse(Console.ReadLine()));

            numberSpiral.Add(int.Parse(Console.ReadLine()));
            int spiralStep = int.Parse(Console.ReadLine());

            int count = 0;

            while (tribSequence.Last() <= 1000000)
            {
                count = tribSequence.Count();
                tribSequence.Add(tribSequence[count - 1] + tribSequence[count - 2] + tribSequence[count - 3]);
            }
            
            count = 1;

            while (numberSpiral.Last() <= 1000000)
            {
                numberSpiral.Add(numberSpiral.Last() + (spiralStep * count));
                numberSpiral.Add(numberSpiral.Last() + (spiralStep * count));
                count++;
            }
            
            for (int i = 0; i < tribSequence.Count; i++)
            {
                if (numberSpiral.Contains(tribSequence[i]) && tribSequence[i] <= 1000000)
                {
                    Console.WriteLine(tribSequence[i]);
                    return;
                }
            }

            Console.WriteLine("No");
        }
    }
}
