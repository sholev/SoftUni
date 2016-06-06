namespace ManualStringProcessing
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Text;
    using System.Text.RegularExpressions;

    class FromBaseTenToBaseN
    {
        static void Main(string[] args)
        {
            var input = Regex.Split(Console.ReadLine(), @"\s+");
            var number = BigInteger.Parse(input[1]);
            var targetBase = int.Parse(input[0]);

            Console.WriteLine(Convert(number, targetBase));
        }

        private static string Convert(BigInteger number, int targetBase)
        {
            var stack = new Stack<BigInteger>();
            while (number >= targetBase)
            {
                stack.Push(number % targetBase);
                number = number / targetBase;
            }

            StringBuilder result = new StringBuilder(number.ToString());
            while (stack.Count > 0)
            {
                result.Append(stack.Pop());
            }

            return result.ToString();
        }
    }
}
