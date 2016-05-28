using System;

class MultiplicationSign
{
    static void Main()
    {
        Console.WriteLine("Enter anything but a number to exit.");
        Console.WriteLine(new String('-', 10));
        double numA = 0;
        double numB = 0;
        double numC = 0;

        while (true)
        {
            try
            {
                Console.Write("a = ");
                numA = double.Parse(Console.ReadLine());
                Console.Write("b = ");
                numB = double.Parse(Console.ReadLine());
                Console.Write("c = ");
                numC = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                return;
            }

            if (numA == 0 || numB == 0 || numC == 0)
                Console.WriteLine(0);

            else if ((numA > 0 && numB > 0 && numC > 0) || 
                     (numA > 0 && numB < 0 && numC < 0) ||
                     (numA < 0 && numB > 0 && numC < 0) ||
                     (numA < 0 && numB < 0 && numC > 0))
                Console.WriteLine('+');

            else
                Console.WriteLine('-');

            Console.WriteLine(new String('-', 10));
        }
    }
}