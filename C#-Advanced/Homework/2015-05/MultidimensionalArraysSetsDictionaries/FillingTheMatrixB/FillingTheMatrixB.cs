using System;
using System.Threading;

class FillingTheMatrixB
{
    static void Main()
    {
        int[,] theRabbitHole = new int[8, 8];
        int fillCounter = 0;
        int col = 0;
        bool moveUp = false;
        bool dontMoveToNextCol = true;

        for (int row = 0; row < theRabbitHole.GetLength(0); row++)
        {
            dontMoveToNextCol = true;

            while (dontMoveToNextCol)
            {
                theRabbitHole[col, row] = ++fillCounter;

                Console.Clear();
                PrintMatrix(theRabbitHole);

                Thread.Sleep(100);

                if (moveUp && col > 0)
                {
                    col--;
                }
                else if (!moveUp && col < theRabbitHole.GetLength(1) - 1)
                {
                    col++;
                }
                else
                {
                    // Change direction and move to the next colon.
                    moveUp = !moveUp;
                    dontMoveToNextCol = !dontMoveToNextCol;
                }
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
