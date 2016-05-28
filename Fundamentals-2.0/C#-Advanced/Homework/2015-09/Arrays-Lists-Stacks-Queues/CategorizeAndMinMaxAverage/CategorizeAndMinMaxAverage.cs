using System;
using System.Collections.Generic;
using System.Linq;

class CategorizeAndMinMaxAverage
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        decimal[] inputNumbers = Array.ConvertAll(
            input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries),
            element => decimal.Parse(element));

        List<int> intNumbers = new List<int>();
        List<decimal> decNumbers = new List<decimal>();

        //http://stackoverflow.com/questions/2751593/how-to-determine-if-a-decimal-double-is-an-integer
        foreach (var number in inputNumbers)
        {           
            if ((number % 1) < 0.000001m) 
            {
                intNumbers.Add((int)number);
            }
            else
            {
                decNumbers.Add(number);
            }
        }

        Console.WriteLine("[{0}] -> min: {1}, max: {2}, sum: {3}, avg: {4:F2}",
            string.Join(" ", decNumbers), decNumbers.Min(), decNumbers.Max(), decNumbers.Sum(), decNumbers.Average());
        Console.WriteLine("[{0}] -> min: {1}, max: {2}, sum: {3}, avg: {4:F2}",
            string.Join(" ", intNumbers), intNumbers.Min(), intNumbers.Max(), intNumbers.Sum(), intNumbers.Average());
    }
}
