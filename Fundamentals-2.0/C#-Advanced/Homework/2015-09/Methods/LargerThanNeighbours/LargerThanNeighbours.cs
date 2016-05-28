using System;

class LargerThanNeighbours
{
    static void Main()
    {
        int[] numbers = { 1, 3, 4, 5, 1, 0, 5 };

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(IsLargerThanNeighbours(numbers, i));
        }
    }

    private static bool IsLargerThanNeighbours(int[] numbers, int i)
    {
        
        if (i - 1 >= 0 && i + 1 < numbers.Length) // Is it inside the bounds of the array.
        {
            if (numbers[i - 1] < numbers[i] && numbers[i + 1] < numbers[i])
            {
                return true;
            }
        }
        else if (i - 1 >= 0) // Is it the left border case.
        {
            if (numbers[i - 1] < numbers[i])
            {
                return true;
            }
        }
        else if (i + 1 < numbers.Length) // Is it the right border case.
        {
            if (numbers[i + 1] < numbers[i])
            {
                return true;
            }
        }

        return false;
    }
}