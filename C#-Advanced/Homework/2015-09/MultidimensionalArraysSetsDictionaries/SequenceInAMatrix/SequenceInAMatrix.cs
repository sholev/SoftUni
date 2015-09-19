using System;

class SequenceInAMatrix
{
    static void Main()
    {
        string[,] strMatrix1 =
        {
            { "ha", "fifi", "ho", "hi" },
            { "fo", "ha", "hi", "xx" },
            { "xxx", "ho", "ha", "xx" }
        };

        string[,] strMatrix2 =
        {
            { "s", "qq", "s"},
            { "pp", "pp", "s" },
            { "pp", "qq", "s" }
        };

        string[,] strMatrix3 =
        {
            { "s", "x", "x", "s", "T", "s" },
            { "o", "x", "s", "T", "s", "o" },
            { "o", "x", "T", "s", "x", "s" },
            { "s", "T", "z", "x", "x", "o" },
            { "T", "z", "s", "o", "x", "s" },
            { "z", "s", "s", "o", "o", "x" }
        };

        Console.WriteLine(FindLongestRepetition(strMatrix1));
        Console.WriteLine(FindLongestRepetition(strMatrix2));
        Console.WriteLine(FindLongestRepetition(strMatrix3));
    }

    private static string FindLongestRepetition(string[,] matrix)
    {
        int maxRepeat = 0;
        int tempRepeat = 0;
        string maxStr = string.Empty;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                string tempStr = matrix[row, col];
                tempRepeat = Math.Max(tempRepeat, FindRepetitions(matrix, row, col, "row"));
                tempRepeat = Math.Max(tempRepeat, FindRepetitions(matrix, row, col, "column"));
                tempRepeat = Math.Max(tempRepeat, FindRepetitions(matrix, row, col, "diagonal"));
                tempRepeat = Math.Max(tempRepeat, FindRepetitions(matrix, row, col, "diagonalReverse"));                

                if (tempRepeat > maxRepeat)
                {
                    maxRepeat = tempRepeat;
                    maxStr = tempStr;
                }
            }
        }

        return GetResult(maxRepeat, maxStr);
    }

    private static string GetResult(int repetitions, string str)
    {
        string result = str;

        for (int i = 1; i < repetitions; i++)
        {
            result += ", " + str;
        }

        return result;
    }

    private static bool notOutsideOfMatrix (int row, int col, string[,] matrix)
    {
        // If we get an exeption we are going outside the board, therefore hitting a wall.
        try
        {
            string temp = matrix[row, col];
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private static int FindRepetitions(string[,] matrix, int startRow, int startCol, string direction)
    {
        int count = 0;
        int temp = 0;
        int r = 0;
        int c = 0;

        switch (direction)
        {
            case "row":

                count = 0;
                for (int col = startCol; col < matrix.GetLength(1); col++)
                {
                    if (matrix[startRow, col] == matrix[startRow, startCol])
                    {
                        count++;
                    }
                    else
                    {
                        if (temp < count)
                        {
                            temp = count;
                            count = 0;
                        }
                    }
                }

                break;

            case "column":

                count = 0;
                for (int row = startRow; row < matrix.GetLength(0); row++)
                {
                    if (matrix[row, startCol] == matrix[startRow, startCol])
                    {
                        count++;
                    }
                    else
                    {
                        if (temp < count)
                        {
                            temp = count;
                            count = 0;
                        }
                    }
                }

                break;

            case "diagonal":

                //count = 0;
                //int diagonalSize = Math.Min(matrix.GetLength(0), matrix.GetLength(1));
                //for (int i = startCol; i < diagonalSize; i++)
                //{
                //    if (matrix[i, i] == matrix[startRow, startCol])
                //    {
                //        count++;
                //    }
                //    else
                //    {
                //        break;
                //    }
                count = 0;
                r = 0;
                c = 0;

                int diagonalModifier = 0;

                while (notOutsideOfMatrix(r, c, matrix))
                {
                    if (matrix[r, c] == matrix[startRow, startCol])
                    {
                        count++;
                    }
                    else
                    {
                        if (temp < count)
                        {
                            temp = count;
                            count = 0;
                        }
                    }
                    r++;
                    c++;
                }

                break;

            case "diagonalReverse":

                count = 0;
                int diagonalReverseSize = Math.Min(matrix.GetLength(0), matrix.GetLength(1));
                for (int i = startCol; i < diagonalReverseSize; i++)
                {
                    if (matrix[diagonalReverseSize - i - 1, i] == matrix[startRow, startCol])
                    {
                        count++;
                    }
                    else
                    {
                        if (temp < count)
                        {
                            temp = count;
                            count = 0;
                        }
                    }
                }

                break;

            default:
                break;
        }

        return count;
    }
}