using System;
using System.Collections.Generic;
using System.Linq;

class PlusRemove
{
    static void Main()
    {
        string input = Console.ReadLine();
        List<List<string>> inputLines = new List<List<string>>();
        List<List<string>> forRemoval = new List<List<string>>();        

        while (input != "END")
        {
            // When I use inputLines = forRemoval both of them will just point to the same location in memory.
            // I'm saving the input for both of them. Not sure if I can avoid this some other way.
            inputLines.Add(new List<string>());
            inputLines[inputLines.Count - 1] = Array.ConvertAll(input.ToCharArray(), c => char.ToString(c)).ToList();

            forRemoval.Add(new List<string>());
            forRemoval[inputLines.Count - 1] = Array.ConvertAll(input.ToCharArray(), c => char.ToString(c)).ToList();

            input = Console.ReadLine();
        }

        markForRemoval(inputLines, ref forRemoval);
        
        for (int row = 0; row < forRemoval.Count; row++)
        {
            forRemoval[row].RemoveAll(str => str == "REMOVE");

            for (int col = 0; col < forRemoval[row].Count; col++)
            {
                Console.Write(forRemoval[row][col]);              
            }

            Console.WriteLine();
        }
    }

    private static void markForRemoval(List<List<string>> inputLines, ref List<List<string>> forRemoval)
    {
        string plusCenter = string.Empty;
        string plusUp = string.Empty;
        string plusDown = string.Empty;
        string plusLeft = string.Empty;
        string plusRight = string.Empty;

        for (int row = 1; row < inputLines.Count; row++)
        {
            for (int col = 1; col < inputLines[row].Count; col++)
            {
                if (plusNotOutOfRange(row, col, inputLines))
                {
                    plusCenter = inputLines[row][col].ToUpper();
                    plusUp = inputLines[row - 1][col].ToUpper();
                    plusDown = inputLines[row + 1][col].ToUpper();
                    plusLeft = inputLines[row][col - 1].ToUpper();
                    plusRight = inputLines[row][col + 1].ToUpper();

                    if (plusCenter == plusUp &&
                        plusCenter == plusDown &&
                        plusCenter == plusLeft &&
                        plusCenter == plusRight)
                    {
                        forRemoval[row][col] = "REMOVE";
                        forRemoval[row - 1][col] = "REMOVE";
                        forRemoval[row + 1][col] = "REMOVE";
                        forRemoval[row][col - 1] = "REMOVE";
                        forRemoval[row][col + 1] = "REMOVE";
                    }
                }
            }
        }
    }

    private static bool plusNotOutOfRange(int row, int col, List<List<string>> inputLines)
    {
        string temp = string.Empty;

        try
        {
            temp = inputLines[row][col];
            temp = inputLines[row - 1][col];
            temp = inputLines[row + 1][col];
            temp = inputLines[row][col - 1];
            temp = inputLines[row][col + 1];

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
