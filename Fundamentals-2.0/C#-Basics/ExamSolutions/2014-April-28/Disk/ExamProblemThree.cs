using System;

namespace Disk
{
    class ExamProblemThree
    {
        static void Main(string[] args)
        {
            int field = int.Parse(Console.ReadLine());
            int radius = int.Parse(Console.ReadLine());

            for (int row = 0 - (field / 2); row <= 0 + (field / 2); row++)
            {
                for (int col = 0 - (field / 2); col <= 0 + (field / 2); col++)
                {
                    // http://www.mathopenref.com/coordbasiccircle.html
                    if ((row * row) + (col * col) <= (radius * radius))
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write('.');
                    }                    
                }
                Console.WriteLine();
            }
        }
    }
}
