using System;

namespace SpiralMatrix
{
    class IdontEven
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter anything but int to exit.");

            while (true)
            {
                int input = 0;

                try
                {
                    Console.Write("Enter n: ");
                    input = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                }
                catch (Exception)
                {
                    return;
                }

                int[,] spiral_matrix = new int[input, input];
                if (1 <= input && input <= 20)
                {
                    spiral_matrix = SpinTheMatrix(input);

                    repeatString("|---", input, "|");

                    for (int i = 0; i < input; i++)
                    {
                        for (int l = 0; l < input; l++)
                        {
                            Console.Write("|{0,3}", spiral_matrix[i, l]);
                        }
                        Console.WriteLine("|");

                        repeatString("|---", input, "|");
                    }
                }
                else
                {
                    Console.WriteLine("Bad input, make sure that n(1 <= n <= 20).");
                }
            }
        }

        private static void repeatString(string repeatThis, int numberOfRepeats, string closingPart)
        {
            for (int i = 0; i < numberOfRepeats; i++)
            {
                Console.Write(repeatThis);
            }
            Console.WriteLine(closingPart);
        }

        // I have to admit, I didn't came up with this on
        // my own, even though I had a similar direction.
        // http://dobromirivanov.net/c-csharp-spiral-matrix/

        // I did a bit of optimisation though. I believe
        // it is possible to optimize it even more, but
        // right now I have plenty of other things to do.
        // Like practice more exam problems. :D
        private static int[,] SpinTheMatrix(int input)
        {
            int[,] matrix_2D = new int[input, input];
            int spotsToFill = input * input;
            int verticalPosition = 0;
            int horizontalPosition = 0;
            string direction = "right";

            for (int i = 1; i <= spotsToFill; i++)
            {
                matrix_2D[verticalPosition, horizontalPosition] = i;

                switch (direction)
                {
                    case "right":

                        horizontalPosition++;

                        if (horizontalPosition > input - 1 || matrix_2D[verticalPosition, horizontalPosition] != 0)
                        {
                            direction = "down";
                            horizontalPosition--;
                            verticalPosition++;
                        }

                        break;

                    case "down":

                        verticalPosition++;

                        if (verticalPosition > input - 1 || matrix_2D[verticalPosition, horizontalPosition] != 0)
                        {
                            direction = "left";
                            verticalPosition--;
                            horizontalPosition--;
                        }

                        break;

                    case "left":

                        horizontalPosition--;

                        if (horizontalPosition < 0 || matrix_2D[verticalPosition, horizontalPosition] != 0)
                        {
                            direction = "up";
                            horizontalPosition++;
                            verticalPosition--;
                        }

                        break;

                    case "up":

                        verticalPosition--;

                        if (verticalPosition < 0 || matrix_2D[verticalPosition, horizontalPosition] != 0)
                        {
                            direction = "right";
                            verticalPosition++;
                            horizontalPosition++;
                        }

                        break;

                    default:

                        Console.WriteLine("Getting in here should be imposible. :D");

                        break;
                }
            }

            return matrix_2D;
        }
    }
}
