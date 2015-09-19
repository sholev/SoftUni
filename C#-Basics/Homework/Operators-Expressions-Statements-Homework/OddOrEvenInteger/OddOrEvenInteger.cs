using System;

class OddOrEvenInteger
{
    static void Main()
    {
        Console.WriteLine("Type in anything but INT to exit");
        int integer = 0;


        while (true)
        {
            Console.Write("Enter integer: ");
            try // make sure input is of int type
            {
                integer = Int32.Parse(Console.ReadLine());
            }
            catch // exit if it is not of int type
            {
                return;
            }

            if (Int32.Parse(integer.ToString()) % 2 == 1 ||
                Int32.Parse(integer.ToString()) % 2 == -1)
            {
                Console.WriteLine("{0} os ODD.", integer);
            }

            else
            {
                Console.WriteLine("{0} is EVEN.", integer);
            }

            Console.WriteLine(new string ('-', 10));
        }
    }
}
