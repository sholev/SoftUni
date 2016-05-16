using System;

namespace Sunglasses
{
    class ExamProblemThree
    {
        static void Main(string[] args)
        {
            char frames = '*';
            char lenses = '/';
            char bridge = '|';
            char empty = ' ';
            byte rows = (byte.Parse(Console.ReadLine()));

            for (int i = 0; i < rows * 2; i++) // first row 
                Console.Write(frames);
            for (int i = 0; i < rows; i++)
                Console.Write(empty);
            for (int i = 0; i < rows * 2; i++)
                Console.Write(frames);

            Console.Write('\n');

            if (rows > 3) // this might not be needed
            {
                for (int i = 0; i < (rows - 3) / 2; i++) // between first row and mid row
                {
                    Console.Write(frames);
                    for (int l = 0; l < (rows * 2) - 2; l++)
                        Console.Write(lenses);
                    Console.Write(frames);

                    for (int l = 0; l < rows; l++)
                        Console.Write(empty);

                    Console.Write(frames);
                    for (int l = 0; l < (rows * 2) - 2; l++)
                        Console.Write(lenses);
                    Console.Write(frames);

                    Console.Write('\n');
                }
            }

            Console.Write(frames); // mid row
            for (int l = 0; l < (rows * 2) - 2; l++)
                Console.Write(lenses);
            Console.Write(frames);

            for (int l = 0; l < rows; l++)
                Console.Write(bridge);

            Console.Write(frames);
            for (int l = 0; l < (rows * 2) - 2; l++)
                Console.Write(lenses);
            Console.Write(frames);

            Console.Write('\n');

            if (rows > 3) // this might not be needed
            {
                for (int i = 0; i < (rows - 3) / 2; i++) // betwen mid and last row
                {
                    Console.Write(frames);
                    for (int l = 0; l < (rows * 2) - 2; l++)
                        Console.Write(lenses);
                    Console.Write(frames);

                    for (int l = 0; l < rows; l++)
                        Console.Write(empty);

                    Console.Write(frames);
                    for (int l = 0; l < (rows * 2) - 2; l++)
                        Console.Write(lenses);
                    Console.Write(frames);

                    Console.Write('\n');
                }
            }

            for (int i = 0; i < rows * 2; i++) // last row
                Console.Write(frames);
            for (int i = 0; i < rows; i++)
                Console.Write(empty);
            for (int i = 0; i < rows * 2; i++)
                Console.Write(frames);

            Console.Write('\n');
        }
    }
}
