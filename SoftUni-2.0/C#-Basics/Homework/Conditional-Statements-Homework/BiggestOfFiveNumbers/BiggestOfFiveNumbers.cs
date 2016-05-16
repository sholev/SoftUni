using System;

class BiggestOfFiveNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter anything but a number to exit.");
        Console.WriteLine(new String('-', 10));
        double biggestNum = double.MinValue;
        double input = 0.0;

        while (true)
        {
            try
            {
                Console.Write("a = ");
                biggestNum = double.Parse(Console.ReadLine());

                Console.Write("b = ");
                input = double.Parse(Console.ReadLine());
                if (input > biggestNum)
                    biggestNum = input;

                Console.Write("c = ");
                input = double.Parse(Console.ReadLine());
                if (input > biggestNum)
                    biggestNum = input;

                Console.Write("d = ");
                input = double.Parse(Console.ReadLine());
                if (input > biggestNum)
                    biggestNum = input;

                Console.Write("e = ");
                input = double.Parse(Console.ReadLine());
                if (input > biggestNum)
                    biggestNum = input;
            }
            catch (Exception)
            {
                return;
            }

            Console.WriteLine("The biggest is: {0}", biggestNum);
            biggestNum = double.MinValue;
            Console.WriteLine(new String('-', 10));
        }
    }
}