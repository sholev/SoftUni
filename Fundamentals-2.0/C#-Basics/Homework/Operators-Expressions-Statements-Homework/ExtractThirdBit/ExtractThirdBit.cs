using System;

class ExtractThirdBit
{
    static void Main()
    {
        Console.WriteLine("Type in anything but uint to exit");
        uint integer = 0;

        while (true)
        {
            try
            {
                Console.Write("Enter integer: ");
                integer = uint.Parse(Console.ReadLine());
            }
            catch
            {
                return;
            }

            Console.WriteLine("The bit #3 of {0} is: {1}.", integer, GetBitAtPosition(integer, 3));
            Console.WriteLine(new String('-', 10));
        }
    }

    private static uint GetBitAtPosition(uint number, int position)
    {
        return (number >> position) & 1;
    }
}