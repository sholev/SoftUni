using System;

namespace InsideTheBuilding
{
    class FirstExamProblem
    {
        static void Main(string[] args)
        {
            int building = int.Parse(Console.ReadLine());
            int numberOfVerts = 5;

            int[] x = new int[5];
            int[] y = new int[5];

            for (int i = 0; i < numberOfVerts; i++)
            {
                x[i] = int.Parse(Console.ReadLine());
                y[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < numberOfVerts; i++)
            {
                if ((x[i] <= 3 * building && y[i] <= building && x[i] >= 0 && y[i] >= 0) ||
                    ((x[i] <= 2 * building && x[i] >= building) && y[i] <= 4 * building) && x[i] >= 0 && y[i] >= 0)
                {
                    Console.WriteLine("inside");
                }
                else
                {
                    Console.WriteLine("outside");
                }
            }
        }
    }
}
