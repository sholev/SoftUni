using System;

class FibonacciNumbers
{
    static void Main()
    {
        int n = Int32.Parse(Console.ReadLine());
        decimal numOne = 0;
        decimal numTwo = 1;

        for (int i = 0; i < n; i++)
        {            
            Console.Write("{0}, ", numOne);

            decimal temp = numOne;
            numOne = numTwo;
            numTwo = temp + numTwo;
        }
    }
}
