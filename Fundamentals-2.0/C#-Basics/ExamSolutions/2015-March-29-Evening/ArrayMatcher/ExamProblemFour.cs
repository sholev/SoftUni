using System;
using System.Collections.Generic;
using System.Linq;

namespace ArrayMatcher
{
    class ExamProblemFour
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split('\\');

            List<char> left = input[0].ToCharArray().ToList();
            List<char> right = input[1].ToCharArray().ToList();
            string command = input[2];

            List<char> result = new List<char>();

            switch (command)
            {
                case "join":

                    foreach (char element in right)
                    {
                        result.AddRange(left.FindAll(c => c == element));
                    }

                    result.Sort();

                    Console.WriteLine(String.Join("", result.Distinct()));

                    break;

                case "right exclude":

                    result = left;

                    foreach (char element in right)
                    {
                        result.RemoveAll(c => c == element);
                    }
                    
                    result.Sort();

                    Console.WriteLine(String.Join("", result.Distinct()));

                    break;

                case "left exclude":

                    result = right;

                    foreach (char element in left)
                    {
                        result.RemoveAll(c => c == element);
                    }

                    result.Sort();

                    Console.WriteLine(String.Join("", result.Distinct()));

                    break;

                default:
                    break;
            }
        }
    }
}
