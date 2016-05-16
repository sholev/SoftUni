using System;

namespace Summertime
{
    class ExamProblemThree
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int index = 2;

            char empty = ' ';
            char glass = '*';
            char beerGone = '.';
            char beer = '@';

            for (int i = 0; i <= 3 * input; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("{0}{1}{2}", 
                        new string(empty, input / 2),
                        new string(glass, input + 1),
                        new string(empty, input / 2));
                }
                else if (i < input)
                {
                    if (input / 2 >= i)
                    {
                        Console.WriteLine("{0}{1}{2}{3}{4}",
                        new string(empty, input / 2),
                        glass,
                        new string(empty, input - 1),
                        glass,
                        new string(empty, input / 2));
                    }
                    else if (input / 2 < i)
                    {
                        Console.WriteLine("{0}{1}{2}{3}{4}",
                        new string(empty, input - i),
                        glass,
                        new string(empty, (input - 3) + index),
                        glass,
                        new string(empty, input - i));

                        index += 2;
                    }
                }
                else if (i < 2 * input)
                {
                    Console.WriteLine("{0}{1}{2}",
                        glass,
                        new string(beerGone, 2 * input - 2),
                        glass);
                }
                else if (i < 3 * input)
                {
                    Console.WriteLine("{0}{1}{2}",
                        glass,
                        new string(beer, 2 * input - 2),
                        glass);
                }
                else
                {
                    Console.WriteLine(new string(glass, 2 * input));
                }
            }
        }
    }
}
