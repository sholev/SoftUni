using System;

class SortArrayNumbers
{
    static void Main()
    {
        string input = Console.ReadLine();
        decimal[] numbers = Array.ConvertAll(
            input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries),
            element => decimal.Parse(element));

        Array.Sort(numbers);

        Console.WriteLine(string.Join(" ", numbers));
    }
}
