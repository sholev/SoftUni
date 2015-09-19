using System;

class SumOfNNumbers
{
    static void Main()
    {
        int n = Int32.Parse(Console.ReadLine());
        double sum = 0d;
        for (int i = 0; i < n; i++)
        {
            sum += Double.Parse(Console.ReadLine());
        }
        Console.WriteLine(sum);
    }
}