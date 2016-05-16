using System;
using System.Collections.Generic;

namespace StudentCables
{
    class ExamProblemTwo
    {
        static void Main(string[] args)
        {
            int numberOfCables = int.Parse(Console.ReadLine());

            List<int> cables = new List<int>();

            for (int i = 0; i < numberOfCables; i++)
            {
                cables.Add(int.Parse(Console.ReadLine()));

                if (Console.ReadLine() == "meters")
                {
                    cables[i] *= 100;
                }
                else if (cables[i] < 20)
                {
                    cables.RemoveAt(i);
                    numberOfCables--;
                    i--;
                }
            }

            int totalCableLenth = 0 - ((cables.Count - 1) * 3);

            foreach (int cable in cables)
            {
                totalCableLenth += cable;
            }

            Console.WriteLine(totalCableLenth / 504);
            Console.WriteLine(totalCableLenth % 504);
        }
    }
}
