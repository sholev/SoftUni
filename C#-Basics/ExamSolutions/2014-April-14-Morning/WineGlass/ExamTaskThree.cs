using System;

namespace WineGlass
{
    class ExamTaskThree
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());

            char glassWallLeft = '\\';
            char glassWallRight = '/';
            char glassContent = '*';
            char glassStem = '|';
            char glassBase = '-';
            char emptySpace = '.';


            for (int row = 0; row < numberOfRows; row++)
            {
                if (row < numberOfRows / 2)
                {
                    Console.WriteLine("{0}{1}{2}{3}{4}",
                        new string(emptySpace, row),
                        glassWallLeft,
                        new string(glassContent, (numberOfRows - 2) - 2 * row),
                        glassWallRight,
                        new string(emptySpace, row));
                }
                else if (numberOfRows >= 12 && row < numberOfRows - 2)
                {
                    Console.WriteLine("{0}{1}{2}",
                        new string(emptySpace, (numberOfRows / 2) - 1),
                        new string(glassStem, 2),
                        new string(emptySpace, (numberOfRows / 2) - 1));
                }
                else if (numberOfRows < 12 && row < numberOfRows - 1)
                {
                    Console.WriteLine("{0}{1}{2}",
                        new string(emptySpace, (numberOfRows / 2) - 1),
                        new string(glassStem, 2),
                        new string(emptySpace, (numberOfRows / 2) - 1));
                }
                else
                {
                    Console.WriteLine(new string(glassBase, numberOfRows));
                }
            }
        }
    }
}
