namespace ProblemsWithMatrices
{
    using System;
    using System.Collections.Generic;

    class Crossfire
    {
        static void Main(string[] args)
        {
            string[] dimensions = Console.ReadLine().Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int rows = int.Parse(dimensions[0]);
            int cols = int.Parse(dimensions[1]);

            var matrix = new List<List<int>>();
            FillMatrix(matrix, rows, cols);

            string input = Console.ReadLine();
            while (input != "Nuke it from orbit")
            {
                var shotParameters = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int shotRow = int.Parse(shotParameters[0]);
                int shotCol = int.Parse(shotParameters[1]);
                int shotRadius = int.Parse(shotParameters[2]);

                ShootCrossgun(matrix, shotRow, shotCol, shotRadius);

                input = Console.ReadLine();
            }
            PrintMatrix(matrix);
        }

        private static void ShootCrossgun(List<List<int>> matrix, int shotRow, int shotCol, int shotRadius)
        {
            var elementsForRemoval = new HashSet<int>();
            for (int row = shotRow + shotRadius; row >= shotRow - shotRadius; row--)
            {
                if (ShotIsInside(row, shotCol, matrix))
                {
                    elementsForRemoval.Add(matrix[row][shotCol]);
                }
            }

            for (int col = shotCol + shotRadius; col >= shotCol - shotRadius; col--)
            {
                if (ShotIsInside(shotRow, col, matrix))
                {
                    elementsForRemoval.Add(matrix[shotRow][col]);
                }
            }

            foreach (List<int> row in matrix.ToArray())
            {
                foreach (int element in elementsForRemoval)
                {
                    row.Remove(element);
                }

                if (row.Count == 0)
                {
                    matrix.Remove(row);
                }
            }
        }

        private static bool ShotIsInside(int row, int col, List<List<int>> matrix)
        {
            return row >= 0 && col >= 0 && row < matrix.Count && col < matrix[row].Count;
        }

        private static void FillMatrix(List<List<int>> matrix, int rows, int cols)
        {
            int counter = 0;
            for (int i = 0; i < rows; i++)
            {
                matrix.Add(new List<int>());
                for (int j = 0; j < cols; j++)
                {
                    matrix[i].Add(++counter);
                }
            }
        }

        private static void PrintMatrix(List<List<int>> matrix)
        {
            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix[i].Count; j++)
                {
                    Console.Write($"{matrix[i][j]} ");
                }
                Console.WriteLine();
            }
        }

    }
}