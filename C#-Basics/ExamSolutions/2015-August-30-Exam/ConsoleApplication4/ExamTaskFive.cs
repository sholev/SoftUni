using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class ExamTaskFive
    {
        static void Main(string[] args)
        {
            ulong input = ulong.Parse(Console.ReadLine());
            //ulong input = ulong.MaxValue;
            string stringBits = Convert.ToString((long)input, 2);
            int? position = null;
            int? wavelenth = null;

            StringBuilder wave = new StringBuilder();

            wave.Append("101");

            while (wave.Length < 63)
            {
                if (stringBits.Contains(wave.ToString()))
                {
                    position = stringBits.LastIndexOf(wave.ToString());
                    wavelenth = wave.ToString().Length;
                }

                wave.Append("01");
            }

            if (position != null && wavelenth != null)
            {
                //Console.WriteLine(wave.ToString().Substring((int)position + 1, (int)wavelenth));
                Console.WriteLine(Convert.ToInt64(stringBits.Remove((int)position, (int)wavelenth), 2));
            }
            else
            {
                Console.WriteLine("No waves found!");
            }

            


        }
    }
}
