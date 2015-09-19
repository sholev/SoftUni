using System;
using System.Threading;

class FillingTheMatrixA
{
    static void Main()
    {
        int[,] theRabbitHole = new int[8, 8];
        int fillCounter = 0;

        for (int row = 0; row < theRabbitHole.GetLength(0); row++)
        {
            for (int col = 0; col < theRabbitHole.GetLength(1); col++)
            {
                theRabbitHole[col, row] = ++fillCounter;

                Console.Clear();
                PrintMatrix(theRabbitHole);

                Thread.Sleep(100);
            }
        }
    }

    private static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write($"{matrix[row, col]}".PadLeft(3, ' '));
            }
            Console.WriteLine();
        }
    }
}
