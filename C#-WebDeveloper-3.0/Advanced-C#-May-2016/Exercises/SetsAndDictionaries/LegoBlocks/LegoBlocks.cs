namespace ProblemsWithMatrices
{
    using System;
    using System.Linq;

    class LegoBlocks
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] firstArray = new int[rows][];
            int[][] secondArray = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                firstArray[row] =
                    Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
            }

            for (int row = 0; row < rows; row++)
            {
                secondArray[row] =
                    Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
            }

            if (ArraysFit(firstArray, secondArray, rows))
            {
                for (int row = 0; row < rows; row++)
                {
                    Console.WriteLine(
                        "[{0}, {1}]",
                        string.Join(", ", firstArray[row]),
                        string.Join(", ", secondArray[row].Reverse()));
                }
            }
            else
            {
                Console.WriteLine(
                    "The total number of cells is: {0}",
                    firstArray.Sum(row => row.Length) + secondArray.Sum(row => row.Length));
            }
        }

        private static bool ArraysFit(int[][] firstArray, int[][] secondArray, int rows)
        {
            int combinedWidth = firstArray[0].Length + secondArray[0].Length;

            for (int row = 1; row < rows; row++)
            {
                if (firstArray[row].Length + secondArray[row].Length != combinedWidth)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
