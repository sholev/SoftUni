using System;

namespace WiggleWiggle
{
    class ExamTaskFive
    {
        static void Main(string[] args)
        {
            long[] input = Array.ConvertAll(Console.ReadLine().Split(' '), str => long.Parse(str));
            long[] result = input;
            long bitHolderOne = 0;
            long bitHolderTwo = 0;

            for (int i = 0; i < input.Length; i += 2)
            {
                for (int j = 0; j < 64; j += 2)
                {
                    bitHolderOne = GetBitAtPosition(result[i], j);
                    bitHolderTwo = GetBitAtPosition(result[i + 1], j);

                    result[i] = SetBitAtPosition(result[i], j, bitHolderTwo);
                    result[i + 1] = SetBitAtPosition(result[i + 1], j, bitHolderOne);
                }

                //Console.WriteLine("{0} {1}", input[i], Convert.ToString(input[i], 2));
                //Console.WriteLine("{0} {1}", result[i], Convert.ToString(result[i], 2));

                result[i] ^= 9223372036854775807;
                result[i + 1] ^= 9223372036854775807;
            }

            for (int i = 0; i < input.Length; i++)
            {
                Console.WriteLine("{0} {1}", input[i], Convert.ToString(input[i], 2).PadLeft(63, '0'));
            }
        }

        private static long GetBitAtPosition(long number, int position)
        {
            return (number >> position) & 1L;
        }

        private static long SetBitAtPosition(long number, int position, long setBitTo)
        {
            if (setBitTo == 1)
                return number | (1L << position);
            else
                return number & ~(1L << position);
        }
    }
}
