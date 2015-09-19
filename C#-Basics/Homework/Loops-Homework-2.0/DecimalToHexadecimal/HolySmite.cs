using System;

namespace DecimalToHexadecimal
{
    class HolySmite // The one that drains all your mana.
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
                        Console.WriteLine("Or enter \"exit\" if you want to exit.");
                        Console.WriteLine(new string('-', 10));
                        continue;
                    }
                    Console.WriteLine("Hexadecimal represantation: {0}", DecimalToHex(numberForConversion));
                }

                Console.WriteLine(new string('-', 10));
            }
        }

        // Using method 1 from this guide:
        // http://www.wikihow.com/Convert-from-Decimal-to-Binary
        // And again, negative numbers will not work, but they are not required in the problem.
        private static string DecimalToHex(long dNumber)
        {
            char[] tohex_table = {
                                 '0', '1', '2', '3',
                                 '4', '5', '6', '7',
                                 '8', '9', 'A', 'B',
                                 'C', 'D', 'E', 'F'
                                 };

            string result = string.Empty;
            long temp = dNumber;
            if (temp > 0)
            {
                while (temp > 0)
                {
                    result += tohex_table[temp % 16];
                    temp /= 16;
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
