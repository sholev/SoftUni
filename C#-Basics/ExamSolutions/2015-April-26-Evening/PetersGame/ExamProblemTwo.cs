using System;
using System.Numerics;

namespace PetersGame
{
    class ExamProblemTwo
    {
        static void Main(string[] args)
        {
            ulong start = ulong.Parse(Console.ReadLine());
            ulong end = ulong.Parse(Console.ReadLine());
            BigInteger sum = 0;
            string sumString = string.Empty;
            string replaceString = Console.ReadLine();

            for (ulong i = start; i < end; i++)
            {
                if (i % 5 == 0)
                {
                    sum += i;
                }
                else
                {
                    sum += i % 5;
                }
            }

            sumString = sum.ToString();

            if (sum % 2 == 0)
            {
                Console.WriteLine(sumString.Replace(sumString[0].ToString(), replaceString));
            }
            else
            {
                Console.WriteLine(sumString.Replace(sumString[sumString.Length - 1].ToString(), replaceString));
            }
            
        }
    }
}
