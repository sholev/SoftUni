using System;

class DivideBySevenAndFive
{
    static void Main()
    {
        Console.WriteLine("Type in anything but Int to exit");
        int integer = 0;

        while (true)
        {
            Console.Write("Enter integer: ");
            try
            {
                integer = Int32.Parse(Console.ReadLine());
            }
            catch
            {
                return;
            }
            if (integer % 7 == 0 && integer % 5 == 0 && integer != 0)
            {
                Console.WriteLine("{0} is divisible by 5 and 7.", integer);
            }
            else
            {
                Console.WriteLine("{0} is not divisible by 5 and 7.", integer);
            }
            Console.WriteLine(new string('-', 10));
        }
    }
}