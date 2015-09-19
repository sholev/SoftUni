using System;

/* Expanding on the concepts of the previous problem.
 * I would have just done this first, and then solved
 * both problems with it, if I didn't find it complicated
 * as hell. :D
 */

class BitExchangeAdvanced
{
    static void Main()
    {
        Console.WriteLine("Type in anything but an integer to exit");
        long integer = 0;
        int positionP = 0;
        int positionQ = 0;
        int lengthK = 0;

        long extractedMask = 0;
        long temporaryMask = 0;
        long exchangedInteger = 0;

        while (true)
        {
            try
            {
                Console.Write("Input we are working on: ");
                integer = long.Parse(Console.ReadLine());
                Console.Write("Exchange position p: ");
                positionP = int.Parse(Console.ReadLine());
                Console.Write("Exchange position q: ");
                positionQ = int.Parse(Console.ReadLine());
                Console.Write("Length for the exchange: ");
                lengthK = int.Parse(Console.ReadLine());
            }
            catch
            {
                return;
            }

            if ((positionP < positionQ) ? // I know (?:) should be avoided, I don't like it either. :D
                ((positionQ + lengthK - 1) > 31 || positionP < 0) : 
                ((positionP + lengthK - 1) > 31 || positionQ < 0))  
            {
                Console.WriteLine("out of range");
                Console.WriteLine(new String('-', 10));
            }

            else if ((positionP < positionQ) ? 
                (positionP + lengthK - 1 >= positionQ) : // If p < q we check if p + k - 1 >= q
                (positionQ + lengthK - 1 >= positionP))  // if p > q we check if q + k - 1 >= p
            {
                Console.WriteLine("overlapping");
                Console.WriteLine(new String('-', 10));
            }

            else
            {
                for (int i = 0; i < 32; i++) // Getting the bits for the exchange.
                {
                    if (i >= positionP && i <= positionP + lengthK - 1) // Checking if we are in range of (p...p+k) so we can store it.
                    {
                        extractedMask = SetBitAtPosition(extractedMask,
                            i - positionP + positionQ, // When "i" gets at position "p", we want to write at position "q"
                            GetBitAtPosition(integer, i));
                        temporaryMask = SetBitAtPosition(temporaryMask, i, 1); // The temporary mask should contain 1 on all the positions we are working on.
                    }
                    else if (i >= positionQ && i <= positionQ + lengthK - 1) // Checking if we are in range of (q...q+k) so we can store it.
                    {
                        extractedMask = SetBitAtPosition(extractedMask,
                            i - positionQ + positionP, // When "i" gets at position "q", we want to write at position "p"
                            GetBitAtPosition(integer, i));
                        temporaryMask = SetBitAtPosition(temporaryMask, i, 1);
                    }
                    else // Filling the rest of the positions in the masks with 0.
                    {
                        extractedMask = SetBitAtPosition(extractedMask, i, 0);
                        temporaryMask = SetBitAtPosition(temporaryMask, i, 0);
                    }
                }

                exchangedInteger = integer & ~temporaryMask;
                exchangedInteger = exchangedInteger | extractedMask;

                Console.WriteLine("Result after the exchange: {0}", exchangedInteger);

                //Console.WriteLine(Convert.ToString(integer, 2).PadLeft(4 * 8, '0'));
                //Console.WriteLine(Convert.ToString(temporaryMask, 2).PadLeft(4 * 8, '0'));
                //Console.WriteLine(Convert.ToString(extractedMask, 2).PadLeft(4 * 8, '0'));
                //Console.WriteLine(Convert.ToString(exchangedInteger, 2).PadLeft(4 * 8, '0'));

                Console.WriteLine(new String('-', 10));
            }
        }
    }

    private static long SetBitAtPosition(long number, int position, int setBitTo)
    {
        if (setBitTo == 1)
            return number | (1 << position);
        else
            return number & ~(1 << position);
    }

    private static int GetBitAtPosition(long number, int position)
    {
        return (int)(number >> position) & 1;
    }
}