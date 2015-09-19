using System;

class FirstLargerThanNeighbours
{
    static void Main()
    {
        int[][] mickJagger = new int[][]
        {
            new int[] { 1, 3, 4, 5, 1, 0, 5 },
            new int[] { 1, 2, 3, 4, 5, 6, 6 },
            new int[] { 1, 1, 1 },
        };

        foreach (var arr in mickJagger)
        {
            Console.WriteLine(GetIndexOfFirstElementLargerThanNeighbours(arr));
        }        
    }

    private static int GetIndexOfFirstElementLargerThanNeighbours(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (i - 1 >= 0 && i + 1 < arr.Length) // Is it inside the bounds of the array.
            {
                if (arr[i - 1] < arr[i] && arr[i + 1] < arr[i])
                {
                    return i;
                }
            }
            else if (i - 1 >= 0) // Is it the left border case.
            {
                if (arr[i - 1] < arr[i])
                {
                    return i;
                }
            }
            else if (i + 1 < arr.Length) // Is it the right border case.
            {
                if (arr[i + 1] < arr[i])
                {
                    return i;
                }
            }
        }        

        return -1;
    }
}
