using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hayvan_Numbers
{
    class HayvanNumbers
    {
        static void Main(string[] args)
        {
            int sum = int.Parse(Console.ReadLine());
            int diff = int.Parse(Console.ReadLine());
            bool doesNotExist = true;

            for (int i = 555; i <= 999; i++)
            {
                if (isValidNumber(i) &&
                    isValidNumber(i + diff) &&
                    isValidNumber(i + diff + diff) &&
                    sumIsValid(i, diff, sum))
                {
                    Console.WriteLine("{0}{1}{2}", i, i + diff, i + diff + diff);
                    doesNotExist = false;
                }
            }

            if (doesNotExist)
            {
                Console.WriteLine("No");
            }
        }

        private static bool sumIsValid(int number, int diff, int sum)
        {
            string sNumber = "" + number + (number + diff) + (number + diff + diff);
            int tempSum = 0;

            for (int i = 0; i < sNumber.Length; i++)
                tempSum += int.Parse(sNumber[i].ToString());

            if (tempSum == sum)
                return true;

            else
                return false;
        }

        private static bool isValidNumber(int number)
        {
            string sNumber = number.ToString();
            char[] invalidNumbers = {'0', '1', '2', '3', '4'};

            if (sNumber.IndexOfAny(invalidNumbers) == -1)
                return true;

            else
                return false;
        }
    }
}
