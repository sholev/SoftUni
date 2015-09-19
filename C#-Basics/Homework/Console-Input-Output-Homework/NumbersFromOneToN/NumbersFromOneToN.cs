using System;

class NumbersFromOneToN
{
    static void Main()
    {
        int n = Int32.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine( i+1 );
        }
    }
}