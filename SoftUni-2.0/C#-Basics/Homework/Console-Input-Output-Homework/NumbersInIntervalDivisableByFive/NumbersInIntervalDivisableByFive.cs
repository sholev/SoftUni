using System;

class NumbersInIntervalDivisableByFive
{
    static void Main()
    {
        int start = Int32.Parse(Console.ReadLine());
        int end = Int32.Parse(Console.ReadLine());
        int count = 0;

        for (int i = 0; i <= end - start; i++)
            if ((start + i) % 5 == 0)
                count++;

        Console.WriteLine(count);
    }
}
