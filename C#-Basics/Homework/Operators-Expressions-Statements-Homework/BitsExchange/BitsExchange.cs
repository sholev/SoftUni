using System;

class BitsExchange
{
    static void Main()
    {
        Console.WriteLine("Type in anything but int to exit");
        long integer = 0;

        while (true)
        {
            try
            {
                Console.Write("Input:  ");
                integer = long.Parse(Console.ReadLine());
            }
            catch
            {
                return;
            }


            int firstThree = GetThreeBitsAtPosition(integer, 3);
            int lastThree = GetThreeBitsAtPosition(integer, 24);

            long extractedMask = (((firstThree << 18) << 3) | lastThree) << 3;   // This is the mask we exctract.

            long maskOne = (((7 << 18) << 3) | 7) << 3;     /* This mask is 00000111 00000000 00000000 00111000
                                                             * It is used so we can zero the bits at positions
                                                             * we need in order to place the mask we extracted. */

            long exchangedInteger = integer & ~maskOne;
            exchangedInteger = exchangedInteger | extractedMask;


            Console.WriteLine("Result: {0}", exchangedInteger);
//            Console.WriteLine(Convert.ToString(integer, 2).PadLeft(4 * 8, '0'));          // I used those
//            Console.WriteLine(Convert.ToString(extractedMask, 2).PadLeft(4 * 8, '0'));    // to help me figure
//            Console.WriteLine(Convert.ToString(exchangedInteger, 2).PadLeft(4*8, '0'));   // what I'm doing. :D
            Console.WriteLine(new String('-', 10));
        }
    }

    private static int GetThreeBitsAtPosition(long number, int position)
    {
        return (int)(number >> position) & 7; // 7 is 0111 mask
    }
}