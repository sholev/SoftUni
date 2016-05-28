using System;

namespace BitShooter
{
    class ShotData
    {
        public int position;
        public int size;
    }

    class ExamTaskFive
    {
        static void Main(string[] args)
        {
            ulong field = ulong.Parse(Console.ReadLine());
            string shot = string.Empty;
            ShotData[] shots = new ShotData[3];

            for (int i = 0; i < shots.Length; i++)
            {
                shot = Console.ReadLine();

                shots[i] = new ShotData
                {
                    position = int.Parse(shot.Substring(0, shot.IndexOf(' '))), // Number before ' '
                    size = int.Parse(shot.Substring(shot.IndexOf(' ') + 1))     // NUmber after ' '
                };
            }

            //Console.WriteLine(Convert.ToString((long)field, 2).PadLeft(64, '0'));

            for (int i = 0; i < shots.Length; i++)
            {
                shootTheField(ref field, shots[i].position, shots[i].size);
                //Console.WriteLine(Convert.ToString((long)field, 2).PadLeft(64, '0'));
            }

            int leftCount = 0;
            int rightCount = 0;

            for (int i = 0; i < 64; i++)
            {
                if (i < 32 && GetBitAtPosition(field, i) == 1)
                {
                    rightCount++;
                }
                else if (GetBitAtPosition(field, i) == 1)
                {
                    leftCount++;
                }
            }

            Console.WriteLine("left: {0}\r\nright: {1}", leftCount, rightCount);

        }

        private static void shootTheField(ref ulong field, int position, int size)
        {
            position = position + (size / 2) + 1;

            for (int i = size; i > 0; i--)
            {
                if (position - i >= 0 && position - i < 64)
                {
                    field = ZeroBitAtPosition(field, position - i);
                }                
            }
        }

        private static ulong GetBitAtPosition(ulong number, int position)
        {
            return (number >> position) & 1;
        }

        private static ulong ZeroBitAtPosition(ulong number, int position)
        {
            // Cheating with char array. T_T
            char[] binaryNumber = Convert.ToString((long)number, 2).PadLeft(64, '0').ToCharArray();
            Array.Reverse(binaryNumber);
            binaryNumber[position] = '0';
            Array.Reverse(binaryNumber);

            return (ulong)Convert.ToInt64(new string(binaryNumber), 2);

            // Tried this first, but I had problems with it,
            // so I'm skipping it for now untill I figure it out.
            return number & (ulong)(~(1 << position));
        }
    }
}
