using System;
using System.Collections.Generic;
using System.Linq;

class StringMatrixRotation
{
    static void Main()
    {
        string rotateCommand = Console.ReadLine();
        // No need for more than 4 rotations, because we are starting from the initial position again.
        // http://stackoverflow.com/questions/378415/how-do-i-extract-text-that-lies-between-parentheses-round-brackets
        int numberOfRotation = (int.Parse(rotateCommand.Split('(', ')')[1]) / 90) % 4;

        List<string> inputLines = new List<string>();

        string input = Console.ReadLine();

        while (input != "END")
        {
            inputLines.Add(input);

            input = Console.ReadLine();
        }

        // http://stackoverflow.com/questions/7975935/is-there-a-linq-function-for-getting-the-longest-string-in-a-list-of-strings - Aggregate magic.
        char[,] originalMatrix = new char[inputLines.Count, inputLines.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur).Length];

        char[,] rotatedMatrix;
        // If the rotation is even, we keep the rotated matrix dimensions the same.
        if (numberOfRotation % 2 == 0)
        {
            rotatedMatrix = new char[inputLines.Count, inputLines.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur).Length];
        }
        // If the rotation is odd, we swap the dimensions of the rotated matrix.
        else
        {
            rotatedMatrix = new char[inputLines.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur).Length, inputLines.Count];
        }        

        for (int row = 0; row < originalMatrix.GetLength(0); row++)
        {
            for (int col = 0; col < originalMatrix.GetLength(1); col++)
            {
                // Fill the matrix with empty space.
                originalMatrix[row, col] = ' ';

                // If there is a coresponding character in the inputLines, fill it in.
                try
                {
                    originalMatrix[row, col] = inputLines[row][col];
                }
                catch (Exception) {} // Not breaking out, because we're filling it with empty spaces.
            }
        }

        rotateMatrix(originalMatrix, numberOfRotation, ref rotatedMatrix);

        for (int row = 0; row < rotatedMatrix.GetLength(0); row++)
        {
            for (int col = 0; col < rotatedMatrix.GetLength(1); col++)
            {
                Console.Write(rotatedMatrix[row, col]);
            }

            Console.WriteLine();
        }
    }

    private static void rotateMatrix(char[,] originalMatrix, int numberOfRotation, ref char[,] rotatedMatrix)
    {
        switch (numberOfRotation)
        {
            case 1: // Rotate once right.
                for (int row = 0; row < rotatedMatrix.GetLength(0); row++)
                {
                    for (int col = 0; col < rotatedMatrix.GetLength(1); col++)
                    {
                        rotatedMatrix[row, col] = originalMatrix[rotatedMatrix.GetLength(1) - col - 1, row];
                    }
                }
                break;

            case 2: // Reverse both left to right and down to up, for two rotations or upside-down.
                for (int row = 0; row < rotatedMatrix.GetLength(0); row++)
                {
                    for (int col = 0; col < rotatedMatrix.GetLength(1); col++)
                    {
                        rotatedMatrix[row, col] = originalMatrix[rotatedMatrix.GetLength(0) - row - 1, rotatedMatrix.GetLength(1) - col - 1];
                    }
                }
                break;

            case 3: // Rotate left => three rotations right.
                for (int row = 0; row < rotatedMatrix.GetLength(0); row++)
                {
                    for (int col = 0; col < rotatedMatrix.GetLength(1); col++)
                    {
                        rotatedMatrix[row, col] = originalMatrix[col, rotatedMatrix.GetLength(0) - row - 1];
                    }
                }
                break;

            default: // Keep the original position. Might just print the original matrix in such case, maybe next time. :D
                for (int row = 0; row < rotatedMatrix.GetLength(0); row++)
                {
                    for (int col = 0; col < rotatedMatrix.GetLength(1); col++)
                    {
                        rotatedMatrix[row, col] = originalMatrix[row, col];
                    }
                }
                break;
        }        
    }
}
