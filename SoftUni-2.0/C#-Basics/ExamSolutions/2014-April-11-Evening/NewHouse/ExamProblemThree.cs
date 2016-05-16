using System;

namespace NewHouse
{
    class ExamProblemThree
    {
        static void Main(string[] args)
        {
            char house = '*';
            char empty = '-';
            char walls = '|';

            int houseHeight = Int32.Parse(Console.ReadLine());
            int roofWidth = 1;

            while (roofWidth <= houseHeight)
            {
                Console.WriteLine("{0}{1}{2}",
                    new string(empty, (houseHeight - roofWidth) / 2),
                    new string(house, roofWidth),
                    new string(empty, (houseHeight - roofWidth) / 2));

                roofWidth += 2;
            }

            for (int i = 0; i < houseHeight; i++)
            {
                Console.WriteLine("{0}{1}{2}",
                    walls,
                    new string(house, houseHeight - 2),
                    walls);
            }
        }
    }
}
