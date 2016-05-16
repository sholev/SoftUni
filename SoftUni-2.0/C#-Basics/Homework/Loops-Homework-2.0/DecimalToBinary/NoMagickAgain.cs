using System;

namespace DecimalToBinary
{
    class NoMagickAgain
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter \"exit\" if you want to exit.");

            while (true)
            {
                Console.Write("Enter decimal number: ");
                string inputStr = Console.ReadLine();
                long numberForConversion = 0;

                if (inputStr == "exit")
                {
                    return;
                }
                else
                {
                    try
                    {
                        numberForConversion = long.Parse(inputStr);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Bad input, make sure it is a decimal number.");
                        Console.WriteLine("Enter \"exit\" if you want to exit.");
                        Console.WriteLine(new string('-', 10));
                        continue;
                    }
                    Console.WriteLine("Binary represantation: {0}", DecimalToBinary(numberForConversion));
                }

                Console.WriteLine(new string('-', 10));
            }
        }

        // Using method 1 from this guide:
        // http://www.wikihow.com/Convert-from-Decimal-to-Binary
        // And again, negative numbers will not work, but they are not required in the problem.
        private static string DecimalToBinary(long dNumber)
        {
            string result = string.Empty;
            long temp = dNumber;
            if (temp > 0)
            {
                while (temp > 0)
                {
                    result += (temp % 2).ToString();
                    temp /= 2;
                }

                // http://stackoverflow.com/questions/228038/best-way-to-reverse-a-string
                char[] reversedResult = result.ToCharArray();
                Array.Reverse(reversedResult);

                return new string(reversedResult);
            }
            else
            {
                return "0";
            }

        }
    }
}
