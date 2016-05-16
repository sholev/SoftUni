using System;
using System.Text;

/* It is working as intended, but it is slow for the Judge and it gets only 80/100
 * I guess I need to learn bitwise operations instead of trying to cheat with text. :D
 */

class BitsInverter
{
    static void Main()
    {
        byte n = byte.Parse(Console.ReadLine());
        byte step = byte.Parse(Console.ReadLine());
        byte[] nNumbers = new byte[n];
        StringBuilder combined = new StringBuilder();
        byte byteLength = 8;

        for (byte i = 0; i < n; i++)    // Get the numbers, convert them to binary string
        {                               // and combine them in a single string
            nNumbers[i] = byte.Parse(Console.ReadLine());
            combined.Append(IntToBinString(nNumbers[i], byteLength));
        }

        for (byte i = 0; i < combined.Length; i += step)    // Flip the combined string
            combined[i] = flipCharBit(combined[i]);

        for (int i = 0; i < combined.Length; i += byteLength)   // Split the combined string,
        {                                                       // convert it to integers and print
            if ((i + byteLength) < combined.Length)
                Console.WriteLine(BinStringToInt(combined.ToString(i, byteLength)));
            else
                Console.WriteLine(BinStringToInt(combined.ToString(i, combined.Length - i)));
        }
    }

    private static char flipCharBit(char c)
    {
        if (c == '0')
            return '1';
        else
            return '0';
    }

    private static string IntToBinString(byte value, byte len)
    {
        string s = Convert.ToString(value, 2);
        return new string('0', len - s.Length) + s;
    }

    private static byte BinStringToInt(string s)
    {
        return Convert.ToByte(s, 2);
    }
}