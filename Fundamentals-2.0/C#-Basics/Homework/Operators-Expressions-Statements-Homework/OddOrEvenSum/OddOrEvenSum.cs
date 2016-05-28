using System;

class OddOrEvenSum
{
    static void Main(string[] args)
    {
        int howManyNumbers = int.Parse(Console.ReadLine());
        int oddSum = 0;
        int evenSum = 0;
        int temp = 0;

        for (int i = 1; i <= 2 * howManyNumbers; i++)
        {
            temp = int.Parse(Console.ReadLine());
            if (i % 2 == 1)
                oddSum += temp;
            else
                evenSum += temp;
        }

        if (oddSum == evenSum)
            Console.WriteLine("Yes, sum={0}", oddSum);
        else
            Console.WriteLine("No, diff={0}", Math.Abs(oddSum - evenSum));
    }
}