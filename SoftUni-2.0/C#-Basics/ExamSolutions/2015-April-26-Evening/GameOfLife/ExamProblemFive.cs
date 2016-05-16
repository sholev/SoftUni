using System;

namespace GameOfLife
{
    class ExamProblemFive
    {
        static void Main(string[] args)
        {
            int[,] initialBoard = {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

            int[,] nextGenerationBoard = {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

            int pairs = int.Parse(Console.ReadLine());
            int X = 0;
            int Y = 0;
            int neighbours = 0;

            for (int i = 0; i < pairs; i++)
            {
                X = int.Parse(Console.ReadLine());
                Y = int.Parse(Console.ReadLine());

                initialBoard[X, Y] = 1;
                nextGenerationBoard[X, Y] = 1;
            }

            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    neighbours = GetNeighbours(initialBoard, row, col);

                    if (nextGenerationBoard[row, col] == 1)
                    {
                        if (neighbours < 2 || neighbours > 3)
                        {
                            nextGenerationBoard[row, col] = 0;
                        }
                    }
                    else
                    {
                        if (neighbours == 3)
                        {
                            nextGenerationBoard[row, col] = 1;
                        }
                    }
                }
            }
            for (int row = 0; row < 10; row++)
            {
                for (int col = 9; col >= 0; col--)
                {
                    Console.Write(nextGenerationBoard[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static int GetNeighbours(int[,] board, int X, int Y)
        {
            int neighbours = 0;

            if (board[X, Y] == 1)
            {
                neighbours--;
            }

            int maxRow = board.GetLength(0) - 1;
            int maxCol = board.GetLength(1) - 1;

            for (int row = Math.Max(X - 1, 0); row <= Math.Min(X + 1, maxRow); row++)
            {
                for (int col = Math.Max(Y - 1, 0); col <= Math.Min(Y + 1, maxCol); col++)
                {
                    neighbours += board[row, col];
                }
            }

            return neighbours;
        }
    }
}
