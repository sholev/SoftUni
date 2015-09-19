using System;
using System.Threading;

class ExchangeVariableValues
{
    static void Main()
    {
        int a = 5;
        int b = 10;

        Console.WriteLine("Before: \na = {0} \nb = {1} ", a, b);

        int temp = a;
        a = b;
        b = temp;

        Console.WriteLine("After: \na = {0} \nb = {1} ", a, b);
    }
}