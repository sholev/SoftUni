using System;

namespace ProgrammerDNA
{
    class ExamProblemThree
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char startLetter = char.Parse(Console.ReadLine());
            char currentLetter = startLetter;
            bool increasingWidth = true;
            int width = 1;

            for (int i = 0; i < rows; i++)
            {
                if (increasingWidth == true && width < 7)
                {
                    Console.WriteLine("{0}{1}{2}",
                        new string('.', (7 - width) / 2),
                        getLetters(ref currentLetter, width),
                        new string('.', (7 - width) / 2));

                    width += 2;
                }
                else if (increasingWidth == true && width == 7)
                {
                    Console.WriteLine("{0}",
                        getLetters(ref currentLetter, width));

                    width -= 2;
                    increasingWidth = !increasingWidth;
                }
                else if (increasingWidth == false && width > 1)
                {
                    Console.WriteLine("{0}{1}{2}",
                        new string('.', (7 - width) / 2),
                        getLetters(ref currentLetter, width),
                        new string('.', (7 - width) / 2));

                    width -= 2;
                }
                else if (increasingWidth == false && width == 1)
                {
                    Console.WriteLine("{0}{1}{2}",
                        new string('.', (7 - width) / 2),
                        getLetters(ref currentLetter, width),
                        new string('.', (7 - width) / 2));

                    if (i != rows - 1)
                    {
                        Console.WriteLine("{0}{1}{2}",
                            new string('.', (7 - width) / 2),
                            getLetters(ref currentLetter, width),
                            new string('.', (7 - width) / 2));
                        rows--;
                    }

                    width += 2;
                    increasingWidth = !increasingWidth;
                }
            }
        }

        private static string getLetters(ref char currentLetter, int width)
        {
            string output = string.Empty;

            for (int i = 0; i < width; i++)
            {
                if (currentLetter == 'H')
                {
                    currentLetter = 'A';
                }

                output += currentLetter;
                currentLetter++;
            }

            return output;
        }
    }
}
