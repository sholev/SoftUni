using System;

class ModifyBitAtGivenPosition
{
    static void Main()
    {
        Console.WriteLine("Type in anything but int to exit");
        long integer = 0;
        int position = 0;
        int replacement = 0;

        while (true)
        {
            try
            {
                Console.Write("Enter integer: ");
                integer = long.Parse(Console.ReadLine());
                Console.Write("Enter position for replacement: ");
                position = int.Parse(Console.ReadLine());
                Console.Write("Enter bit value for replacement: ");
                replacement = int.Parse(Console.ReadLine());
            }
            catch
            {
                return;
            }

            long replacedInteger = SetBitAtPosition(integer, position, replacement);

            Console.WriteLine("Input: {0}, after modification: {1}", integer, replacedInteger);
            Console.WriteLine(new String('-', 10));
        }
    }

    private static long SetBitAtPosition(long number, int position, int setBitTo)
    {
        if (setBitTo == 1)
            return number | (1 << position);
        else
            return number & ~(1 << position);
    }
}