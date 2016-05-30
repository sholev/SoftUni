namespace ProblemsWithMatrices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TargetPractice
    {
        static void Main(string[] args)
        {
            var matrixDimensions =
                Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            var snake = Console.ReadLine();

            var shotParameters =
                Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            var stairs = new char[matrixDimensions[0]][];

            FillMatrix(matrixDimensions, snake, stairs);
            FireShot(shotParameters, stairs);
            DropHangingSymbols(stairs);

            for (int row = 0; row < stairs.Length; row++)
            {
                for (int col = 0; col < stairs[row].Length; col++)
                {
                    Console.Write(stairs[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static void DropHangingSymbols(char[][] stairs)
        {
            for (int col = 0; col < stairs[0].Length; col++)
            {
                var column = new List<char>();
                for (int row = stairs.Length - 1; row >= 0; row--)
                {
                    if (stairs[row][col] != ' ')
                    {
                        column.Add(stairs[row][col]);
                    }
                }

                for (int i = 0; i < stairs.Length; i++)
                {
                    stairs[stairs.Length - 1 - i][col] = i >= column.Count ? ' ' : column[i];
                }
            }
        }

        private static void FireShot(int[] shotParameters, char[][] stairs)
        {
            for (int row = 0; row < stairs.Length; row++)
            {
                for (int col = 0; col < stairs[row].Length; col++)
                {
                    if (IsPointInCircle(row, col, shotParameters[0], shotParameters[1], shotParameters[2]))
                    {
                        stairs[row][col] = ' ';
                    }
                }
            }
        }

        private static bool IsPointInCircle(double pointX, double pointY, double circleX, double circleY, double circleR)
        {
            return Math.Pow(pointX - circleX, 2) + Math.Pow(pointY - circleY, 2) <= Math.Pow(circleR, 2);
        }

        private static void FillMatrix(int[] matrixDimensions, string snake, char[][] matrix)
        {
            var snakeIndex = 0;
            var isGoingLeft = true;
            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                matrix[row] = new char[matrixDimensions[1]];

                if (isGoingLeft)
                {
                    for (int col = matrix[row].Length - 1; col >= 0; col--)
                    {
                        matrix[row][col] = snake[snakeIndex % snake.Length];
                        snakeIndex++;
                    }
                    isGoingLeft = !isGoingLeft;
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] = snake[snakeIndex % snake.Length];
                        snakeIndex++;
                    }
                    isGoingLeft = !isGoingLeft;
                }
            }
        }
    }
}
