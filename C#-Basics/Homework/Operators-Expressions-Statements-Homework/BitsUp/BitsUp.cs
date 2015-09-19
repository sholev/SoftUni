using System;

class BitsUp
{
    static void Main()
    {
        int numberOfBytes = Int32.Parse(Console.ReadLine());
        int step = Int32.Parse(Console.ReadLine());
        int[] bytes = new Int32[numberOfBytes];
        int[] resultBytes = new Int32[numberOfBytes];

        for (int i = 0; i < bytes.Length; i++)
            bytes[i] = Int32.Parse(Console.ReadLine());

        int index = 1;
        resultBytes = bytes;

        for (int i = 0; i < bytes.Length; i++)
            for (int l = 0; l < 8; l++)
                if (index == l + (i * 8))
                {
                    resultBytes[i] = SetBitAtPosition(resultBytes[i], 7 - l, 1);
                    index += step;
                }

        for (int i = 0; i < bytes.Length; i++)
            Console.WriteLine(resultBytes[i]);
    }

    private static int SetBitAtPosition(int number, int position, int setBitTo)
    {
        if (setBitTo == 1)
            return number | (1 << position);
        else
            return number & ~(1 << position);
    }
}