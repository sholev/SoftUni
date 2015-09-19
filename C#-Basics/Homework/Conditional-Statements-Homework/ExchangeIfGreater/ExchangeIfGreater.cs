using System;

class ExchangeIfGreater
{
    static void Main()
    {
        Console.WriteLine("Enter anything but a number to exit.");
        Console.WriteLine(new String('-', 10));

        double numA = 0.0;
        double numB = 0.0;
        double NumTemp = 0.0;

        while (true)
        {
            try
            {
                Console.Write("Enter number a = ");
                numA = double.Parse(Console.ReadLine());

                Console.Write("Enter number b = ");
                numB = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                return;
            }


            if (numA > numB)
            {
                NumTemp = numA;
                numA = numB;
                numB = NumTemp;
            }

            Console.WriteLine("{0} {1}", numA, numB);
            Console.WriteLine(new String('-', 10));
        }
    }
}