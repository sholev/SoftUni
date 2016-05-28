using System;
using System.Linq;

namespace MagicCarNumbers
{
    class FourthExamProblem
    {
        static void Main(string[] args)
        {
            int magicWeight = int.Parse(Console.ReadLine());
            int magicNumbers = 0;
            string carNumber = string.Empty;
            char[] charsInUse = { 'A', 'B', 'C', 'E', 'H', 'K', 'M', 'P', 'T', 'X' };

            //Console.WriteLine(scalcWeight(Console.ReadLine()));

            for (int ch1 = 0; ch1 <= 9; ch1++)
            {
                for (int ch2 = 0; ch2 <= 9; ch2++)
                {
                    for (int a = 0; a <= 9; a++)
                    {
                        for (int b = 0; b <= 9; b++)
                        {
                            if (a != b)
                            {
                                carNumber = "CA" + a + a + a + a + charsInUse[ch1] + charsInUse[ch2];

                                if (stringIsValid(carNumber) &&
                                    calcWeight(carNumber) == magicWeight)
                                {
                                    //Console.WriteLine(carNumber);
                                    magicNumbers++;
                                    b = 9;
                                    continue;
                                }

                                carNumber = "CA" + a + b + b + b + charsInUse[ch1] + charsInUse[ch2];

                                if (stringIsValid(carNumber) &&
                                    calcWeight(carNumber) == magicWeight)
                                {
                                    //Console.WriteLine(carNumber);
                                    magicNumbers++;
                                }

                                carNumber = "CA" + a + a + a + b + charsInUse[ch1] + charsInUse[ch2];

                                if (stringIsValid(carNumber) &&
                                    calcWeight(carNumber) == magicWeight)
                                {
                                    //Console.WriteLine(carNumber);
                                    magicNumbers++;
                                }

                                carNumber = "CA" + a + a + b + b + charsInUse[ch1] + charsInUse[ch2];

                                if (stringIsValid(carNumber) &&
                                    calcWeight(carNumber) == magicWeight)
                                {
                                    //Console.WriteLine(carNumber);
                                    magicNumbers++;
                                }

                                carNumber = "CA" + a + b + a + b + charsInUse[ch1] + charsInUse[ch2];

                                if (stringIsValid(carNumber) &&
                                    calcWeight(carNumber) == magicWeight)
                                {
                                    //Console.WriteLine(carNumber);
                                    magicNumbers++;
                                }

                                carNumber = "CA" + a + b + b + a + charsInUse[ch1] + charsInUse[ch2];

                                if (stringIsValid(carNumber) &&
                                    calcWeight(carNumber) == magicWeight)
                                {
                                    //Console.WriteLine(carNumber);
                                    magicNumbers++;
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine(magicNumbers);
        }

        //private static bool numberIsValid(string sNumber)
        //{
        //    return (sNumber[0] == sNumber[1] && sNumber[1] == sNumber[2] && sNumber[2] == sNumber[3]) ||
        //        (sNumber[0] != sNumber[1] && sNumber[1] == sNumber[2] && sNumber[2] == sNumber[3]) ||
        //        (sNumber[0] == sNumber[1] && sNumber[1] == sNumber[2] && sNumber[2] != sNumber[3]) ||
        //        (sNumber[0] == sNumber[1] && sNumber[1] != sNumber[2] && sNumber[2] == sNumber[3]) ||
        //        (sNumber[0] == sNumber[2] && sNumber[1] == sNumber[3] && sNumber[0] != sNumber[1]) ||
        //        (sNumber[0] == sNumber[3] && sNumber[1] == sNumber[2] && sNumber[0] != sNumber[1]);
        //}

        private static bool stringIsValid(string inputStr)
        {
            string allowedChars = "0123456789ABCEHKMPTX";

            return inputStr.ToUpper().All(c => allowedChars.Contains(c));
        }

        private static int calcWeight(string carNumber)
        {
            int weight = 0;

            foreach (char letter in carNumber)
            {
                switch (letter)
                {
                    case 'A':
                        weight += 10;
                        break;
                    case 'B':
                        weight += 20;
                        break;
                    case 'C':
                        weight += 30;
                        break;
                    case 'E':
                        weight += 50;
                        break;
                    case 'H':
                        weight += 80;
                        break;
                    case 'K':
                        weight += 110;
                        break;
                    case 'M':
                        weight += 130;
                        break;
                    case 'P':
                        weight += 160;
                        break;
                    case 'T':
                        weight += 200;
                        break;
                    case 'X':
                        weight += 240;
                        break;

                    case '1':
                        weight += 1;
                        break;
                    case '2':
                        weight += 2;
                        break;
                    case '3':
                        weight += 3;
                        break;
                    case '4':
                        weight += 4;
                        break;
                    case '5':
                        weight += 5;
                        break;
                    case '6':
                        weight += 6;
                        break;
                    case '7':
                        weight += 7;
                        break;
                    case '8':
                        weight += 8;
                        break;
                    case '9':
                        weight += 9;
                        break;

                    default:
                        break;
                }
            }

            return weight;
        }
    }
}
