namespace Methods
{
    using System;

    public class Methods
    {
        public static double CalcTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentOutOfRangeException("Triangle sides must be positive.");
            }
            double halfPerimeter = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(
                halfPerimeter *
                (halfPerimeter - sideA) *
                (halfPerimeter - sideB) *
                (halfPerimeter - sideC));
            return area;
        }

        public static string DigitToString(int number)
        {
            if (number < 0 || number > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(number) + "must be a single digit.");
            }

            string[] digitStrings =
                {
                    "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"
                };

            return digitStrings[number];
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(elements) + "Must contain at least one element");
            }

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > elements[0])
                {
                    elements[0] = elements[i];
                }
            }

            return elements[0];
        }

        public static void PrintNumber2DigitsFloatingPoint(object number)
        {
            Console.WriteLine("{0:f2}", number);
        }

        public static void PrintNumberAsPercent(object number)
        {
            Console.WriteLine("{0:p0}", number);
        }

        public static void PrintNumberAlignedRight(object number)
        {
            Console.WriteLine("{0,8}", number);
        }

        public static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        private static bool isVertical(double x1, double x2)
        {
            return (x1 == x2);
        }

        private static bool isHorizontal(double y1, double y2)
        {
            return (y1 == y2);
        }

        static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));
            
            Console.WriteLine(DigitToString(5));
            
            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintNumber2DigitsFloatingPoint(1.3);
            PrintNumberAsPercent(0.75);
            PrintNumberAlignedRight(2.30);
            
            Console.WriteLine(CalcDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + isHorizontal(3, 3));
            Console.WriteLine("Vertical? " + isVertical(-1, 2.5));

            Student peter = new Student("Peter", "Ivanov", new DateTime(1992, 03, 17), "From Sofia");
            Student stella = new Student("Stella", "Markova", new DateTime(1993, 11, 03), "From Vidin", "gamer", "high results");

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
