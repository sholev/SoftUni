using System;

namespace BitFlipper
{
    class ExamProblemFive
    {
        static void Main(string[] args)
        {
            ulong input = ulong.Parse(Console.ReadLine());
            //Console.WriteLine(Convert.ToString((long)input, 2).PadLeft(64, '0'));
            ulong output = input;

            for (int i = 61; i >= 0; i--)
            {
                if (GetThreeBitsAtPosition(input, i) == 7)
                {
                    //Console.WriteLine(Convert.ToString((long)GetThreeBitsAtPosition(input, i)));
                    output = FlipThreeBitsAtPosition(output, i);
                    i -= 2;
                }
                else if (GetThreeBitsAtPosition(input, i) == 0)
                {
                    //Console.WriteLine(Convert.ToString((long)GetThreeBitsAtPosition(input, i)));
                    output = FlipThreeBitsAtPosition(output, i);
                    i -= 2;
                }
            }

            //Console.WriteLine(Convert.ToString((long)output, 2).PadLeft(64, '0'));
            Console.WriteLine(output);
        }

        private static ulong FlipThreeBitsAtPosition(ulong number, int position)
        {
            return number ^ ((ulong)7 << position);
        }

        private static ulong GetThreeBitsAtPosition(ulong number, int position)
        {
            return (number >> position) & 7; // 7 is 0111 mask
        }
    }
}
