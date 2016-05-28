using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eclipse
{
    class Eclipse
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char lense = '/';
            char frame = '*';
            char bridge = '-';
            char empty = ' ';

            Console.WriteLine("{0}{1}{2}{3}{4}", // First row - the frame.
                empty,
                new string(frame, rows * 2 - 2),
                new string(empty, rows + 1),
                new string(frame, rows * 2 - 2),
                empty);

            for (int i = 0; i < rows - 2; i++) // "rows - 2" since we are skipping the first row and the last one.
            {
                if (i < (rows - 2) / 2) // Rows before the center where the bridge is.
                {
                    Console.WriteLine("{0}{1}{2}{3}{4}{5}{6}",
                        frame,
                        new string(lense, (2 * rows) - 2),
                        frame,
                        new string(empty, rows - 1),
                        frame,
                        new string(lense, (2 * rows) - 2),
                        frame);
                }
                else if (i == (rows - 2) / 2) // Center row with the bridge.
                {
                    Console.WriteLine("{0}{1}{2}{3}{4}{5}{6}",
                        frame,
                        new string(lense, (2 * rows) - 2),
                        frame,
                        new string(bridge, rows - 1),
                        frame,
                        new string(lense, (2 * rows) - 2),
                        frame);
                }
                else // Rows after the center.
                {
                    Console.WriteLine("{0}{1}{2}{3}{4}{5}{6}",
                        frame,
                        new string(lense, (2 * rows) - 2),
                        frame,
                        new string(empty, rows - 1),
                        frame,
                        new string(lense, (2 * rows) - 2),
                        frame);
                }
            }

            Console.WriteLine("{0}{1}{2}{3}{4}", empty, // Last row - the frame.
                new string(frame, rows * 2 - 2),
                new string(empty, rows + 1),
                new string(frame, rows * 2 - 2),
                empty);
        }
    }
}
