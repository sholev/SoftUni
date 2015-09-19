using System;

namespace Arrow
{
    class ThirdExamProblem
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            char arrow = '#';
            char empty = '.';

            for (int i = 1; i < input * 2; i++)
            {
                if (i == 1) // First row.
                {

                    Console.WriteLine("{0}{1}{2}{3}{4}",
                        new string(empty, (input - 1) / 2),
                        arrow,
                        new string(arrow, input - 2),
                        arrow,
                        new string(empty, (input - 1) / 2));
                }
                else if (i < input) // Between first to mid rows.
                {
                    Console.WriteLine("{0}{1}{2}{3}{4}",
                        new string(empty, (input - 1) / 2),
                        arrow,
                        new string(empty, input - 2),
                        arrow,
                        new string(empty, (input - 1) / 2));
                }
                else if (i == input) // Mid row.
                {

                    Console.WriteLine("{0}{1}{2}{3}{4}",
                        new string(arrow, (input - 1) / 2),
                        arrow,
                        new string(empty, input - 2),
                        arrow,
                        new string(arrow, (input - 1) / 2));
                }
                else if (i > input && i != (input * 2) - 1) // Between mid to last row.
                {
                    Console.WriteLine("{0}{1}{2}{3}{4}",
                    new string(empty, i - input),
                    arrow,
                    new string(empty, (input * 2) - ((i - input) * 2) - 3),
                    arrow,
                    new string(empty, i - input));

                }
                else // Last row.
                {
                    Console.WriteLine("{0}{1}{2}",
                        new string(empty, input - 1),
                        arrow,
                        new string(empty, input - 1));
                }
            }
        }
    }
}
