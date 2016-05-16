using System;
using System.Collections.Generic;
using System.Text;
//using System.Linq;

namespace LongestAlplabeticalWord
{
    class ExamTaskFour
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int wordIndex = 0;

            int matrixSize = int.Parse(Console.ReadLine());
            char[,] brainFunk = new char[matrixSize, matrixSize];
            
            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    brainFunk[row, col] = word[wordIndex];
                    wordIndex++;

                    if (wordIndex >= word.Length)
                    {
                        wordIndex = 0;
                    }
                }
            }

            List<string> allStrings = new List<string>();
            string temp = string.Empty;
            
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    temp += brainFunk[i, j];
                }

                allStrings.Add(temp);
                temp = string.Empty;

                for (int j = 0; j < matrixSize; j++)
                {
                    temp += brainFunk[j, i];
                }

                allStrings.Add(temp);
                temp = string.Empty;

                for (int j = matrixSize - 1; j >= 0; j--)
                {
                    temp += brainFunk[i, j];
                }

                allStrings.Add(temp);
                temp = string.Empty;

                for (int j = matrixSize - 1; j >= 0; j--)
                {
                    temp += brainFunk[j, i];
                }

                allStrings.Add(temp);
                temp = string.Empty;
            }

            allStrings.Sort(); // Lexicographical order needed. ლ(ಠ益ಠლ)
            string longestWord = string.Empty;
            temp = string.Empty;


            foreach (var str in allStrings)
            {
                for (int i = 0; i < str.Length - 1; i++)
                {
                    temp = getWordFromString(str, i);

                    if (longestWord.Length < temp.Length)
                    {
                        longestWord = temp;
                    }
                    else if (longestWord.Length == temp.Length) // Seems that more lexicographical ordering is needed. ლ(ಠ益ಠლ)
                    {
                        //// Get the numeric value of all characters and sum it. Turns out byte[] doesn't have .Sum() huh.
                        //int numericValueOfLongestWord = Array.ConvertAll(Encoding.ASCII.GetBytes(longestWord), b => (int)b).Sum();
                        //int numericValueOfTemp = Array.ConvertAll(Encoding.ASCII.GetBytes(temp), b => (int)b).Sum();

                        //if (numericValueOfLongestWord > numericValueOfTemp)
                        //{
                        //    longestWord = temp;
                        //}

                        if (longestWord[0] > temp[0]) // Who would have thought...
                        {
                            longestWord = temp;
                        }
                    }
                }                
            }

            if (longestWord.Length > 0)
            {
                Console.WriteLine(longestWord);
            }
            else
            {
                Console.WriteLine(word[0]);
            }
            
        }

        private static string getWordFromString(string input, int position)
        {
            StringBuilder result = new StringBuilder();
            result.Append(input[position]);

            for (int i = position + 1; i < input.Length; i++)
            {
                if (result[result.Length - 1] < input[i])
                {
                    result.Append(input[i]);
                }
                else
                {
                    return result.ToString();
                }
            }

            return result.ToString();
        }
    }
}
