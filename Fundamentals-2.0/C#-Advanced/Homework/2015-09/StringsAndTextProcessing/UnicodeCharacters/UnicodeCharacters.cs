using System;
using System.Text;

class UnicodeCharacters
{
    static void Main()
    {
        string input = Console.ReadLine();

        foreach (char c in input)
        {
            Console.Write("\\u{0:X4}", getUnicodeCode(c));
        }
        Console.WriteLine();
    }

    private static int getUnicodeCode(char character)
    {
        UTF32Encoding encoding = new UTF32Encoding();
        byte[] bytes = encoding.GetBytes(character.ToString().ToCharArray());

        //return BitConverter.ToInt32(bytes, 0).ToString("X");
        return BitConverter.ToInt32(bytes, 0);
    }
}