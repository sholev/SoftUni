using System;

namespace CatchTheBits
{
    class ExamProblemFive
    {
        static void Main(string[] args)
        {
            int numberOfBytes = int.Parse(Console.ReadLine());
            int position = int.Parse(Console.ReadLine());
            int[] bytes = new int[numberOfBytes];

            for (int i = 0; i < bytes.Length; i++)
                bytes[i] = int.Parse(Console.ReadLine());


            int index = 1;
            int result = 0;
            int shifts = 0;

            for (int i = 0; i < bytes.Length; i++)
                for (int l = 0; l < 8; l++)
                    if (index == l + (i * 8))
                    {
                        result = result << 1;
                        shifts++;
                        result = SetBitAtPosition(result, 0, GetBitAtPosition(bytes[i], 7 - l));
                        if (shifts == 8)
                        {
                            shifts = 0;
                            Console.WriteLine(result);
                            result = 0;
                        }
                        index += position;
                    }
            if (shifts != 0)
                Console.WriteLine(result << (8 - shifts));
        }

        private static int GetBitAtPosition(int number, int position)
        {
            return (number >> position) & 1;
        }

        private static int SetBitAtPosition(int number, int position, int setBitTo)
        {
            if (setBitTo == 1)
                return number | (1 << position);
            else
                return number & ~(1 << position);
        }
    }
}
