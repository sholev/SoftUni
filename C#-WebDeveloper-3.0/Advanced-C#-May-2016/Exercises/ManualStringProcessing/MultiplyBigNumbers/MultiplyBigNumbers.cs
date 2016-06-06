namespace ManualStringProcessing
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class MultiplyBigNumbers
    {
        static void Main(string[] args)
        {
            string firstNumber = Console.ReadLine().TrimStart('0');
            string secondNumber = Console.ReadLine().TrimStart('0');

            if (firstNumber.Length == 0 || secondNumber.Length == 0)
            {
                Console.WriteLine(0);
                return;
            }

            string sum = firstNumber;
            for (int i = 1; i < int.Parse(secondNumber); i++)
            {
                sum = Sum(sum, firstNumber);
            }

            Console.WriteLine(sum);
        }

        private static string Sum(string firstNumber, string secondNumber)
        {
            Stack<byte> digitStack = new Stack<byte>();
            byte reminder = 0;
            string shorterNumber = firstNumber.Length > secondNumber.Length ? secondNumber : firstNumber;
            string longerNumber = firstNumber.Length <= secondNumber.Length ? secondNumber : firstNumber;
            for (int i = 0; i < shorterNumber.Length; i++)
            {
                byte firstDigit = (byte)char.GetNumericValue(shorterNumber[shorterNumber.Length - 1 - i]);
                byte secondDigit = (byte)char.GetNumericValue(longerNumber[longerNumber.Length - 1 - i]);
                byte addedDigits = (byte)(firstDigit + secondDigit + reminder);
                reminder = (byte)(addedDigits / 10);
                digitStack.Push((byte)(addedDigits % 10));
            }

            if (shorterNumber.Length != longerNumber.Length)
            {
                for (int i = shorterNumber.Length; i < longerNumber.Length; i++)
                {
                    byte digit = (byte)char.GetNumericValue(longerNumber[longerNumber.Length - 1 - i]);
                    byte addedDigits = (byte)(digit + reminder);
                    reminder = (byte)(addedDigits / 10);
                    digitStack.Push((byte)(addedDigits % 10));
                }
            }

            if (reminder != 0)
            {
                digitStack.Push(reminder);
            }

            StringBuilder result = new StringBuilder();
            while (digitStack.Count > 0)
            {
                result.Append(digitStack.Pop());
            }

            return result.ToString();
        }
    }
}
