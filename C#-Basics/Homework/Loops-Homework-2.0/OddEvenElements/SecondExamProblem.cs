using System;
using System.Collections.Generic;
using System.Linq;

namespace OddEvenElements
{
    class SecondExamProblem
    {
        static void Main(string[] args)
        {
            string sInput = Console.ReadLine();
            decimal[] fInput = new decimal[sInput.Length];

            if (sInput != string.Empty)
            {
                fInput = sInput.Split(' ').Select(decimal.Parse).ToArray();
            }

            List<decimal> odd = new List<decimal>();
            List<decimal> even = new List<decimal>();

            for (int i = 0; i < fInput.Length; i++)
            {
                if (i % 2 == 0)
                {
                    odd.Add(fInput[i]);
                }
                else
                {
                    even.Add(fInput[i]);
                }
            }

            if (odd.Any() && even.Any() && sInput.Length > 0) 
            {
                Console.WriteLine("OddSum={0}, OddMin={1}, OddMax={2}, EvenSum={3}, EvenMin={4}, EvenMax={5}",
                (double)odd.Sum(), (double)odd.Min(), (double)odd.Max(),      // I couldn't figure out I need a cast without looking
                (double)even.Sum(), (double)even.Min(), (double)even.Max());  // at the author's solution... Score: SoftUni 1, Me 0 :D
            }
            else
            {
                if (!even.Any() && sInput.Length > 0)
                {
                    Console.WriteLine("OddSum={0}, OddMin={1}, OddMax={2}, EvenSum={3}, EvenMin={4}, EvenMax={5}",
                (double)odd.Sum(), (double)odd.Min(), (double)odd.Max(),
                "No", "No", "No");
                }
                else
                {
                    Console.WriteLine("OddSum={0}, OddMin={1}, OddMax={2}, EvenSum={3}, EvenMin={4}, EvenMax={5}",
                "No", "No", "No",
                "No", "No", "No");
                }
            }
        }
    }
}
