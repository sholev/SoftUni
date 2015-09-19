using System;

class ExtractBitFromInteger
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

            Console.WriteLine("The bit #{2} of {0} is: {1}.", integer, GetBitAtPosition(integer, position), position);
            Console.WriteLine(new String('-', 10));
        }
    }

    private static uint GetBitAtPosition(uint number, int position)
    {
        return (number >> position) & 1;
    }
}