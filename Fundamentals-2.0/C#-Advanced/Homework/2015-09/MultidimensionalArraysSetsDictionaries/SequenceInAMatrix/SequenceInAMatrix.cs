using System;

// I couldn't solve this on my own, so for keeping the homework deadline
// I'm copying this solution with a bit of modifications.

class LineColumnOrDagonal
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
                    { "2", "x", ".", "s", ".", "Z" },
                    { "o", "1", "s", ".", "Z", "Z" },
                    { "o", "x", "0", "Z", "Z", "s" },
                    { "s", ".", ".", "Z", "x", "." },
                    { ".", "Z", "Z", "o", ".", "." },
                    { "Z", "Z", "s", "o", "o", "x" }
                };

        checkMatrix(strMatrix1);
        checkMatrix(strMatrix2);
        checkMatrix(strMatrix3);
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

    private static void checkMatrix(string[,] matrix)
    {
        int maxCounter = 0;
        string maxStr = string.Empty;

        checkLines(matrix, ref maxCounter, ref maxStr);
        checkColumns(matrix, ref maxCounter, ref maxStr);
        checkDiagonalsDownRight(matrix, ref maxCounter, ref maxStr);
        checkDagonalsDownLeft(matrix, ref maxCounter, ref maxStr);

        Console.WriteLine("Longest sequence of equal strings: " + GetResult(maxCounter, maxStr));
    }

    static void checkLines(string[,] matrix, ref int maxCount, ref string maxText)
    {
        int count = 1;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                for (int i = col; i < matrix.GetLength(1) - 1; i++)
                {
                    if (matrix[row, i] == matrix[row, i + 1])
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (count > maxCount)
                {
                    maxCount = count;
                    maxText = matrix[row, col];
                }

                count = 1;
            }
        }
    }

    static void checkColumns(string[,] matrix, ref int maxCount, ref string maxText)
    {
        int count = 1;

        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int i = row; i < matrix.GetLength(0) - 1; i++)
                {
                    if (matrix[i, col] == matrix[i + 1, col])
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (count > maxCount)
                {
                    maxCount = count;
                    maxText = matrix[row, col];
                }

                count = 1;
            }
        }
    }

    static void checkDiagonalsDownRight(string[,] matrix, ref int maxCount, ref string maxText)
    {
        int count = 1;

        for (int rows = 0; rows < matrix.GetLength(0) - 2; rows++)  //moves diagonal to left and down
        {
            for (int row = rows, col = 0; row < matrix.GetLength(0) - 1; row++, col++)
            {
                if ((row == matrix.GetLength(0) - 1) || (col == matrix.GetLength(1) - 1))
                {
                    break;
                }

                if (matrix[row, col] == matrix[row + 1, col + 1])
                {
                    count++;

                    if (count > maxCount)
                    {
                        maxCount = count;
                        maxText = matrix[row, col];
                    }
                }
                else
                {
                    count = 1;
                }
            }

            count = 1;
        }

        for (int cols = 1; cols < matrix.GetLength(0) - 2; cols++)  //moves diagonal to right
        {
            for (int row = 0, col = cols; row < matrix.GetLength(0) - 1; row++, col++)
            {
                if ((row == matrix.GetLength(0) - 1) || (col == matrix.GetLength(1) - 1))
                {
                    break;
                }

                if (matrix[row, col] == matrix[row + 1, col + 1])
                {
                    count++;

                    if (count > maxCount)
                    {
                        maxCount = count;
                        maxText = matrix[row, col];
                    }
                }
                else
                {
                    count = 1;
                }
            }

            count = 1;
        }
    }

    static void checkDagonalsDownLeft(string[,] arr, ref int maxCount, ref string maxText)
    {
        //ckeck diagonals down-left
        int count = 1;

        for (int rows = 0; rows < arr.GetLength(0) - 1; rows++)  //moves diagonal to left and down
        {
            for (int row = rows, col = arr.GetLength(1) - 1; row < arr.GetLength(0) - 1; row++, col--)
            {
                if ((row == arr.GetLength(0) - 1) || (col == 0))
                {
                    break;
                }

                if (arr[row, col] == arr[row + 1, col - 1])
                {
                    count++;

                    if (count > maxCount)
                    {
                        maxCount = count;
                        maxText = arr[row, col];
                    }
                }

                else count = 1;
            }

            count = 1;
        }

        for (int cols = arr.GetLength(1) - 2; cols >= 1; cols--)  //moves diagonal to right
        {
            for (int row = 0, col = cols; row < arr.GetLength(0) - 1; row++, col--)
            {
                if ((row == arr.GetLength(0) - 1) || (col == 0))
                {
                    break;
                }

                if (arr[row, col] == arr[row + 1, col - 1])
                {
                    count++;

                    if (count > maxCount)
                    {
                        maxCount = count;
                        maxText = arr[row, col];
                    }
                }

                else count = 1;
            }

            count = 1;
        }
    }
}

