using System;

class ComparingFloats
{
    static void Main()
    {
        double a, b;
        double eps = 0.000001d;
        bool equal;

        Console.Write("Number a = ");
        a = Double.Parse(Console.ReadLine());

        Console.Write("Number b = ");
        b = Double.Parse(Console.ReadLine());

        if (Math.Abs(a - b) < eps)
            equal = true;
        else
            equal = false;

        Console.WriteLine("a = {0}; b = {1}; equal = {2}.", a, b, equal);
    }
}
