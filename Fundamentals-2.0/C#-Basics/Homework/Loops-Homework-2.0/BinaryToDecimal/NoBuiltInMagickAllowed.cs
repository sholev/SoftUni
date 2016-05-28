using System;

namespace BinaryToDecimal
{
    class NoBuiltInMagickAllowed
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter \"exit\" if you want to exit.");

            while (true)
            {
                Console.Write("Enter binary number: ");
                string inputStr = Console.ReadLine();

                if (inputStr == "exit")
                {
                    return;
                }
                else if (isNotBinary(inputStr))
                {
                    Console.WriteLine("Bad input, make sure you are entering a binary number.");
                    Console.WriteLine("Enter \"exit\" if you want to exit.");
                }
                else
                {
                    Console.WriteLine("Decimal represantation: {0}", BinaryToDecimal(inputStr));
                }

                Console.WriteLine(new string('-', 10));
            }
        }

        // Using method 2 from this guide:
        // http://www.wikihow.com/Convert-from-Binary-to-Decimal
        private static long BinaryToDecimal(string binaryNumber)
        {
            long result = 0;

            foreach (char num in binaryNumber)
            {
                // Both do the job.
                // result = (result * 2) + (int)char.GetNumericValue(num);
                result = (result * 2) + (int)(num - '0');
            }

            return result;
        }

        // Negative numbers won't work, but they aren't mentioned.
        private static bool isNotBinary(string inputStr)
        {
            foreach (var chr in inputStr)
            {
                if (chr != '0' && chr != '1')
                {
                    return true;
                }
            }

            return false;
        }
    }
}
