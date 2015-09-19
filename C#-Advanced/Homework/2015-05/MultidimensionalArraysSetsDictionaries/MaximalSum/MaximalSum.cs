using System;

class MaximalSum
{
    static void Main()
    {
        int[] dimensions = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int[][] matrix = new int[dimensions[0]][];

        // Not sure how to achieve similar input with a normal 2D array. 
        // That is why I'm using a jagged array.
        for (int i = 0; i < dimensions[1] - 1; i++)
        {
            matrix[i] = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        }

        int MaxSum = int.MinValue;
        int[] MaxSumPosition = new int[2];
        int temp = 0;

        for (int row = 0; row < matrix.Length - 2; row++)
        {
            for (int col = 0; col < matrix[row].Length - 2; col++)
            {
                // This could be another two for loops if we want easily to change the number of elements we check.
                temp = matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2] +
                    matrix[row + 1][col] + matrix[row + 1][col + 1] + matrix[row + 1][col + 2] +
                    matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row + 2][col + 2];

                if (temp > MaxSum )
                {
                    MaxSum = temp;
                    MaxSumPosition[0] = row;
                    MaxSumPosition[1] = col; 
                }
            }
        }
        //PrintJaggedMatrix(matrix);
        Console.WriteLine($"Sum = {MaxSum}");
        PrintJaggedMatrixFromGivenPosition(matrix, MaxSumPosition, 2);
    }

    private static void PrintJaggedMatrixFromGivenPosition(int[][] matrix, int[] position, int lenth)
    {
        // Might want to check if going out of array if using somewhere else.
        for (int row = position[0]; row <= position[0] + lenth; row++)
        {
            for (int col = position[1]; col <= position[1] + lenth; col++)
            {
                Console.Write($"{matrix[row][col]}".PadLeft(3, ' '));
            }
            Console.WriteLine();
        }
    }

    //private static void PrintJaggedMatrix(int[][] matrix)
    //{
    //    for (int row = 0; row < matrix.Length; row++)
    //    {
    //        for (int col = 0; col < matrix[row].Length; col++)
    //        {
    //            Console.Write($"{matrix[row][col]}".PadLeft(3, ' '));
    //        }
    //        Console.WriteLine();
    //        Console.WriteLine();
    //    }
    //}
}