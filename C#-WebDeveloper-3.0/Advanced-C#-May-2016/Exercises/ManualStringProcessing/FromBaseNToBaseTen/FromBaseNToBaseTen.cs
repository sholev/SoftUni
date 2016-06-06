namespace ManualStringProcessing
{
    using System;
    using System.Numerics;
    using System.Text.RegularExpressions;

    class FromBaseNToBaseTen
    {
        static void Main(string[] args)
        {
            var input = Regex.Split(Console.ReadLine(), @"\s+");
            var number = input[1];
            var fromBase = int.Parse(input[0]);

            Console.WriteLine(Convert(number, fromBase));
        }

        private static BigInteger Convert(string number, int fromBase)
        {
            BigInteger result = new BigInteger(0);

            foreach (char digit in number)
            {
                result = result * fromBase + BigInteger.Parse(digit.ToString());
            }

            return result;
        }
    }
}
