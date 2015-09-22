using System;

class MatrixShuffling
{
    static void Main()
    {
        string[,] inputMatrix = new string[int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())];
        
        for (int row = 0; row < inputMatrix.GetLength(0); row++)
        {
            for (int col = 0; col < inputMatrix.GetLength(1); col++)
            {
                inputMatrix[row, col] = Console.ReadLine();
            }
        }

        string[] command = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        while (!(command.Length == 1 && command[0] == "END"))
        { 
            try
            {
                if (command[0] == "swap" && command.Length == 5)
                {
                    Swap(ref inputMatrix, command[0], int.Parse(command[1]), int.Parse(command[2]), int.Parse(command[3]), int.Parse(command[4]));
                    PrintMatrix(inputMatrix);
                }
                else
                {
                    throw new Exception();
                }                
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input!");
            }

            command = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        }
    }

    private static void Swap(ref string[,] inputMatrix, string cmd, int x1, int y1, int x2, int y2)
    {
        string temp = inputMatrix[x1, y1];
        inputMatrix[x1, y1] = inputMatrix[x2, y2];
        inputMatrix[x2, y2] = temp;
    }

    private static void PrintMatrix(string[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write($"{matrix[row, col]} ".PadLeft(2, ' '));
            }
            Console.WriteLine();
        }
    }
}
