using System;

class CollectTheCoins
{
    static void Main()
    {
        int boardRows = 4;
        char[][] board = new char[4][];
        
        for (int i = 0; i < boardRows; i++)
        {
            board[i] = Console.ReadLine().ToCharArray();
        }
        //PrintJaggedMatrix(board);

        int[] playerPosition = { 0, 0 };
        string moves = Console.ReadLine();
        int coinsCollected = 0;
        int wallsHit = 0;

        foreach (char move in moves)
        {
            playerPosition = GetMove(move, playerPosition, board, ref wallsHit);
            board = CheckForCoins(playerPosition, board, ref coinsCollected);
        }

        Console.WriteLine($"Coins collected: {coinsCollected}");
        Console.WriteLine($"Walls hit: {wallsHit}");
    }

    private static char[][] CheckForCoins(int[] playerPosition, char[][] board, ref int coinsCollected)
    {
        // If there is a coin at the position, we increase the coin counter and replace the coin with empty space.
        if (board[playerPosition[0]][playerPosition[1]] == '$')
        {
            coinsCollected++;
            board[playerPosition[0]][playerPosition[1]] = ' ';
            return board;
        }
        // If there isn't a coin, we do not make changes.
        else
        {
            return board;
        }
    }

    private static int[] GetMove(char move, int[] playerPosition, char[][] board, ref int wallsHit)
    {
        switch (move)
        {
            case '<':
                playerPosition[1]--;
                if (playerOutsideBoard(playerPosition, board))
                {
                    wallsHit++;
                    playerPosition[1]++;
                }                
                break;

            case '>':
                playerPosition[1]++;
                if (playerOutsideBoard(playerPosition, board))
                {
                    wallsHit++;
                    playerPosition[1]--;
                }
                break;

            case '^':
                playerPosition[0]--;
                if (playerOutsideBoard(playerPosition, board))
                {
                    wallsHit++;
                    playerPosition[0]++;
                }
                break;

            case 'V':
                playerPosition[0]++;
                if (playerOutsideBoard(playerPosition, board))
                {
                    wallsHit++;
                    playerPosition[0]--;
                }
                break;

            default:
                break;
        }

        return playerPosition;
    }

    private static bool playerOutsideBoard(int[] playerPosition, char[][] board)
    {
        // If we get an exeption we are going outside the board, therefore hitting a wall.
        try
        {
            char temp = board[playerPosition[0]][playerPosition[1]];
            return false;
        }
        catch (Exception)
        {
            return true;
        }
    }

    //private static void PrintJaggedMatrix(char[][] matrix)
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
