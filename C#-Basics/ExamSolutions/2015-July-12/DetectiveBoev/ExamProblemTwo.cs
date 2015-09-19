using System;
using System.Text;

namespace DetectiveBoev
{
    class ExamProblemTwo
    {
        static void Main(string[] args)
        {

            string secretWord = Console.ReadLine();
            string encryptedMessage = Console.ReadLine();

            int mask = GetMask(secretWord);
            string decryptedMessage = DecryptMessage(encryptedMessage, mask);

            Console.WriteLine(ReverseString(decryptedMessage));
        }

        private static string ReverseString(string s)
        {
            char[] result = s.ToCharArray();
            Array.Reverse(result);

            return new string(result);
        }

        private static string DecryptMessage(string encryptedMessage, int mask)
        {
            StringBuilder result = new StringBuilder();

            foreach (char c in encryptedMessage)
            {
                if (c % mask == 0)
                {
                    result.Append((char)(c + mask));
                }
                else
                {
                    result.Append((char)(c - mask));
                }
            }

            return result.ToString();
        }

        private static int GetMask(string secretWord)
        {
            int result = 0;
            int temp = 0;
            
            foreach (char c in secretWord)
            {
                result += c;
            }            

            while (result > 9)
            {
                foreach (char c in result.ToString())
                {
                    temp += (int)char.GetNumericValue(c);
                }
                result = temp;
                temp = 0;
            }            

            return result;
        }
    }
}
