using System;

class IsThirdDigitSeven
{
    static void Main()
    {
        Console.WriteLine("Type in anything but Int to exit");
        int integer = 0;
        int thirdDigit = 0;

        while (true)
        {
            try
            {
                Console.Write("Enter integer: ");
                integer = Int32.Parse(Console.ReadLine());
                thirdDigit = (integer / 100) % 10;
            }
            catch
            {
                return;
            }

            if (thirdDigit == 7)
                Console.WriteLine("The third digit of {0} is 7.", integer);
            else
                Console.WriteLine("The third digit of {0} is not 7.", integer);

            Console.WriteLine(new string('-', 10));
        }
    }
}