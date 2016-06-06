namespace ManualStringProcessing
{
    using System;
    using System.Text;

    class UnicodeCharacters
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            foreach (char symbol in input)
            {
                Console.Write($"\\u{GetUnicodeCode(symbol):X4}".ToLower());
            }
            Console.WriteLine();
        }

        private static int GetUnicodeCode(char character)
        {
            UTF32Encoding encoding = new UTF32Encoding();
            byte[] bytes = encoding.GetBytes(character.ToString().ToCharArray());

            return BitConverter.ToInt32(bytes, 0);
        }
    }
}
