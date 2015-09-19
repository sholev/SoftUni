using System;

namespace Sunlight
{
    class ExamProblemThree
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char sun = '*';
            char empty = '.';

            for (int i = 0; i <= 3 * size; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("{0}{1}{2}",
                        new string(empty, (3 * size) / 2),
                        sun,
                        new string(empty, (3 * size) / 2));
                }
                else if (i < size)
                {
                    Console.WriteLine("{0}{1}{2}{3}{4}{5}{6}",
                        new string(empty, i),
                        sun, 
                        new string(empty, (3 * size) / 2 - i - 1),
                        sun,
                        new string(empty, (3 * size) / 2 - i - 1),
                        sun,
                        new string(empty, i));
                }
                else if (i > size && i < (3 * size) / 2)
                {
                    Console.WriteLine("{0}{1}{2}",
                        new string(empty, size),
                        new string(sun, size),
                        new string(empty, size));
                }
                else if (i == (3 * size) / 2)
                {
                    Console.WriteLine("{0}",
                        new string(sun, 3 * size));
                }
                else if (i < 2 * size)
                {
                    Console.WriteLine("{0}{1}{2}",
                        new string(empty, size),
                        new string(sun, size),
                        new string(empty, size));
                }
                else if (i > 2 * size && i < 3 * size)
                {
                    // A lot more complicated than it needs to be 
                    // if we introduce another index.
                    Console.WriteLine("{0}{1}{2}{3}{4}{5}{6}",
                        new string(empty, (3 * size) - i),
                        sun,
                        new string(empty, ((3 * size) / 2) - ((3 * size) - i + 1)),
                        sun,
                        new string(empty, ((3 * size) / 2) - ((3 * size) - i + 1)),
                        sun,
                        new string(empty, (3 * size) - i));
                }
                else if (i == 3 * size)
                {
                    Console.WriteLine("{0}{1}{2}",
                        new string(empty, (3 * size) / 2),
                        sun,
                        new string(empty, (3 * size) / 2));
                }
            }
        }
    }
}
