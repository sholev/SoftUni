namespace Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Exceptions
    {
        public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
        {
            List<T> result = new List<T>();
            for (int i = startIndex; i < startIndex + count; i++)
            {
                result.Add(arr[i]);
            }

            return result.ToArray();
        }

        public static string ExtractEnding(string str, int count)
        {
            string parameterName = nameof(str);
            if (str == null)
            {
                throw new ArgumentNullException(parameterName, "String should not be null");
            }
            if (count > str.Length)
            {
                throw new ArgumentException("Invalid string length.", parameterName);
            }

            StringBuilder result = new StringBuilder();
            for (int i = str.Length - count; i < str.Length; i++)
            {
                result.Append(str[i]);
            }

            return result.ToString();
        }

        public static void CheckPrime(int number)
        {
            double squaredNumber = Math.Sqrt(number);
            for (int divisor = 2; divisor <= squaredNumber; divisor++)
            {
                if (number % divisor == 0)
                {
                    Console.WriteLine($"{number} is not prime.");
                }
            }
            Console.WriteLine($"{number} is prime.");
        }

        static void Main()
        {
            var test = "this is a test".ToList(); 
            var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
            Console.WriteLine(substr);

            var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
            Console.WriteLine(String.Join(" ", subarr));

            var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
            Console.WriteLine(String.Join(" ", allarr));

            var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
            Console.WriteLine(String.Join(" ", emptyarr));

            Console.WriteLine(ExtractEnding("I love C#", 2));
            Console.WriteLine(ExtractEnding("Nakov", 4));
            Console.WriteLine(ExtractEnding("beer", 4));
            Console.WriteLine(ExtractEnding("Hi", 100));

            CheckPrime(23);
            CheckPrime(33);

            List<Exam> peterExams = new List<Exam>()
                                        {
                                            new SimpleMathExam(2),
                                            new CSharpExam(55),
                                            new CSharpExam(100),
                                            new SimpleMathExam(1),
                                            new CSharpExam(0),
                                        };
            Student peter = new Student("Peter", "Petrov", peterExams);
            double peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
    }
}
