using System;
using System.Linq;

namespace HexadecimalToDecimal
{
    class PurgeTheMagick
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter \"exit\" if you want to exit.");

            while (true)
            {
                Console.Write("Enter hexadecimal number: ");
                string inputStr = Console.ReadLine();

                if (inputStr == "exit")
                {
                    return;
                }
                else if (isNotHex(inputStr) || inputStr == string.Empty)
                {
                    Console.WriteLine("Bad input, make sure you are entering a hexadecimal number.");
                    Console.WriteLine("Or enter \"exit\" if you want to exit.");
                }
                else
                {
                    Console.WriteLine("Decimal represantation: {0}", BinaryToDecimal(inputStr));
                }

                Console.WriteLine(new string('-', 10));
            }
        }

        // Need to come back here and understand this better. :D
        // http://stackoverflow.com/questions/74148/how-to-convert-numbers-between-hexadecimal-and-decimal-in-c
        private static long BinaryToDecimal(string hexNumber)
        {
            sbyte[] unhex_table =
            {
                 -1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1
                ,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1
                ,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1
                , 0, 1, 2, 3, 4, 5, 6, 7, 8, 9,-1,-1,-1,-1,-1,-1
                ,-1,10,11,12,13,14,15,-1,-1,-1,-1,-1,-1,-1,-1,-1
                ,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1
                ,-1,10,11,12,13,14,15,-1,-1,-1,-1,-1,-1,-1,-1,-1
                ,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1
            };

            long decValue = unhex_table[(byte)hexNumber[0]];

            for (int i = 1; i < hexNumber.Length; i++)
            {
                decValue *= 16;
                decValue += unhex_table[(byte)hexNumber[i]];
            }

            return decValue;
        }

        // Negative numbers won't work, but they aren't mentioned.
        // http://stackoverflow.com/questions/3293295/string-contains-only-a-given-set-of-characters
        private static bool isNotHex(string inputStr)
        {
            string allowedChars = "0123456789ABCDEF";

            // .NET 2
            //foreach (var chr in inputStr) 
            //{
            //    if (!allowedChars.Contains(chr.ToString())) 
            //    {
            //        return true;
            //    }
            //}

            //return false;

            // LINQ - .NET 3.5
            return !inputStr.ToUpper().All(c => allowedChars.Contains(c));

        }
    }
}
