namespace ProblemsWithMatrices
{
    using System;

    class RubiksMatrix
    {
        static void Main(string[] args)
        {
            string[] dimensions = Console.ReadLine().Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int rows = int.Parse(dimensions[0]);
            int cols = int.Parse(dimensions[1]);
            int inputLines = int.Parse(Console.ReadLine());
            int[][] matrix = new int[rows][];
            FillMatrix(matrix, cols);
            //printMatrix(matrix);
            for (int i = 0; i < inputLines; i++)
            {
                string[] cmdParams = Console.ReadLine()
                    .Trim()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int position = int.Parse(cmdParams[0]);
                string moveDirection = cmdParams[1];
                int numberOfMoves = int.Parse(cmdParams[2]);
                switch (moveDirection)
                {
                    case "up":
                        for (int move = 0; move < numberOfMoves % rows; move++)
                        {
                            int temp = matrix[0][position];
                            for (int row = 0; row < rows - 1; row++)
                            {
                                matrix[row][position] = matrix[row + 1][position];
                            }
                            matrix[rows - 1][position] = temp;
                        }
                        break;
                    case "down":
                        for (int move = 0; move < numberOfMoves % rows; move++)
                        {
                            int temp = matrix[rows - 1][position];
                            for (int row = rows - 1; row > 0; row--)
                            {
                                matrix[row][position] = matrix[row - 1][position];
                            }
                            matrix[0][position] = temp;
                        }
                        break;
                    case "left":
                        for (int move = 0; move < numberOfMoves % cols; move++)
                        {
                            int temp = matrix[position][0];
                            for (int col = 0; col < cols - 1; col++)
                            {
                                matrix[position][col] = matrix[position][col + 1];
                            }
                            matrix[position][cols - 1] = temp;
                        }
                        break;
                    case "right":
                        for (int move = 0; move < numberOfMoves % cols; move++)
                        {
                            int temp = matrix[position][cols - 1];
                            for (int col = cols - 1; col > 0; col--)
                            {
                                matrix[position][col] = matrix[position][col - 1];
                            }
                            matrix[position][0] = temp;
                        }
                        break;
                }
            }
            //printMatrix(matrix);

            int counter = 1;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row][col] != counter)
                    {
                        FindAndSwap(matrix, row, col, counter);
                        //printMatrix(matrix);
                    }
                    else
                    {
                        Console.WriteLine("No swap required");
                    }
                    counter++;
                }
            }
        }

        private static void FindAndSwap(int[][] matrix, int row, int col, int matchingElement)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == matchingElement)
                    {
                        int temp = matrix[row][col];
                        matrix[row][col] = matrix[i][j];
                        matrix[i][j] = temp;
                        Console.WriteLine($"Swap ({row}, {col}) with ({i}, {j})");
                        return;
                    }
                }
            }
        }

        private static void FillMatrix(int[][] matrix, int cols)
        {
            int counter = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new int[cols];
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = ++counter;
                }
            }
        }

        //private static void PrintMatrix(int[][] matrix)
        //{
        //    for (int i = 0; i < matrix.Length; i++)
        //    {
        //        for (int j = 0; j < matrix[i].Length; j++)
        //        {
        //            Console.Write(matrix[i][j]);
        //        }
        //        Console.WriteLine();
        //    }
        //}
    }

}
