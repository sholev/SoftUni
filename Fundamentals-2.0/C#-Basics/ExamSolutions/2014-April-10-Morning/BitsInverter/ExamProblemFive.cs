using System;

namespace BitsInverter
{
    class ExamProblemFive
    {
        static void Main(string[] args)
        {
            byte numberOfBytes = byte.Parse(Console.ReadLine());
            byte invertStep = byte.Parse(Console.ReadLine());
            byte[] bytesInput = new byte[numberOfBytes];
            byte[] bytesOutput = new byte[numberOfBytes];
            int flipIndex = 0;
            int position = 0;

            for (int i = 0; i < numberOfBytes; i++)
            {
                bytesInput[i] = byte.Parse(Console.ReadLine());
            }

            for (int i = 0; i < numberOfBytes; i++)
            {
                bytesOutput[i] = bytesInput[i];
                bytesOutput[i] = ReverseBitsWith7Operations(bytesOutput[i]);

                for (int bit = 0; bit < 8; bit++)
                {
                    position = (i * 8) + bit;

                    if (position == flipIndex)
                    {                        
                        bytesOutput[i] = InvertBitAtPosition(bytesOutput[i], (byte)bit);
                        
                        flipIndex += invertStep;
                        bit += (invertStep - 1);                        
                    }
                }

                bytesOutput[i] = ReverseBitsWith7Operations(bytesOutput[i]);
            }

            for (int i = 0; i < numberOfBytes; i++)
            {
                Console.WriteLine(bytesOutput[i]);
                //Console.WriteLine(Convert.ToString(bytesInput[i], 2).PadLeft(8, '0'));
                //Console.WriteLine(Convert.ToString(bytesOutput[i], 2).PadLeft(8, '0'));
            }


        }

        private static byte InvertBitAtPosition(byte number, byte position)
        {
            return (byte)(number ^ (1 << position));
        }

        // http://stackoverflow.com/questions/3587826/is-there-a-built-in-function-to-reverse-bit-order
        public static byte ReverseBitsWith7Operations(byte b)
        {
            return (byte)(((b * 0x0802u & 0x22110u) | (b * 0x8020u & 0x88440u)) * 0x10101u >> 16);
        }
    }
}
