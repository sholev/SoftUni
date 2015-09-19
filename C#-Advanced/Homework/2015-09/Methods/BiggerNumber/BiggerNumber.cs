using System;

class BiggerNumber
{
    static void Main()
    {
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());

        int max = GetMaX(firstNumber, secondNumber);

        Console.WriteLine(max);
    }

    private static int GetMaX(int firstNumber, int secondNumber)
    {
        return Math.Max(firstNumber, secondNumber);
    }
}