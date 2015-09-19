using System;

class BitShifting
{
    static void Main()
    {
        ulong input = ulong.Parse(Console.ReadLine());
        int sievesNum = int.Parse(Console.ReadLine());
        ulong sieve = 0;
        ulong sieved = input;
        int result = 0;

        for (int i = 0; i < sievesNum; i++)
        {
            sieve = ulong.Parse(Console.ReadLine());
            sieved = sieved & ~sieve;
        }

        for (int i = 0; i < 64; i++)
            result += GetBitAtPosition(sieved, i);

        Console.WriteLine(result);
    }

    private static int GetBitAtPosition(ulong number, int position)
    {
        return (int)(number >> position) & 1; 
    }
}