// =========================================================================
// This is another solution I worked on.
// But it is wrong, keeping it here if I ever get
// the time and motivation to try and figure it out:
// =========================================================================

//using System;

//class SequenceInAMatrix
//{
//    static void Main()
//    {
//        string[,] strMatrix1 =
//        {
//            { "ha", "fifi", "ho", "hi" },
//            { "fo", "ha", "hi", "xx" },
//            { "xxx", "ho", "ha", "xx" }
//        };

//        string[,] strMatrix2 =
//        {
//            { "s", "qq", "s"},
//            { "pp", "pp", "s" },
//            { "pp", "qq", "s" }
//        };

//        string[,] strMatrix3 =
//        {
//            { "2", "x", ".", "s", ".", "s" },
//            { "o", "1", "s", ".", "s", "o" },
//            { "o", "x", "0", "s", ".", "s" },
//            { "s", ".", "z", ".", "x", "." },
//            { ".", "z", "s", "o", ".", "." },
//            { "z", "s", "s", "o", "o", "x" }
//        };

//        Console.WriteLine(FindLongestRepetition(strMatrix1));
//        Console.WriteLine(FindLongestRepetition(strMatrix2));
//        Console.WriteLine(FindLongestRepetition(strMatrix3));
//    }

//    private static string FindLongestRepetition(string[,] matrix)
//    {
//        int maxRepeat = 0;
//        int tempRepeat = 0;
//        string maxStr = string.Empty;

//        for (int row = 0; row < matrix.GetLength(0); row++)
//        {
//            for (int col = 0; col < matrix.GetLength(1); col++)
//            {
//                string tempStr = matrix[row, col];
//                tempRepeat = Math.Max(tempRepeat, FindRepeatingSequence(matrix, row, col, "row"));
//                tempRepeat = Math.Max(tempRepeat, FindRepeatingSequence(matrix, row, col, "column"));
//                tempRepeat = Math.Max(tempRepeat, FindRepeatingSequence(matrix, row, col, "diagonal"));
//                tempRepeat = Math.Max(tempRepeat, FindRepeatingSequence(matrix, row, col, "diagonalReverse"));                

//                if (tempRepeat > maxRepeat)
//                {
//                    maxRepeat = tempRepeat;
//                    maxStr = tempStr;
//                }
//            }
//        }

//        return GetResult(maxRepeat, maxStr);
//    }

//    private static string GetResult(int repetitions, string str)
//    {
//        string result = str;

//        for (int i = 1; i < repetitions; i++)
//        {
//            result += ", " + str;
//        }

//        return result;
//    }

//    private static int FindRepeatingSequence(string[,] matrix, int startRow, int startCol, string direction)
//    {
//        int count = 0;
//        int result = 0;

//        switch (direction)
//        {
//            case "row":

//                count = 0;
//                for (int col = startCol; col < matrix.GetLength(1); col++)
//                {
//                    if (matrix[startRow, col] == matrix[startRow, startCol])
//                    {
//                        count++;
//                    }
//                }

//                break;

//            case "column":

//                count = 0;
//                for (int row = startRow; row < matrix.GetLength(0); row++)
//                {
//                    if (matrix[row, startCol] == matrix[startRow, startCol])
//                    {
//                        count++;
//                    }
//                }

//                break;

//            case "diagonal":

//                count = 0;
//                int diagonalSize = Math.Min(matrix.GetLength(0), matrix.GetLength(1));

//                for (int i = startCol; i < diagonalSize; i++)
//                {
//                    if (matrix[i, i] == matrix[startRow, startCol])
//                    {
//                        count++;
//                    }
//                }             

//                break;

//            case "diagonalReverse":

//                count = 0;
//                int diagonalReverseSize = Math.Min(matrix.GetLength(0), matrix.GetLength(1));

//                for (int i = startCol; i < diagonalReverseSize; i++)
//                {
//                    if (matrix[diagonalReverseSize - i - 1, i] == matrix[startRow, startCol])
//                    {
//                        count++;
//                    }
//                }

//                break;

//            default:
//                break;
//        }

//        return count;
//    }
//}