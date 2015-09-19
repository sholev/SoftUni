using System;
using System.Collections.Generic;
using System.Text;

namespace EncryptTheMessages
{
    class ExamProblemFour
    {
        static void Main(string[] args)
        {
            List<string> messages = new List<string>();
            List<string> encrypted = new List<string>();
            string input = string.Empty;

            while (input.ToUpper() != "END")
            {
                input = Console.ReadLine();

                if (input.ToUpper() == "START")
                {
                    while (input.ToUpper() != "END")
                    {
                        input = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(input) && input.ToUpper() != "END")
                        {
                            messages.Add(input);
                        }                                                
                    }
                }
            }

            foreach (string message in messages)
            {
                encrypted.Add(EncryptMessage(message));
            }

            if (encrypted.Count > 0)
            {
                Console.WriteLine("Total number of messages: {0}", encrypted.Count);
                foreach (string message in encrypted)
                {
                    Console.WriteLine(message);
                }
            }
            else
            {
                Console.WriteLine("No messages sent.");
            }
            
        }

        private static string EncryptMessage(string message)
        {
            StringBuilder result = new StringBuilder();
            char[] messageArray = message.ToCharArray();

            for (int i = messageArray.Length - 1; i >= 0; i--)
            {
                result.Append(ReplaceCharacter(messageArray[i]));
            }

            return result.ToString();
        }

        private static char ReplaceCharacter(char c)
        {
            char result = new char();

            if ((c >= 'a' && c <= 'm') || (c >= 'A' && c <= 'M'))
            {
                result = (char)(c + 13);
            }
            else if ((c >= 'n' && c <= 'z') || (c >= 'N' && c <= 'Z'))
            {
                result = (char)(c - 13);
            }
            else
            {
                switch (c)
                {
                    case ' ':
                        result = '+';
                        break;

                    case ',':
                        result = '%';
                        break;

                    case '.':
                        result = '&';
                        break;

                    case '?':
                        result = '#';
                        break;

                    case '!':
                        result = '$';
                        break;

                    default:
                        result = c;
                        break;
                }
            }

            return result;
        }
    }
}
