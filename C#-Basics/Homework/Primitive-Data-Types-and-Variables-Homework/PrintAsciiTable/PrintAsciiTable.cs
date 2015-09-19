using System;

class PrintAsciiTable
{
    static void Main()
    {
        for (int i = 0; i < 256; i++)
        {
            Console.WriteLine("{0}: {1}", i, (char)i);

        }
    }
}