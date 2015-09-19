using System;

class CheckBitAtGivenPosition
{
    static void Main()
    {
        Console.WriteLine("Type in anything but uint to exit");
        uint integer = 0;
        int position = 0;

        while (true)
        {
            try
            {
                Console.Write("Enter integer: ");
                integer = uint.Parse(Console.ReadLine());
                Console.Write("Enter position for extraction: ");
                position = int.Parse(Console.ReadLine());
            }
            catch
            {
                return;
            }

            bool isOne = GetBitAtPosition(integer, position) == 1;

            Console.WriteLine("Bit #{2} of {0} is equal to 1. - {1}.", integer, isOne, position);
            Console.WriteLine(new String('-', 10));
        }
    }

    private static uint GetBitAtPosition(uint number, int position)
    {
        return (number >> position) & 1;
    }
}