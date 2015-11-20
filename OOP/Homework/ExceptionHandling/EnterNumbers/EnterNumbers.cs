using System;
using System.Collections.Generic;
using System.Linq;

class EnterNumbers
{
    static void Main(string[] args)
    {
        var numbers = new List<int>(10);
        Console.WriteLine("Enter 10 numbers:");
        for (int i = 0; i < 10; i++)
        {
            try
            {
                Console.Write($"N[{i}] = ");
                numbers.Add(ReadNumber(numbers.Count == 0 ? 1 : numbers.Last(), 100 - (9 - numbers.Count)));
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                i--;
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                i--;
            }
        }
        Console.WriteLine(String.Join(",", numbers));        
    }

    static int ReadNumber(int start, int end)
    {
        int input = 0;

        input = Int32.Parse(Console.ReadLine());

        if (input <= start || input >= end)
        {
            throw new ArgumentOutOfRangeException(input.GetTypeCode() + " input", $"Parameter is not in the range: {start} < N < {end}.");
        }

        return input;
    }
}