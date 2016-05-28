using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class ExamTaskThree
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int patternStart = 0;
            char stripe = '#';
            char empty = '.';
            char[] pattern = { stripe, empty, empty };


            for (int i = 0; i < n + (n / 2); i++)
            {
                if (patternStart == 3)
                {
                    patternStart = 0;
                }

                switch (patternStart)
                {
                    case 0:
                        PrintRow(pattern, 0, n);
                        break;
                    case 1:
                        PrintRow(pattern, 1, n);
                        break;
                    case 2:
                        PrintRow(pattern, 2, n);
                        break;

                    default:
                        break;
                }
                                
                patternStart++;
                Console.WriteLine();
            }
        }

        private static void PrintRow(char[] pattern, int patternStart, int n)
        {
            for (int i = 0; i < n; i++)
            {
                if (patternStart == 3)
                {
                    patternStart = 0;
                }
                Console.Write(pattern[patternStart]);
                patternStart++;
            }

            
        }
    }
}
